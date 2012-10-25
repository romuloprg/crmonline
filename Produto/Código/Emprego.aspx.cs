using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Emprego : System.Web.UI.Page
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
            this.EmpregoGridView.DataSource = usuarioController.BuscarContrato(Session["cpf"].ToString());
            this.EmpregoGridView.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmpregoForm.aspx");
        }
    }
}