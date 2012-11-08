using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EmpresaController empresaController = new EmpresaController();
                txtEmpresa.DataSource = empresaController.ObterTodos(Session["cnpjEmp"].ToString());
                txtEmpresa.DataTextField = "nomEmp";
                txtEmpresa.DataValueField = "cnpjEmp";
                txtEmpresa.DataBind();

                txtEmpresa.Items.Insert(0, new ListItem("", "0"));

                if (Request.QueryString["codCli"] != null)
                {
                    PreencheCampos();
                    txtEmpresa.Enabled = false;
                    txtEmpresa.Focus();
                } 
            }
        }

        protected void txtEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpresa.Focus();

            try
            {
                txtCnpj.Text = txtEmpresa.SelectedValue;

                if (txtEmpresa.SelectedValue != "0")
                {
                    txtVendedor.Items.Clear();
                    UsuarioController usuarioController = new UsuarioController();
                    txtVendedor.DataSource = usuarioController.ObterTodosFuncionarios(txtEmpresa.SelectedValue);
                    txtVendedor.DataTextField = "nomUsu";
                    txtVendedor.DataValueField = "cpfUsu";
                    txtVendedor.DataBind();

                    txtVendedor.Items.Insert(0, new ListItem("", "0"));
                }
                else
                {
                    txtVendedor.Items.Clear();
                    txtVendedor.Items.Insert(0, new ListItem("Selecione uma empresa", "0"));
                    txtVendedor.Items.Insert(0, new ListItem("", "0"));
                }
            }
            catch
            { }
        }

        private void PreencheCampos()
        {
            ClienteController clienteController = new ClienteController();
            ClienteEntity cliente = clienteController.Obter(Convert.ToInt32(Request.QueryString["codCli"].ToString()));
            try
            {
                txtEmpresa.Items.FindByValue(cliente.cnpjCli).Selected = true;
                txtEmpresa_SelectedIndexChanged(null, null);
                txtCnpj.Text = cliente.cnpjCli;
                txtVendedor.Items.FindByValue(cliente.cpfVen).Selected = true;
            }
            catch
            { }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cliente.aspx");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            ClienteEntity cliente = new ClienteEntity();
            VendedorEntity vendedor = new VendedorEntity();
            ClienteController clienteController = new ClienteController();
            VendedorController vendedorController = new VendedorController();

            if (txtEmpresa.SelectedValue == "0" || txtVendedor.SelectedValue == "0")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                cliente.cnpjEmp = Session["cnpjEmp"].ToString();
                cliente.cnpjCli = txtEmpresa.SelectedValue;

                vendedor.cpfUsu = txtVendedor.SelectedValue;
                vendedor.cnpjEmp = Session["cnpjEmp"].ToString();
                vendedor.cnpjCli = txtEmpresa.SelectedValue;

                if (Request.QueryString["codCli"] != null)
                {
                    if (vendedorController.Atualizar(vendedor))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Cliente alterado com sucesso!'); window.location.href='Cliente.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
                else
                {
                    if (clienteController.Inserir(cliente))
                    {
                        vendedorController.Inserir(vendedor);
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Cliente salvo com sucesso!'); window.location.href='Cliente.aspx';</script>");
                    }
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na inclusão do registro!');</script>");
                }
            }
        }        
    }
}