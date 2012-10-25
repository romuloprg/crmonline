using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class EmpresaForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
            {
                ExtrasController extras = new ExtrasController();
                txtUf.DataSource = extras.listaEstado();
                txtUf.DataTextField = "sigEst";
                txtUf.DataValueField = "sigEst";
                txtUf.DataBind();

                txtUf.Items.Insert(0, new ListItem("", "0"));

                try
                {
                    string cnpjEmp = Request.QueryString["cnpjEmp"].ToString();
                    preencheCampos(cnpjEmp);
                    txtCnpj.Enabled = false;
                    txtRazao.Focus();
                }
                catch
                { }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            // Cria a instância
            EmpresaEntity empresa = new EmpresaEntity();
            EmpresaController empresaController = new EmpresaController();

            if (txtCnpj.Text == "" || txtRazao.Text == "" || txtNome.Text == "")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                empresa.cnpjEmp = txtCnpj.Text;
                empresa.razEmp = txtRazao.Text;
                empresa.nomEmp = txtNome.Text;
                empresa.endEmp = txtEndereco.Text;
                empresa.cidEmp = txtCidade.Text;
                empresa.ufEmp = txtUf.Text;
                empresa.telEmp = txtTelefone.Text;

                string cnpjEmp = null;

                try
                {
                    cnpjEmp = Request.QueryString["cnpjEmp"].ToString();
                }
                catch
                { }

                // Chama método
                if (cnpjEmp != null)
                {
                    empresa.cnpjEmp = cnpjEmp;
                    if (empresaController.Atualizar(empresa))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa alterada com sucesso!'); window.location.href='Empresa.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
                else
                {
                    if (empresaController.Inserir(empresa, Session["cpf"].ToString()))
                    {
                        UsuarioController usuarioController = new UsuarioController();
                        usuarioController.InserirContrato(Session["cpf"].ToString(), empresa.cnpjEmp, 3); // 3 -> código de proprietário

                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa salva com sucesso!'); window.location.href='Empresa.aspx';</script>");
                    }
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na inclusão do registro!');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Empresa.aspx");
        }

        protected void txtUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUf.Focus();

            try
            {
                if (txtUf.SelectedValue != "0")
                {
                    txtCidade.Items.Clear();
                    ExtrasController extras = new ExtrasController();
                    txtCidade.DataSource = extras.listaCidade(txtUf.SelectedValue);
                    txtCidade.DataTextField = "nomCid";
                    txtCidade.DataValueField = "nomCid";
                    txtCidade.DataBind();

                    txtCidade.Items.Insert(0, new ListItem("", "0"));
                }
                else
                {
                    txtCidade.Items.Clear();
                    txtCidade.Items.Insert(0, new ListItem("Selecione um estado", "0"));
                    txtCidade.Items.Insert(0, new ListItem("", "0"));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void preencheCampos(string cnpjEmp)
        {
            EmpresaController empresaController = new EmpresaController();
            EmpresaEntity empresa = empresaController.Obter(cnpjEmp);
            txtCnpj.Text = empresa.cnpjEmp;
            txtRazao.Text = empresa.razEmp;
            txtNome.Text = empresa.nomEmp;
            txtEndereco.Text = empresa.endEmp;
            try
            {
                txtUf.Items.FindByText(empresa.ufEmp).Selected = true;
                txtUf_SelectedIndexChanged(null, null);
                txtCidade.Items.FindByText(empresa.cidEmp).Selected = true;
            }
            catch
            { }
            txtTelefone.Text = empresa.telEmp;
        }
    }
}