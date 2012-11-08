using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class AtividadeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClienteController clienteController = new ClienteController();
                txtCliente.DataSource = clienteController.ObterTodos(Session["cnpjEmp"].ToString());
                txtCliente.DataTextField = "nomCli";
                txtCliente.DataValueField = "codCli";
                txtCliente.DataBind();

                UsuarioController usuarioController = new UsuarioController();
                lstParticipantes.DataSource = usuarioController.ObterParteFuncionarios(Session["cpfUsu"].ToString());
                lstParticipantes.DataTextField = "nomUsu";
                lstParticipantes.DataValueField = "cpfUsu";
                lstParticipantes.DataBind();

                txtCliente.Items.Insert(0, new ListItem("", "0"));

                if (Request.QueryString["codAti"] != null)
                {
                    PreencheCampos();
                    txtCliente.Enabled = false;
                    txtCliente.Focus();
                }
            }
        }

        private void PreencheCampos()
        {
            AtividadeController atividadeController = new AtividadeController();
            AtividadeEntity atividade = atividadeController.Obter(Convert.ToInt32(Request.QueryString["codAti"].ToString()));
            ParticipanteController participanteController = new ParticipanteController();

            try
            {
                txtCliente.Items.FindByValue(atividade.codCli.ToString()).Selected = true;

                List<string> participantes = participanteController.ObterTodos(Convert.ToInt32(Request.QueryString["codAti"].ToString()));
                for (int i = 0; i < lstParticipantes.Items.Count; i++)
                {
                    if (participantes.Contains(lstParticipantes.Items[i].Value))
                        lstParticipantes.Items[i].Selected = true;
                }
            }
            catch
            { }
            txtDescricao.Text = atividade.desAti;
            txtTipo.Text = atividade.tipAti;
            txtData.Text = atividade.datAti;
            txtHora.Text = atividade.horAti;


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Atividade.aspx");
        }

        private void insereParticipantes(int codAti)
        {
            ParticipanteEntity participante = new ParticipanteEntity();
            ParticipanteController participanteController = new ParticipanteController();

            participante.codAti = codAti;
            participante.cpfUsu = Session["cpfUsu"].ToString();
            participanteController.Inserir(participante);

            for (int i = 0; i < lstParticipantes.Items.Count; i++)
            {
                if (lstParticipantes.Items[i].Selected)
                {
                    participante.cpfUsu = lstParticipantes.Items[i].Value;
                    participanteController.Inserir(participante);
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            AtividadeEntity atividade = new AtividadeEntity();
            AtividadeController atividadeController = new AtividadeController();
            ParticipanteController participanteController = new ParticipanteController();

            if (txtCliente.SelectedValue == "0" || txtDescricao.Text == "" || txtTipo.Text == "" || txtData.Text == "" || txtHora.Text == "")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                atividade.codCli = Convert.ToInt32(txtCliente.SelectedValue);
                atividade.desAti = txtDescricao.Text;
                atividade.tipAti = txtTipo.Text;
                atividade.datAti = txtData.Text;
                atividade.horAti = txtHora.Text;

                if (Request.QueryString["codAti"] != null)
                {
                    if (atividadeController.Atualizar(atividade))
                    {
                        participanteController.Remover(Convert.ToInt32(Request.QueryString["codAti"].ToString()));
                        insereParticipantes(Convert.ToInt32(Request.QueryString["codAti"].ToString()));

                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Atividade alterada com sucesso!'); window.location.href='Atividade.aspx';</script>");
                    }
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
                else
                {
                    if (atividadeController.Inserir(atividade))
                    {
                        insereParticipantes(atividadeController.ObterUltimo().codAti);

                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Atividade salva com sucesso!'); window.location.href='Atividade.aspx';</script>");
                    }
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na inclusão do registro!');</script>");
                }
            }
        }
    }
}