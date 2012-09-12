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
        public void Inserir(Cliente cliente)
        {
            //TODO: Código para inserir no banco de dados

            IDbConnection connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=CRMOnlineDB;Integrated Security=True");
            IDbCommand command = connection.CreateCommand();

            command.CommandText = "INSERT INTO Cliente(nomCli, endCli, cidCli, ufCli, codEmp) Values(@Nome, @Endereco, @Cidade, @UF, @CodEmpresa)";
            command.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
            command.Parameters.Add(new SqlParameter("@Email", cliente.Endereco));
            command.Parameters.Add(new SqlParameter("@Cidade", cliente.Cidade));
            command.Parameters.Add(new SqlParameter("@UF", cliente.UF));
            command.Parameters.Add(new SqlParameter("@CodEmpresa", cliente.CodEmpresa));
            command.ExecuteNonQuery();
        }


        public void Atualizar(Cliente cliente)
        {
            //TODO: código para atualizar cliente
        }

        public Cliente ObterCliente(int id)
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

        public List<Cliente> ObterTodos()
        {
            IDbConnection connection = null;
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                //Colocar a string de conexão em um arquivo de configuração
                connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=CRMOnlineDB;Integrated Security=True");
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "Select Nome, Email from Cliente";
                connection.Open();
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    object valor = reader.GetValue(0);

                    cliente.Nome = this.ObterValor<string>(reader, 0, null);
                    cliente.Endereco = this.ObterValor<string>(reader, 1, null);
                    cliente.Cidade = this.ObterValor<string>(reader, 2, null);
                    cliente.UF = this.ObterValor<string>(reader, 3, null);
                    cliente.CodEmpresa = this.ObterValor<string>(reader, 4, null);

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
    }
}