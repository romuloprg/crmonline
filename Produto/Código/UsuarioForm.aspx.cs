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
    public partial class UsuarioForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
            {
                GraduacaoController graduacaoController = new GraduacaoController();
                txtGraduacao.DataSource = graduacaoController.ObterTodos();
                txtGraduacao.DataTextField = "nomGra";
                txtGraduacao.DataValueField = "codGra";
                txtGraduacao.DataBind();

                txtGraduacao.Items.Insert(0, new ListItem("", "0"));
                
                ExtrasController extras = new ExtrasController();
                txtUf.DataSource = extras.listaEstado();
                txtUf.DataTextField = "sigEst";
                txtUf.DataValueField = "sigEst";
                txtUf.DataBind();

                txtUf.Items.Insert(0, new ListItem("", "0"));
                
                try
                {
                    string cpfUsu = Request.QueryString["cpfUsu"].ToString();
                    preencheCampos(cpfUsu);
                    txtCpf.Enabled = false;
                    txtNome.Focus();
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

            if (txtNome.Text == "" || txtCpf.Text == "" || txtSexo.SelectedValue == "0" || txtEmail.Text == "" || txtSenha.Text == "" || txtGraduacao.SelectedValue == "0")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                usuario.cpfUsu = txtCpf.Text;
                usuario.nomUsu = txtNome.Text;
                usuario.endUsu = txtEndereco.Text;
                usuario.cidUsu = txtCidade.Text;
                usuario.ufUsu = txtUf.Text;
                usuario.sexUsu = txtSexo.SelectedValue;
                usuario.telUsu = txtTelefone.Text;
                usuario.emaUsu = txtEmail.Text;
                usuario.senUsu = txtSenha.Text;
                usuario.codGra = Convert.ToInt32(txtGraduacao.SelectedValue);

                if (usuarioController.Atualizar(usuario))
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Usuario alterado com sucesso!'); window.location.href='Usuario.aspx';</script>");
                else
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuario.aspx");
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

        private void preencheCampos(string cpfUsu)
        {
            UsuarioController usuarioController = new UsuarioController();
            UsuarioEntity usuario = usuarioController.Obter(cpfUsu);

            txtCpf.Text = usuario.cpfUsu;
            txtNome.Text = usuario.nomUsu;
            txtEndereco.Text = usuario.endUsu;
            try
            {
                txtUf.Items.FindByText(usuario.ufUsu).Selected = true;
                txtUf_SelectedIndexChanged(null, null);
                txtCidade.Items.FindByText(usuario.cidUsu).Selected = true;
            }
            catch
            { }
            txtSexo.Items.FindByValue(usuario.sexUsu).Selected = true;
            txtTelefone.Text = usuario.telUsu;
            txtEmail.Text = usuario.emaUsu;
            txtSenha.Text = usuario.senUsu;
            txtGraduacao.Items.FindByValue(usuario.codGra.ToString()).Selected = true;
        }
    }
}