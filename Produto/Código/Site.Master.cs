using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRMOnline
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("caminhoDll", HttpContext.Current.Server.MapPath(@"CRMOnlineDAO\bin\Debug\CRMOnlineDAO.dll"));

            if (Session["cpf"] == null)
                Response.Redirect("~/Index.aspx");
            else
            {
                lblLogin.Text = Session["nome"].ToString();
                if (Session["cargo"] == null)
                {
                    NavigationMenu.Items.RemoveAt(5);
                    NavigationMenu.Items.RemoveAt(3);
                    NavigationMenu.Items.RemoveAt(2);
                    lblTipo.Text = "Desempregado";
                }
                else if (Session["cargo"].ToString() == "Funcionário")
                {
                    NavigationMenu.Items.RemoveAt(5);
                    NavigationMenu.Items.RemoveAt(4);
                    lblTipo.Text = "Funcionário";
                }
                else if (Session["cargo"].ToString() == "Administrador")
                {
                    NavigationMenu.Items.RemoveAt(4);
                    lblTipo.Text = "Administrador";
                }
                else if (Session["cargo"].ToString() == "Proprietário")
                {
                    NavigationMenu.Items.RemoveAt(6);
                    lblTipo.Text = "Proprietário";
                }
            }
        }
    }
}