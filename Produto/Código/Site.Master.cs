using System;
using System.Configuration;
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

            if (Session["cpfUsu"] == null)
                Response.Redirect("~/Login.aspx");
            else
            {
                lblLogin.Text = Session["nomUsu"].ToString();
                if (Session["nomCar"] == null)
                {
                    NavigationMenu.Items.RemoveAt(5);
                    NavigationMenu.Items.RemoveAt(4);
                    NavigationMenu.Items.RemoveAt(2);
                    lblTipo.Text = "Desempregado";
                }
                else if (Session["nomCar"].ToString() == "Funcionário")
                {
                    NavigationMenu.Items.RemoveAt(5);
                    NavigationMenu.Items.RemoveAt(3);
                    lblTipo.Text = "Funcionário";
                }
                else if (Session["nomCar"].ToString() == "Administrador")
                {
                    NavigationMenu.Items.RemoveAt(3);
                    lblTipo.Text = "Administrador";
                }
                else if (Session["nomCar"].ToString() == "Proprietário")
                {
                    lblTipo.Text = "Proprietário";
                }
            }
        }
    }
}