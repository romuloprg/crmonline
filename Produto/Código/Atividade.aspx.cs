using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Atividade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            AtividadeController atividadeController = new AtividadeController();
            this.AtividadeGridView.DataSource = atividadeController.ObterTodos(Session["cpfUsu"].ToString());
            this.AtividadeGridView.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AtividadeForm.aspx");
        }

        protected void AtividadeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codAti = Convert.ToInt32(AtividadeGridView.DataKeys[e.RowIndex].Value.ToString());
            ParticipanteController participanteController = new ParticipanteController();
            if (participanteController.Remover(codAti))
            {
                AtividadeController atividadeController = new AtividadeController();
                if (atividadeController.Remover(codAti))
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Atividade removida com sucesso!');</script>");
            }
            else
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na remoção do registro, existem lembretes pendentes!');</script>");
            PreencheGrid();
        }

        protected void AtividadeGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton deleteButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro?')) return false;";
            }
        }

        protected void txtBusca_TextChanged(object sender, EventArgs e)
        {
            AtividadeController atividadeController = new AtividadeController();
            this.AtividadeGridView.DataSource = atividadeController.Buscar(Session["cpfUsu"].ToString(), txtBusca.Text);
            this.AtividadeGridView.DataBind();
        }
    }
}