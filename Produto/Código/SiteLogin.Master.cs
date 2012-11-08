using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CRMOnlineEntity;
using CRMOnlineDAO;

namespace CRMOnline
{
    public partial class SiteLogin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("caminhoDll", HttpContext.Current.Server.MapPath(@"CRMOnlineDAO\bin\Debug\CRMOnlineDAO.dll"));
        }
    }
}