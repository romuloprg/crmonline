using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class EmpregoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EmpresaController empresaController = new EmpresaController();
                txtEmpresa.DataSource = empresaController.ObterTodos();
                txtEmpresa.DataTextField = "nomEmp";
                txtEmpresa.DataValueField = "cnpjEmp";
                txtEmpresa.DataBind();

                txtEmpresa.Items.Insert(0, new ListItem("", "0"));
                txtEmpresa.Items.Insert(0, new ListItem("Nenhuma", "0"));

                PreencheCampos();
                txtEmpresa.Focus();
            }
        }

        private void PreencheCampos()
        {
            ContratoController contratoController = new ContratoController();
            ContratoEntity contrato = contratoController.ObterAtivo(Session["cpfUsu"].ToString());

            txtCpf.Text = Session["cpfUsu"].ToString();
            txtNome.Text = Session["nomUsu"].ToString();
            try
            {
                txtEmpresa.Items.FindByValue(contrato.cnpjEmp).Selected = true;
            }
            catch
            { }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Emprego.aspx");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            ContratoController contratoController = new ContratoController();
            VendedorController vendedorController = new VendedorController();

            ContratoEntity contrato = new ContratoEntity();
            contrato.cpfUsu = Session["cpfUsu"].ToString();
            contrato.cnpjEmp = txtEmpresa.SelectedValue;
            contrato.codCar = 1; // 1 -> código de funcionário

            if (txtNome.Text == "" || txtCpf.Text == "")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                if (vendedorController.ObterTodos(Session["cpfUsu"].ToString()).Count <= 0)
                {
                    if (txtEmpresa.SelectedValue == "0")
                    {
                        if (contratoController.Cancelar(Session["cpfUsu"].ToString()))
                            this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Contrato finalizado com sucesso!'); window.location.href='Login.aspx';</script>");
                        else
                            this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                    }
                    else if (contratoController.Inserir(contrato))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Contrato criado com sucesso!'); window.location.href='Login.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na criação do registro!');</script>");
                }
                else
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro, você ainda é vendedor de alguma empresa!');</script>");
            }
        }
    }
}