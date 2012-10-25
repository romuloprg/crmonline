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
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            AtividadeController atividadeController = new AtividadeController();
            this.AtividadeGridView.DataSource = atividadeController.ObterTodos();
            this.AtividadeGridView.DataBind();
        }

        protected void AtividadeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codAti = Convert.ToInt32(AtividadeGridView.DataKeys[e.RowIndex].Value.ToString());
            AtividadeController atividadeController = new AtividadeController();
            if (atividadeController.Remover(codAti))
            {
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Atividade excluída com sucesso!');</script>");
                PreencheGrid();
            }
            else
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na exclusão do registro!');</script>");
        }

        protected void AtividadeGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Referência ao linkbutton edit
                ImageButton editButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 2].Controls[0];
                AtividadeEntity Atividade = (AtividadeEntity)e.Row.DataItem;
                editButton.OnClientClick = "window.location.href='AtividadeForm.aspx?codAti=" + Atividade.codAti + "';";

                //Referência ao linkbutton delete
                ImageButton deleteButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro?')) return false;";
            }
        }

        protected void txtBusca_TextChanged(object sender, EventArgs e)
        {
            AtividadeController atividadeController = new AtividadeController();
            this.AtividadeGridView.DataSource = atividadeController.Buscar(txtBusca.Text);
            this.AtividadeGridView.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AtividadeForm.aspx");
        }
    }
}