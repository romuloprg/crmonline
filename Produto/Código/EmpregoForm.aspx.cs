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
    public partial class EmpregoForm : System.Web.UI.Page
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
                
                preencheCampos();
                txtEmpresa.Focus();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            // Cria a instância
            UsuarioController usuarioController = new UsuarioController();

            if (txtNome.Text == "" || txtCpf.Text == "")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                // Chama método
                if (Session["cpf"].ToString() != null)
                {
                    if (txtEmpresa.SelectedValue == "0")
                    {
                        if (usuarioController.RemoverContrato(Session["cpf"].ToString()))
                            this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa alterada com sucesso!'); window.location.href='Emprego.aspx';</script>");
                        else
                            this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                    }
                    else if (usuarioController.InserirContrato(Session["cpf"].ToString(), txtEmpresa.SelectedValue, 1))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa alterada com sucesso!'); window.location.href='Emprego.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Emprego.aspx");
        }

        private void preencheCampos()
        {
            UsuarioController usuarioController = new UsuarioController();
            ContratoEntity contrato = usuarioController.ObterContrato(Session["cpf"].ToString());

            txtCpf.Text = Session["cpf"].ToString();
            txtNome.Text = Session["nome"].ToString();
            try
            {
                txtEmpresa.Items.FindByValue(contrato.cnpjEmp).Selected = true;
            }
            catch
            { }
        }
    }
}