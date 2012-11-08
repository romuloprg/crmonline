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
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Cliente VALUES (@cnpjEmp, @cnpjCli)", connection);
                command.Parameters.AddWithValue("@cnpjEmp", cliente.cnpjEmp);
                command.Parameters.AddWithValue("@cnpjCli", cliente.cnpjCli);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return true;
        }

        public bool Remover(int codCli)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Cliente WHERE codCli = @codCli", connection);
                command.Parameters.AddWithValue("@codCli", codCli);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return true;
        }

        public ClienteEntity Obter(int codCli)
        {
            ClienteEntity cliente = new ClienteEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Cliente.codCli, Cliente.cnpjEmp, Cliente.cnpjCli, nomEmp, nomCli, codVen, Vendedor.cpfUsu AS cpfVen, nomUsu AS nomVen FROM Cliente LEFT JOIN (SELECT DISTINCT cnpjEmp, nomEmp FROM Empresa) AS Empresa1 ON Empresa1.cnpjEmp = Cliente.cnpjEmp LEFT JOIN (SELECT DISTINCT cnpjEmp AS cnpjCli, nomEmp AS nomCli FROM Empresa) AS Empresa2 ON Empresa2.cnpjCli = Cliente.cnpjCli LEFT JOIN Vendedor ON Vendedor.codCli = Cliente.codCli LEFT JOIN Usuario ON Usuario.cpfUsu = Vendedor.cpfUsu WHERE Cliente.codCli = @codCli ORDER BY nomCli", connection);
                command.Parameters.AddWithValue("@codCli", codCli);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                cliente.codCli = ExtraDAO.ObterValor<int>(reader, 0, 0);
                cliente.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 1, null);
                cliente.cnpjCli = ExtraDAO.ObterValor<string>(reader, 2, null);
                cliente.nomEmp = ExtraDAO.ObterValor<string>(reader, 3, null);
                cliente.nomCli = ExtraDAO.ObterValor<string>(reader, 4, null);
                cliente.codVen = ExtraDAO.ObterValor<int>(reader, 5, 0);
                cliente.cpfVen = ExtraDAO.ObterValor<string>(reader, 6, null);
                cliente.nomVen = ExtraDAO.ObterValor<string>(reader, 7, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return cliente;
        }

        public List<ClienteEntity> ObterTodos(string cnpjEmp)
        {
            List<ClienteEntity> clientes = new List<ClienteEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Cliente.codCli, Cliente.cnpjEmp, Cliente.cnpjCli, nomEmp, nomCli, codVen, Vendedor.cpfUsu AS cpfVen, nomUsu AS nomVen FROM Cliente LEFT JOIN (SELECT DISTINCT cnpjEmp, nomEmp FROM Empresa) AS Empresa1 ON Empresa1.cnpjEmp = Cliente.cnpjEmp LEFT JOIN (SELECT DISTINCT cnpjEmp AS cnpjCli, nomEmp AS nomCli FROM Empresa) AS Empresa2 ON Empresa2.cnpjCli = Cliente.cnpjCli LEFT JOIN Vendedor ON Vendedor.codCli = Cliente.codCli LEFT JOIN Usuario ON Usuario.cpfUsu = Vendedor.cpfUsu WHERE Cliente.cnpjEmp = @cnpjEmp ORDER BY nomCli", connection);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClienteEntity cliente = new ClienteEntity();

                    cliente.codCli = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    cliente.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 1, null);
                    cliente.cnpjCli = ExtraDAO.ObterValor<string>(reader, 2, null);
                    cliente.nomEmp = ExtraDAO.ObterValor<string>(reader, 3, null);
                    cliente.nomCli = ExtraDAO.ObterValor<string>(reader, 4, null);
                    cliente.codVen = ExtraDAO.ObterValor<int>(reader, 5, 0);
                    cliente.cpfVen = ExtraDAO.ObterValor<string>(reader, 6, null);
                    cliente.nomVen = ExtraDAO.ObterValor<string>(reader, 7, null);

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

        public List<ClienteEntity> Buscar(string cnpjEmp, string busca)
        {
            List<ClienteEntity> clientes = new List<ClienteEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Cliente.codCli, Cliente.cnpjEmp, Cliente.cnpjCli, nomEmp, nomCli, codVen, Vendedor.cpfUsu AS cpfVen, nomUsu AS nomVen FROM Cliente LEFT JOIN (SELECT DISTINCT cnpjEmp, nomEmp FROM Empresa) AS Empresa1 ON Empresa1.cnpjEmp = Cliente.cnpjEmp LEFT JOIN (SELECT DISTINCT cnpjEmp AS cnpjCli, nomEmp AS nomCli FROM Empresa) AS Empresa2 ON Empresa2.cnpjCli = Cliente.cnpjCli LEFT JOIN Vendedor ON Vendedor.codCli = Cliente.codCli LEFT JOIN Usuario ON Usuario.cpfUsu = Vendedor.cpfUsu WHERE Cliente.cnpjEmp = @cnpjEmp AND nomCli LIKE CONCAT('%', @busca, '%') ORDER BY nomCli", connection);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                command.Parameters.AddWithValue("@busca", busca);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClienteEntity cliente = new ClienteEntity();

                    cliente.codCli = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    cliente.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 1, null);
                    cliente.cnpjCli = ExtraDAO.ObterValor<string>(reader, 2, null);
                    cliente.nomEmp = ExtraDAO.ObterValor<string>(reader, 3, null);
                    cliente.nomCli = ExtraDAO.ObterValor<string>(reader, 4, null);
                    cliente.codVen = ExtraDAO.ObterValor<int>(reader, 5, 0);
                    cliente.cpfVen = ExtraDAO.ObterValor<string>(reader, 6, null);
                    cliente.nomVen = ExtraDAO.ObterValor<string>(reader, 7, null);

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
