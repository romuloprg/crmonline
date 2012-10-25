using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;

namespace CRMOnline
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtSenha.Text == "")
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Preencha todos os campos!');</script>");
            else
            {
                UsuarioController usuarioController = new UsuarioController();
                List<string> lista = usuarioController.Validar(txtUsuario.Text, txtSenha.Text);

                if (lista[0] != null)
                {
                    Session["cpf"] = lista[0];
                    Session["nome"] = lista[1];
                    Session["cargo"] = lista[2];
                    
                    Response.Write(Session["cpf"]);
                    Response.Write(Session["nome"]);
                    Response.Write(Session["cargo"]);

                    Response.Redirect("~/Home.aspx");
                }
                else
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Usuário ou senha inválidos!');</script>");
            }
        }
    }
}