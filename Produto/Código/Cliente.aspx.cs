using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            ClienteController clienteController = new ClienteController();
            this.ClienteGridView.DataSource = clienteController.ObterTodos();
            this.ClienteGridView.DataBind();
        }

        protected void ClienteGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codCli = Convert.ToInt32(ClienteGridView.DataKeys[e.RowIndex].Value.ToString());
            ClienteController clienteController = new ClienteController();
            if (clienteController.Remover(codCli))
            {
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Cliente excluído com sucesso!');</script>");
                PreencheGrid();
            }
            else
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na exclusão do registro!');</script>");
        }

        protected void ClienteGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Referência ao linkbutton edit
                ImageButton editButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 2].Controls[0];
                ClienteEntity cliente = (ClienteEntity)e.Row.DataItem;
                editButton.OnClientClick = "window.location.href='ClienteForm.aspx?codCli=" + cliente.codCli + "';";

                //Referência ao linkbutton delete
                ImageButton deleteButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro?')) return false;";
            }
        }

        protected void txtBusca_TextChanged(object sender, EventArgs e)
        {
            ClienteController clienteController = new ClienteController();
            this.ClienteGridView.DataSource = clienteController.Buscar(txtBusca.Text);
            this.ClienteGridView.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ClienteForm.aspx");
        }
    }
}