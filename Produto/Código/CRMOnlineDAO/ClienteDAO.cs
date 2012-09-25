using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMOnlineIDAO;
using CRMOnlineEntity;
using System.Data;
using System.Data.SqlClient;

namespace CRMOnlineDAO
{
    public class ClienteDAO : IClienteDAO
    {
        private SqlConnection connection;

        public ClienteDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public void Inserir(ClienteEntity cliente)
        {
            //TODO: Código para inserir no banco de dados
            connection.Open();
            SqlCommand command = new SqlCommand("sproc_InsereCliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@codCli", cliente.codCliente));
            command.Parameters.Add(new SqlParameter("@nomCli", cliente.nomeCliente));
            command.Parameters.Add(new SqlParameter("@endCli", cliente.enderecoCliente));
            command.Parameters.Add(new SqlParameter("@cidCli", cliente.cidadeCliente));
            command.Parameters.Add(new SqlParameter("@ufCli", cliente.ufCliente));
            command.Parameters.Add(new SqlParameter("@cnpjEmp", cliente.cnpjEmpresa));
            command.ExecuteNonQuery();
        }

        public void Atualizar(ClienteEntity cliente)
        {
            //TODO: código para atualizar cliente
            connection.Open();
            SqlCommand command = new SqlCommand("sproc_AtualizaCliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@codCli", cliente.codCliente));
            command.Parameters.Add(new SqlParameter("@nomCli", cliente.nomeCliente));
            command.Parameters.Add(new SqlParameter("@endCli", cliente.enderecoCliente));
            command.Parameters.Add(new SqlParameter("@cidCli", cliente.cidadeCliente));
            command.Parameters.Add(new SqlParameter("@ufCli", cliente.ufCliente));
            command.Parameters.Add(new SqlParameter("@cnpjEmp", cliente.cnpjEmpresa));
            command.ExecuteNonQuery();
        }

        public ClienteEntity ObterCliente(int id)
        {
            //TODO: código para selecionar um cliente pelo id
            return null;
        }

        public T ObterValor<T>(IDataReader reader, int indice, T valorDefault)
        {
            if (!reader.IsDBNull(indice))
            {
                return (T)reader.GetValue(indice);
            }
            return valorDefault;
        }

        public List<ClienteEntity> ObterTodos()
        {
            List<ClienteEntity> clientes = new List<ClienteEntity>();
            try
            {
                //Colocar a string de conexão em um arquivo de configuração
                connection.Open();
                SqlCommand command = new SqlCommand("sproc_BuscaTodosCliente", connection);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClienteEntity cliente = new ClienteEntity();

                    object valor = reader.GetValue(0);

                    cliente.nomeCliente = this.ObterValor<string>(reader, 0, null);
                    cliente.enderecoCliente = this.ObterValor<string>(reader, 1, null);
                    cliente.cidadeCliente = this.ObterValor<string>(reader, 2, null);
                    cliente.ufCliente = this.ObterValor<string>(reader, 3, null);
                    cliente.cnpjEmpresa = this.ObterValor<string>(reader, 4, null);

                    clientes.Add(cliente);
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return clientes;
        }

        public void Remover(int id)
        {
            //TODO: código para atualizar cliente
            connection.Open();
            SqlCommand command = new SqlCommand("sproc_DeletaCliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@codCli", id));
            command.ExecuteNonQuery();
        }
    }
}