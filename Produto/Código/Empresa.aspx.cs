using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRMOnlineController;
using CRMOnlineEntity;

namespace CRMOnline
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa apenas na primeira carga da página
            if (!Page.IsPostBack)
                PreencheGrid();
        }

        private void PreencheGrid()
        {
            EmpresaController empresaController = new EmpresaController();
            this.EmpresaGridView.DataSource = empresaController.Buscar(Session["cpf"].ToString());
            this.EmpresaGridView.DataBind();
        }

        protected void EmpresaGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cnpjEmp = EmpresaGridView.DataKeys[e.RowIndex].Value.ToString();
            EmpresaController empresaController = new EmpresaController();
            if (empresaController.Remover(cnpjEmp))
            {
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Empresa excluída com sucesso!');</script>");
                PreencheGrid();
            }
            else
                this.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('Erro na exclusão do registro!');</script>");
        }

        protected void EmpresaGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Referência ao linkbutton edit
                ImageButton editButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 2].Controls[0];
                EmpresaEntity Empresa = (EmpresaEntity)e.Row.DataItem;
                editButton.OnClientClick = "window.location.href='EmpresaForm.aspx?cnpjEmp=" + Empresa.cnpjEmp + "';";

                //Referência ao linkbutton delete
                ImageButton deleteButton = (ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro?')) return false;";
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmpresaForm.aspx");
        }
    }
}