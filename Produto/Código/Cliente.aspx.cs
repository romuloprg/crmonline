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
            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            ClienteController clienteController = new ClienteController();
            this.ClienteGridView.DataSource = clienteController.ObterTodos(Session["cnpjEmp"].ToString());
            this.ClienteGridView.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ClienteForm.aspx");
        }

        protected void ClienteGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codCli = Convert.ToInt32(ClienteGridView.DataKeys[e.RowIndex].Value.ToString());
            VendedorController vendedorController = new VendedorController();
            vendedorController.Remover(codCli);
            ClienteController clienteController = new ClienteController();
            if (clienteController.Remover(codCli))
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Cliente removido com sucesso!');</script>");
            else
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na remoção do registro!');</script>");
            PreencheGrid();
        }

        protected void ClienteGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton deleteButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro?')) return false;";
            }
        }

        protected void txtBusca_TextChanged(object sender, EventArgs e)
        {
            ClienteController clienteController = new ClienteController();
            this.ClienteGridView.DataSource = clienteController.Buscar(Session["cnpjEmp"].ToString(), txtBusca.Text);
            this.ClienteGridView.DataBind();
        }
    }
}