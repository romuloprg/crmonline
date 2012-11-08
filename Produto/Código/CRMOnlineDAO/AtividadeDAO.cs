using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class AtividadeDAO : IAtividadeDAO
    {
        private SqlConnection connection;

        public AtividadeDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(AtividadeEntity atividade)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Atividade VALUES (@codCli, @desAti, @tipAti, @datAti, @horAti)", connection);
                command.Parameters.AddWithValue("@codCli", atividade.codCli);
                command.Parameters.AddWithValue("@desAti", atividade.desAti);
                command.Parameters.AddWithValue("@tipAti", atividade.tipAti);
                command.Parameters.AddWithValue("@datAti", atividade.datAti);
                command.Parameters.AddWithValue("@horAti", atividade.horAti);
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

        public bool Atualizar(AtividadeEntity atividade)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Atividade SET desAti = @desAti, tipAti = @tipAti, datAti = @datAti, horAti = @horAti WHERE codAti = @codAti", connection);
                command.Parameters.AddWithValue("@codAti", atividade.codAti);
                command.Parameters.AddWithValue("@desAti", atividade.desAti);
                command.Parameters.AddWithValue("@tipAti", atividade.tipAti);
                command.Parameters.AddWithValue("@datAti", atividade.datAti);
                command.Parameters.AddWithValue("@horAti", atividade.horAti);
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

        public bool Remover(int codAti)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Atividade WHERE codAti = @codAti", connection);
                command.Parameters.AddWithValue("@codAti", codAti);
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

        public AtividadeEntity Obter(int codAti)
        {
            AtividadeEntity atividade = new AtividadeEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codAti, Atividade.codCli, desAti, tipAti, datAti, horAti, nomEmp AS nomCli FROM Atividade LEFT JOIN Cliente ON Atividade.codCli = Cliente.codCli LEFT JOIN Empresa ON Cliente.cnpjCli = Empresa.cnpjEmp WHERE Atividade.codAti = @codAti ORDER BY datAti", connection);
                command.Parameters.AddWithValue("@codAti", codAti);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                atividade.codAti = ExtraDAO.ObterValor<int>(reader, 0, 0);
                atividade.codCli = ExtraDAO.ObterValor<int>(reader, 1, 0);
                atividade.desAti = ExtraDAO.ObterValor<string>(reader, 2, null);
                atividade.tipAti = ExtraDAO.ObterValor<string>(reader, 3, null);
                atividade.datAti = ExtraDAO.ObterValor<DateTime>(reader, 4, new DateTime()).ToShortDateString();
                atividade.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 5, new TimeSpan()).ToString().Substring(0, 5);
                atividade.nomCli = ExtraDAO.ObterValor<string>(reader, 6, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return atividade;
        }

        public List<AtividadeEntity> ObterTodos(string cpfUsu)
        {
            List<AtividadeEntity> atividades = new List<AtividadeEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Atividade.codAti, Atividade.codCli, desAti, tipAti, datAti, horAti, nomEmp AS nomCli FROM Atividade LEFT JOIN Cliente ON Atividade.codCli = Cliente.codCli LEFT JOIN Empresa ON Cliente.cnpjCli = Empresa.cnpjEmp LEFT JOIN Participante ON Atividade.codAti = Participante.codAti WHERE cpfUsu = @cpfUsu ORDER BY datAti", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AtividadeEntity atividade = new AtividadeEntity();

                    atividade.codAti = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    atividade.codCli = ExtraDAO.ObterValor<int>(reader, 1, 0);
                    atividade.desAti = ExtraDAO.ObterValor<string>(reader, 2, null);
                    atividade.tipAti = ExtraDAO.ObterValor<string>(reader, 3, null);
                    atividade.datAti = ExtraDAO.ObterValor<DateTime>(reader, 4, new DateTime()).ToShortDateString();
                    atividade.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 5, new TimeSpan()).ToString().Substring(0, 5);
                    atividade.nomCli = ExtraDAO.ObterValor<string>(reader, 6, null);

                    atividades.Add(atividade);
                }
            }
            catch
            { }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return atividades;
        }

        public List<AtividadeEntity> Buscar(string cpfUsu, string busca)
        {
            List<AtividadeEntity> atividades = new List<AtividadeEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Atividade.codAti, Atividade.codCli, desAti, tipAti, datAti, horAti, nomEmp AS nomCli FROM Atividade LEFT JOIN Cliente ON Atividade.codCli = Cliente.codCli LEFT JOIN Empresa ON Cliente.cnpjCli = Empresa.cnpjEmp LEFT JOIN Participante ON Atividade.codAti = Participante.codAti WHERE cpfUsu = @cpfUsu AND (desAti LIKE CONCAT('%', @busca, '%') OR tipAti LIKE CONCAT('%', @busca, '%')) ORDER BY datAti", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                command.Parameters.AddWithValue("@busca", busca);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AtividadeEntity atividade = new AtividadeEntity();

                    atividade.codAti = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    atividade.codCli = ExtraDAO.ObterValor<int>(reader, 1, 0);
                    atividade.desAti = ExtraDAO.ObterValor<string>(reader, 2, null);
                    atividade.tipAti = ExtraDAO.ObterValor<string>(reader, 3, null);
                    atividade.datAti = ExtraDAO.ObterValor<DateTime>(reader, 4, new DateTime()).ToShortDateString();
                    atividade.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 5, new TimeSpan()).ToString().Substring(0, 5);
                    atividade.nomCli = ExtraDAO.ObterValor<string>(reader, 6, null);

                    atividades.Add(atividade);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return atividades;
        }

        public AtividadeEntity ObterUltimo()
        {
            AtividadeEntity atividade = new AtividadeEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codAti, Atividade.codCli, desAti, tipAti, datAti, horAti, nomEmp AS nomCli FROM Atividade LEFT JOIN Cliente ON Atividade.codCli = Cliente.codCli LEFT JOIN Empresa ON Cliente.cnpjCli = Empresa.cnpjEmp WHERE Atividade.codAti = (SELECT IDENT_CURRENT('Atividade') AS codAti) ORDER BY datAti", connection);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                atividade.codAti = ExtraDAO.ObterValor<int>(reader, 0, 0);
                atividade.codCli = ExtraDAO.ObterValor<int>(reader, 1, 0);
                atividade.desAti = ExtraDAO.ObterValor<string>(reader, 2, null);
                atividade.tipAti = ExtraDAO.ObterValor<string>(reader, 3, null);
                atividade.datAti = ExtraDAO.ObterValor<DateTime>(reader, 4, new DateTime()).ToShortDateString();
                atividade.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 5, new TimeSpan()).ToString().Substring(0, 5);
                atividade.nomCli = ExtraDAO.ObterValor<string>(reader, 6, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return atividade;
        }
    }
}
