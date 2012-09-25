using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CRMOnline
{
    public partial class Cliente : System.Web.UI.Page
    {
        string strConexao = null;   

        protected void Page_Load(object sender, EventArgs e)
        {
            //strConexao = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|CRMOnlineDB.mdf;Integrated Security=True;User Instance=True";
            strConexao = @"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True";

            //chama apenas na primeira carga da pagina
            if (!Page.IsPostBack)
            {
                preencheGrid();
            }
        }

        public void preencheGrid()
        {
            //cria uma conexão usando a string de conexão definida
            SqlConnection con = new SqlConnection(strConexao);
            //abre a conexão
            con.Open();
            //define um objeto Command que usa a stored procedure na conexão criada
            SqlCommand cmd = new SqlCommand("sproc_BuscaClientes", con);
            //realizar um acesso somente-leitura no banco de dados
            SqlDataReader dr = cmd.ExecuteReader();
            //cria um datatable que conterá os dados
            DataTable dt = new DataTable();
            //carrega o datatable com os dados do datareader
            dt.Load(dr);
            //exibe os dados no GridView
            ClienteGridView.DataSource = dt;
            ClienteGridView.DataBind();
        }

        protected void ClienteGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClienteGridView.EditIndex = -1;
            preencheGrid();
        }

        protected void ClienteGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClienteGridView.EditIndex = e.NewEditIndex;
            preencheGrid();
        }

        protected void ClienteGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codCli = Convert.ToInt32(ClienteGridView.DataKeys[e.RowIndex].Value.ToString());
            SqlConnection con = new SqlConnection(strConexao);
            con.Open();
            SqlCommand cmd = new SqlCommand("sproc_DeletaCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codCli ", codCli);
            cmd.ExecuteNonQuery();
            preencheGrid();
        }

        protected void ClienteGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Obtem cada valor único do DataKeyNames
            int codCli = Convert.ToInt32(ClienteGridView.DataKeys[e.RowIndex].Value.ToString());
            //Obtem o valor do TextBox no EditItemTemplet da linha clicada
            string nomCli = ((TextBox)ClienteGridView.Rows[e.RowIndex].FindControl("txtNome")).Text;
            string endCli = ((TextBox)ClienteGridView.Rows[e.RowIndex].FindControl("txtEndereco")).Text;
            string cidCli = ((TextBox)ClienteGridView.Rows[e.RowIndex].FindControl("txtCidade")).Text;
            string ufCli = ((TextBox)ClienteGridView.Rows[e.RowIndex].FindControl("txtUf")).Text;
            //abre a conexão
            SqlConnection con = new SqlConnection(strConexao);
            con.Open();
            //Utiliza a stored procedure sproc_AtualizaCliente na conexão
            SqlCommand cmd = new SqlCommand("sproc_AtualizaCliente", con);
            //define o tipo de comando 
            cmd.CommandType = CommandType.StoredProcedure;
            //passa os parâmetros para a stored procedure
            cmd.Parameters.AddWithValue("@codCli ", codCli);
            cmd.Parameters.AddWithValue("@nomCli ", nomCli);
            cmd.Parameters.AddWithValue("@endCli ", endCli);
            cmd.Parameters.AddWithValue("@cidCli ", cidCli);
            cmd.Parameters.AddWithValue("@ufCli ", ufCli);
            //Método que retorna as linhas afetadas
            cmd.ExecuteNonQuery();
            //nenhuma linha no modo de edição
            ClienteGridView.EditIndex = -1;
            //preenche o grid nomvanete
            preencheGrid();
        }

        protected void ClienteGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) | e.Row.RowState == DataControlRowState.Edit)
            {
                return;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Referencia ao linkbutton delete
                ImageButton deleteButton = (ImageButton)e.Row.Cells[6].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro ?')) return false;";
            }
        }
    }
}