using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Funcionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            UsuarioController usuarioController = new UsuarioController();
            this.FuncionarioGridView.DataSource = usuarioController.ObterFuncionarios(Session["cpfUsu"].ToString());
            this.FuncionarioGridView.DataBind();
        }

        protected void txtBusca_TextChanged(object sender, EventArgs e)
        {
            UsuarioController usuarioController = new UsuarioController();
            this.FuncionarioGridView.DataSource = usuarioController.BuscarFuncionarios(Session["cpfUsu"].ToString(), txtBusca.Text);
            this.FuncionarioGridView.DataBind();
        }
    }
}