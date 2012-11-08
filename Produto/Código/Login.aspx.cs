using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Login : System.Web.UI.Page
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
                UsuarioEntity usuario = usuarioController.Validar(txtUsuario.Text, txtSenha.Text);

                if (usuario.nomUsu != null)
                {
                    Session["cpfUsu"] = usuario.cpfUsu;
                    Session["nomUsu"] = usuario.nomUsu;
                    Session["codCar"] = usuario.codCar;
                    Session["nomCar"] = usuario.nomCar;
                    Session["cnpjEmp"] = usuario.cnpjEmp;
                    Session["nomEmp"] = usuario.nomEmp;

                    Response.Write(Session["cpfUsu"]);
                    Response.Write(Session["nomUsu"]);
                    Response.Write(Session["codCar"]);
                    Response.Write(Session["nomCar"]);
                    Response.Write(Session["cnpjEmp"]);
                    Response.Write(Session["nomEmp"]);

                    Response.Redirect("~/Home.aspx");
                }
                else
                    this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Usuário ou senha inválidos!');</script>");
            }
        }
    }
}