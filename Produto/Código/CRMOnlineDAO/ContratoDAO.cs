using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class ContratoDAO : IContratoDAO
    {
        private SqlConnection connection;

        public ContratoDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(ContratoEntity contrato)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Contrato VALUES (@cpfUsu, @cnpjEmp, @codCar, GETDATE(), NULL)", connection);
                command.Parameters.AddWithValue("@cpfUsu", contrato.cpfUsu);
                command.Parameters.AddWithValue("@cnpjEmp", contrato.cnpjEmp);
                command.Parameters.AddWithValue("@codCar", contrato.codCar);
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

        public bool Atualizar(ContratoEntity contrato)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Contrato SET codCar = @codCar WHERE cpfUsu = @cpfUsu AND cnpjEmp = @cnpjEmp", connection);
                command.Parameters.AddWithValue("@cpfUsu", contrato.cpfUsu);
                command.Parameters.AddWithValue("@cnpjEmp", contrato.cnpjEmp);
                command.Parameters.AddWithValue("@codCar", contrato.codCar);
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

        public bool Cancelar(string cpfUsu)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Contrato SET fimCtr = GETDATE() WHERE cpfUsu = @cpfUsu AND fimCtr IS NULL", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
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

        public bool Remover(string cpfUsu)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Contrato WHERE cpfUsu = @cpfUsu AND fimCtr IS NULL", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
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

        public bool RemoverTodos(string cpfUsu)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Contrato WHERE cpfUsu = @cpfUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
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

        public ContratoEntity ObterAtivo(string cpfUsu)
        {
            ContratoEntity contrato = new ContratoEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codCtr, Contrato.cpfUsu, Empresa.cnpjEmp, Contrato.codCar, iniCtr, fimCtr, nomUsu, nomEmp, nomCar FROM Contrato JOIN Cargo ON Contrato.codCar = Cargo.codCar JOIN Usuario ON Contrato.cpfUsu = Usuario.cpfUsu LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE Contrato.cpfUsu = @cpfUsu AND fimCtr IS NULL ORDER BY iniCtr", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                contrato.codCtr = ExtraDAO.ObterValor<int>(reader, 0, 0);
                contrato.cpfUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                contrato.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 2, null);
                contrato.codCar = ExtraDAO.ObterValor<int>(reader, 3, 0);
                contrato.iniCtr = ExtraDAO.ObterValor<DateTime>(reader, 4, new DateTime()).ToShortDateString();
                contrato.fimCtr = ExtraDAO.ObterValor<DateTime>(reader, 5, new DateTime()).ToShortDateString();
                contrato.nomUsu = ExtraDAO.ObterValor<string>(reader, 6, null);
                contrato.nomEmp = ExtraDAO.ObterValor<string>(reader, 7, null);
                contrato.nomCar = ExtraDAO.ObterValor<string>(reader, 8, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return contrato;
        }

        public List<ContratoEntity> ObterTodos(string cpfUsu)
        {
            List<ContratoEntity> contratos = new List<ContratoEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codCtr, Contrato.cpfUsu, Empresa.cnpjEmp, Contrato.codCar, iniCtr, fimCtr, nomUsu, nomEmp, nomCar FROM Contrato JOIN Cargo ON Contrato.codCar = Cargo.codCar JOIN Usuario ON Contrato.cpfUsu = Usuario.cpfUsu LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE Contrato.cpfUsu = @cpfUsu ORDER BY iniCtr", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ContratoEntity contrato = new ContratoEntity();

                    contrato.codCtr = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    contrato.cpfUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                    contrato.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 2, null);
                    contrato.codCar = ExtraDAO.ObterValor<int>(reader, 3, 0);
                    contrato.iniCtr = ExtraDAO.ObterValor<DateTime>(reader, 4, new DateTime()).ToShortDateString();
                    contrato.fimCtr = ExtraDAO.ObterValor<DateTime>(reader, 5, new DateTime()).ToShortDateString();
                    contrato.nomUsu = ExtraDAO.ObterValor<string>(reader, 6, null);
                    contrato.nomEmp = ExtraDAO.ObterValor<string>(reader, 7, null);
                    contrato.nomCar = ExtraDAO.ObterValor<string>(reader, 8, null);

                    contratos.Add(contrato);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return contratos;
        }
    }
}
