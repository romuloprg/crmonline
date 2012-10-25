using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Permissao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            UsuarioController usuarioController = new UsuarioController();
            this.PermissaoGridView.DataSource = usuarioController.Buscar(Session["cpf"].ToString());
            this.PermissaoGridView.DataBind();
        }

        protected void PermissaoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Referência ao linkbutton edit
                ImageButton editButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
                UsuarioEntity usuario = (UsuarioEntity)e.Row.DataItem;
                editButton.OnClientClick = "window.location.href='PermissaoForm.aspx?cpfUsu=" + usuario.cpfUsu + "';";
            }
        }
    }
}