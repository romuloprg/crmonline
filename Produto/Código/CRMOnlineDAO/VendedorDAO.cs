using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class VendedorDAO : IVendedorDAO
    {
        private SqlConnection connection;

        public VendedorDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(VendedorEntity vendedor)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Vendedor VALUES (@cpfUsu, (SELECT codCli FROM Cliente WHERE cnpjEmp = @cnpjEmp AND cnpjCli = @cnpjCli))", connection);
                command.Parameters.AddWithValue("@cpfUsu", vendedor.cpfUsu);
                command.Parameters.AddWithValue("@cnpjEmp", vendedor.cnpjEmp);
                command.Parameters.AddWithValue("@cnpjCli", vendedor.cnpjCli);
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

        public bool Atualizar(VendedorEntity vendedor)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Vendedor SET cpfUsu = @cpfUsu WHERE codCli = (SELECT codCli FROM Cliente WHERE cnpjEmp = @cnpjEmp AND cnpjCli = @cnpjCli)", connection);
                command.Parameters.AddWithValue("@cpfUsu", vendedor.cpfUsu);
                command.Parameters.AddWithValue("@cnpjEmp", vendedor.cnpjEmp);
                command.Parameters.AddWithValue("@cnpjCli", vendedor.cnpjCli);
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
                SqlCommand command = new SqlCommand("DELETE FROM Vendedor WHERE codCli = @codCli", connection);
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

        public List<VendedorEntity> ObterTodos(string cpfUsu)
        {
            List<VendedorEntity> vendedores = new List<VendedorEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codVen, Vendedor.cpfUsu, Vendedor.codCli, nomUsu, cnpjEmp, cnpjCli FROM Vendedor LEFT JOIN Cliente ON Vendedor.codCli = Cliente.codCli LEFT JOIN Usuario ON Vendedor.cpfUsu = Usuario.cpfUsu WHERE Vendedor.cpfUsu = @cpfUsu ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    VendedorEntity vendedor = new VendedorEntity();

                    vendedor.codVen = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    vendedor.cpfUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                    vendedor.codCli = ExtraDAO.ObterValor<int>(reader, 2, 0);
                    vendedor.nomUsu = ExtraDAO.ObterValor<string>(reader, 3, null);
                    vendedor.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                    vendedor.cnpjCli = ExtraDAO.ObterValor<string>(reader, 5, null);

                    vendedores.Add(vendedor);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return vendedores;
        }
    }
}
