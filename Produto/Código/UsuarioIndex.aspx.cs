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
    public partial class UsuarioIndex : System.Web.UI.Page
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
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            // Cria a instância
            UsuarioEntity usuario = new UsuarioEntity();
            UsuarioController usuarioController = new UsuarioController();

            if (txtNome.Text == "" || txtCpf.Text == "" || txtSexo.SelectedValue == "0" || txtEmail.Text == "" || txtGraduacao.SelectedValue == "0")
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

                // Chama método
                if (usuarioController.Inserir(usuario))
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Usuario salvo com sucesso!'); window.location.href='Index.aspx';</script>");
                else
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na inclusão do registro!');</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
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
    }
}