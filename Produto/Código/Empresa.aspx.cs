using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ExtraController extraController = new ExtraController();
                txtUf.DataSource = extraController.listaEstado();
                txtUf.DataTextField = "sigEst";
                txtUf.DataValueField = "sigEst";
                txtUf.DataBind();

                txtUf.Items.Insert(0, new ListItem("", "0"));

                if (Session["cnpjEmp"] != null)
                {
                    PreencheCampos();
                    txtCnpj.Enabled = false;
                    btnExcluir.Visible = true;
                    txtNome.Focus();
                }
            }
        }

        protected void txtUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUf.Focus();

            try
            {
                if (txtUf.SelectedValue != "0")
                {
                    txtCidade.Items.Clear();
                    ExtraController extraController = new ExtraController();
                    txtCidade.DataSource = extraController.listaCidade(txtUf.SelectedValue);
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
            catch
            { }
        }

        private void PreencheCampos()
        {
            EmpresaController empresaController = new EmpresaController();
            EmpresaEntity empresa = empresaController.Obter(Session["cnpjEmp"].ToString());
            txtCnpj.Text = empresa.cnpjEmp;
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            EmpresaEntity empresa = new EmpresaEntity();
            EmpresaController empresaController = new EmpresaController();

            if (txtCnpj.Text == "" || txtNome.Text == "" || txtTelefone.Text == "")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                empresa.cnpjEmp = txtCnpj.Text;
                empresa.nomEmp = txtNome.Text;
                empresa.endEmp = txtEndereco.Text;
                empresa.cidEmp = txtCidade.Text;
                empresa.ufEmp = txtUf.Text;
                empresa.telEmp = txtTelefone.Text;

                if (Session["cnpjEmp"] != null)
                {
                    if (empresaController.Atualizar(empresa))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa alterada com sucesso!'); window.location.href='Home.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
                else
                {
                    if (empresaController.Inserir(empresa))
                    {
                        ContratoEntity contrato = new ContratoEntity();
                        contrato.cpfUsu = Session["cpfUsu"].ToString();
                        contrato.cnpjEmp = empresa.cnpjEmp;
                        contrato.codCar = 3; // 3 -> código de proprietário
                        ContratoController contratoController = new ContratoController();
                        contratoController.Inserir(contrato);

                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa salva com sucesso!'); window.location.href='Login.aspx';</script>");
                    }
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na inclusão do registro!');</script>");
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            EmpresaController empresaController = new EmpresaController();
            ClienteController clienteController = new ClienteController();
            VendedorController vendedorController = new VendedorController();
            UsuarioController usuarioController = new UsuarioController();
            ContratoController contratoController = new ContratoController();

            if (usuarioController.ObterTodosFuncionarios(Session["cnpjEmp"].ToString()).Count <= 0)
            {
                List<ClienteEntity> clientes = clienteController.ObterTodos(Session["cnpjEmp"].ToString());
                for (int i = 0; i < clientes.Count; i++)
                {
                    vendedorController.Remover(clientes[i].codCli);
                    clienteController.Remover(clientes[i].codCli);
                }

                contratoController.Remover(Session["cpfUsu"].ToString());

                if (empresaController.Remover(Session["cnpjEmp"].ToString()))
                {
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa removida com sucesso!'); window.location.href='Login.aspx';</script>");
                }
            }
            else
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na remoção do registro, sua empresa ainda possui funcionários!');</script>");
        }
    }
}