using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class FuncionarioForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PreencheCampos();
                txtCargo.Focus();
            }
        }

        private void PreencheCampos()
        {
            try
            {
                string cpfUsu = Request.QueryString["cpfUsu"].ToString();
                UsuarioController usuarioController = new UsuarioController();
                UsuarioEntity usuario = usuarioController.Obter(cpfUsu);

                txtCpf.Text = usuario.cpfUsu;
                txtNome.Text = usuario.nomUsu;
                txtCargo.Items.FindByValue(usuario.codCar.ToString()).Selected = true;
            }
            catch
            { }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Funcionario.aspx");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            ContratoEntity contrato = new ContratoEntity();
            ContratoController contratoController = new ContratoController();

            if (txtNome.Text == "" || txtCpf.Text == "" || txtCargo.SelectedValue == "0")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                string cpfUsu = null;

                try
                {
                    cpfUsu = Request.QueryString["cpfUsu"].ToString();
                    contrato = contratoController.ObterAtivo(cpfUsu);
                    contrato.codCar = Convert.ToInt32(txtCargo.SelectedValue);
                }
                catch
                { }

                if (cpfUsu != null)
                {
                    if (contratoController.Atualizar(contrato))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Contrato alterado com sucesso!'); window.location.href='Funcionario.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
            }
        }
    }
}