using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class ClienteDAO : IClienteDAO
    {
        private SqlConnection connection;

        public ClienteDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(ClienteEntity cliente)
        {
            //TODO: Código para inserir cliente
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("cliente_Inserir", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nomCli", cliente.nomCli);
                command.Parameters.AddWithValue("@endCli", cliente.endCli);
                command.Parameters.AddWithValue("@cidCli", cliente.cidCli);
                command.Parameters.AddWithValue("@ufCli", cliente.ufCli);
                command.Parameters.AddWithValue("@cnpjEmp", cliente.cnpjEmp);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(ClienteEntity cliente)
        {
            //TODO: Código para atualizar cliente
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("cliente_Atualizar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codCli", cliente.codCli);
                command.Parameters.AddWithValue("@nomCli", cliente.nomCli);
                command.Parameters.AddWithValue("@endCli", cliente.endCli);
                command.Parameters.AddWithValue("@cidCli", cliente.cidCli);
                command.Parameters.AddWithValue("@ufCli", cliente.ufCli);
                command.Parameters.AddWithValue("@cnpjEmp", cliente.cnpjEmp);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Remover(int codCli)
        {
            //TODO: código para remover cliente
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("cliente_Remover", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codCli", codCli);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private T ObterValor<T>(IDataReader reader, int indice, T valorDefault)
        {
            try
            {
                //TODO: código para selecionar valores dos registros
                if (!reader.IsDBNull(indice))
                    return (T)reader.GetValue(indice);
                else
                    return valorDefault;
            }
            catch
            {
                return valorDefault;
            }
        }

        public List<ClienteEntity> ObterTodos()
        {
            //TODO: código para selecionar todos os clientes
            List<ClienteEntity> clientes = new List<ClienteEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("cliente_ObterTodos", connection);
                command.CommandType = CommandType.StoredProcedure;
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClienteEntity cliente = new ClienteEntity();

                    object valor = reader.GetValue(0);

                    cliente.codCli = this.ObterValor<int>(reader, 0, 0);
                    cliente.nomCli = this.ObterValor<string>(reader, 1, null);
                    cliente.endCli = this.ObterValor<string>(reader, 2, null);
                    cliente.cidCli = this.ObterValor<string>(reader, 3, null);
                    cliente.ufCli = this.ObterValor<string>(reader, 4, null);
                    cliente.cnpjEmp = this.ObterValor<string>(reader, 5, null);
                    cliente.nomEmp = this.ObterValor<string>(reader, 6, null);

                    clientes.Add(cliente);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return clientes;
        }

        public ClienteEntity Obter(int codCli)
        {
            //TODO: código para selecionar um cliente pelo código
            ClienteEntity cliente = new ClienteEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("cliente_Obter", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codCli", codCli);
                IDataReader reader = command.ExecuteReader();

                reader.Read();
                object valor = reader.GetValue(0);

                cliente.codCli = this.ObterValor<int>(reader, 0, 0);
                cliente.nomCli = this.ObterValor<string>(reader, 1, null);
                cliente.endCli = this.ObterValor<string>(reader, 2, null);
                cliente.cidCli = this.ObterValor<string>(reader, 3, null);
                cliente.ufCli = this.ObterValor<string>(reader, 4, null);
                cliente.cnpjEmp = this.ObterValor<string>(reader, 5, null);
                cliente.nomEmp = this.ObterValor<string>(reader, 6, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return cliente;
        }

        public List<ClienteEntity> Buscar(string busca)
        {
            //TODO: código para selecionar clientes
            List<ClienteEntity> clientes = new List<ClienteEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("cliente_Buscar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@busca", busca);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClienteEntity cliente = new ClienteEntity();

                    object valor = reader.GetValue(0);

                    cliente.codCli = this.ObterValor<int>(reader, 0, 0);
                    cliente.nomCli = this.ObterValor<string>(reader, 1, null);
                    cliente.endCli = this.ObterValor<string>(reader, 2, null);
                    cliente.cidCli = this.ObterValor<string>(reader, 3, null);
                    cliente.ufCli = this.ObterValor<string>(reader, 4, null);
                    cliente.cnpjEmp = this.ObterValor<string>(reader, 5, null);
                    cliente.nomEmp = this.ObterValor<string>(reader, 6, null);

                    clientes.Add(cliente);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return clientes;
        }
    }
}