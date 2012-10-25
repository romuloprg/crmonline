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
    public partial class PermissaoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
            {
                try
                {
                    string cpfUsu = Request.QueryString["cpfUsu"].ToString();
                    preencheCampos(cpfUsu);
                    txtCpf.Enabled = false;
                    txtPermissao.Focus();
                }
                catch
                { }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            // Cria a instância
            UsuarioEntity usuario = new UsuarioEntity();
            UsuarioController usuarioController = new UsuarioController();

            if (txtNome.Text == "" || txtCpf.Text == "" || txtPermissao.SelectedValue == "0")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                string cpfUsu = null;

                try
                {
                    cpfUsu = Request.QueryString["cpfUsu"].ToString();
                    usuario = usuarioController.Obter(cpfUsu);
                }
                catch
                { }

                // Chama método
                if (cpfUsu != null)
                {
                    if (usuarioController.AtualizarContrato(usuario.cpfUsu, usuario.cnpjEmp, Convert.ToInt32(txtPermissao.SelectedValue)))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Permissão alterada com sucesso!'); window.location.href='Permissao.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Permissao.aspx");
        }

        private void preencheCampos(string cpfUsu)
        {
            UsuarioController usuarioController = new UsuarioController();
            UsuarioEntity usuario = usuarioController.Obter(cpfUsu);

            txtCpf.Text = usuario.cpfUsu;
            txtNome.Text = usuario.nomUsu;
            txtPermissao.Items.FindByValue(usuario.codCar.ToString()).Selected = true;
        }
    }
}