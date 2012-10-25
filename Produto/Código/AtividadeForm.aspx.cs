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
    public partial class AtividadeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
            {
                try
                {
                    int codAti = Convert.ToInt32(Request.QueryString["codAti"]);
                    preencheCampos(codAti);
                    txtDescricao.Focus();
                }
                catch
                { }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            // Cria a instância
            AtividadeEntity atividade = new AtividadeEntity();
            AtividadeController atividadeController = new AtividadeController();

            if (txtDescricao.Text == "" || txtTipo.Text == "" || txtData.Text == "" || txtHora.Text == "")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                atividade.desAti = txtDescricao.Text;
                atividade.tipAti = txtTipo.Text;
                atividade.datAti = txtData.Text; // data está como string
                atividade.horAti = txtHora.Text; // hora esta como string
                atividade.durAti = Convert.ToInt32(txtDuracao.Text);// converte para inteiro

                int codAti = 0;

                try
                {
                    codAti = Convert.ToInt32(Request.QueryString["codAti"]);
                }
                catch
                { }

                // Chama método
                if (codAti != 0)
                {
                    atividade.codAti = codAti;
                    if (atividadeController.Atualizar(atividade))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Atividade alterada com sucesso!'); window.location.href='Atividade.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na alteração do registro!');</script>");
                }
                else
                {
                    if (atividadeController.Inserir(atividade))
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Atividade salva com sucesso!'); window.location.href='Atividade.aspx';</script>");
                    else
                        this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na inclusão do registro!');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Atividade.aspx");
        }

        private void preencheCampos(int codAti)
        {
            AtividadeController atividadeController = new AtividadeController();
            AtividadeEntity atividade = atividadeController.Obter(codAti);
            txtDescricao.Text = atividade.desAti;
            txtTipo.Text = atividade.tipAti;
            txtData.Text = atividade.datAti; // data está como string
            txtHora.Text = atividade.horAti; // hora esta como string
            txtDuracao.Text = atividade.durAti.ToString();
        }
    }
}