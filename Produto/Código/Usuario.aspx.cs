using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Usuario : System.Web.UI.Page
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
            List<UsuarioEntity> lista = new List<UsuarioEntity>();
            lista.Add(usuarioController.Obter(Session["cpf"].ToString()));
            this.UsuarioGridView.DataSource = lista;
            this.UsuarioGridView.DataBind();
        }

        protected void UsuarioGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cpfUsu = UsuarioGridView.DataKeys[e.RowIndex].Value.ToString();
            UsuarioController usuarioController = new UsuarioController();
            if (usuarioController.Remover(cpfUsu))
            {
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Usuario excluído com sucesso!');</script>");
                Session.Clear();
                Response.Redirect("~/Index.aspx");
            }
            else
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na exclusão do registro!');</script>");
        }

        protected void UsuarioGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Referência ao linkbutton edit
                ImageButton editButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 2].Controls[0];
                UsuarioEntity usuario = (UsuarioEntity)e.Row.DataItem;
                editButton.OnClientClick = "window.location.href='UsuarioForm.aspx?cpfUsu=" + usuario.cpfUsu + "';";

                //Referência ao linkbutton delete
                ImageButton deleteButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro?')) return false;";
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioForm.aspx");
        }
    }
}