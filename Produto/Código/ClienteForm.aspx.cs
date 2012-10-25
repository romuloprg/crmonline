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
    public partial class ClienteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
            {
                EmpresaController empresaController = new EmpresaController();
                txtEmpresa.DataSource = empresaController.ObterTodos();
                txtEmpresa.DataTextField = "nomEmp";
                txtEmpresa.DataValueField = "cnpjEmp";
                txtEmpresa.DataBind();

                txtEmpresa.Items.Insert(0, new ListItem("", "0"));

                ExtrasController extras = new ExtrasController();
                txtUf.DataSource = extras.listaEstado();
                txtUf.DataTextField = "sigEst";
                txtUf.DataValueField = "sigEst";
                txtUf.DataBind();

                txtUf.Items.Insert(0, new ListItem("", "0"));

                try
                {
                    int codCli = Convert.ToInt32(Request.QueryString["codCli"]);
                    preencheCampos(codCli);
                    txtNome.Focus();
                }
                catch
                { }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            // Cria a instância
            ClienteEntity cliente = new ClienteEntity();
            ClienteController clienteController = new ClienteController();

            if (txtNome.Text == "" || txtEmpresa.SelectedValue == "0")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                cliente.nomCli = txtNome.Text;
                cliente.endCli = txtEndereco.Text;
                cliente.cidCli = txtCidade.Text;
                cliente.ufCli = txtUf.Text;
                cliente.nomEmp = txtEmpresa.Text;
                cliente.cnpjEmp = txtEmpresa.Text;

                int codCli = 0;

                try
                {
                    codCli = Convert.ToInt32(Request.QueryString["codCli"]);
                }
                catch
                { }

                // Chama método
                if (codCli != 0)
                {
                    cliente.codCli = codCli;
                    if (clienteController.Atualizar(cliente))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Cliente alterado com sucesso!'); window.location.href='Cliente.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
                else
                {
                    if (clienteController.Inserir(cliente))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Cliente salvo com sucesso!'); window.location.href='Cliente.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na inclusão do registro!');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cliente.aspx");
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

        private void preencheCampos(int codCli)
        {
            ClienteController clienteController = new ClienteController();
            ClienteEntity cliente = clienteController.Obter(codCli);
            txtNome.Text = cliente.nomCli;
            txtEndereco.Text = cliente.endCli;
            try
            {
                txtUf.Items.FindByText(cliente.ufCli).Selected = true;
                txtUf_SelectedIndexChanged(null, null);
                txtCidade.Items.FindByText(cliente.cidCli).Selected = true;
            }
            catch
            { }
            txtEmpresa.Items.FindByText(cliente.nomEmp).Selected = true;
        }
    }
}