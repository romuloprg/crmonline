using System;
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
            if (Session["nomCar"] != null)
                if (Session["nomCar"].ToString() == "Proprietário")
                    panelButton.Visible = false;

            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            ContratoController contratoController = new ContratoController();
            this.EmpregoGridView.DataSource = contratoController.ObterTodos(Session["cpfUsu"].ToString());
            this.EmpregoGridView.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmpregoForm.aspx");
        }
    }
}