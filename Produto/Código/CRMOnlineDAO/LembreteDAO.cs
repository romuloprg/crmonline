using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class LembreteDAO : ILembreteDAO
    {
        private SqlConnection connection;

        public LembreteDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(LembreteEntity lembrete)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Lembrete VALUES ((SELECT codPar FROM Participante WHERE cpfUsu = @cpfUsu AND codAti = @codAti), @datLem, @horLem, @diaLem, @semLem)", connection);
                command.Parameters.AddWithValue("@cpfUsu", lembrete.cpfUsu);
                command.Parameters.AddWithValue("@codAti", lembrete.codAti);
                command.Parameters.AddWithValue("@datLem", lembrete.datLem);
                command.Parameters.AddWithValue("@horLem", lembrete.horLem);
                command.Parameters.AddWithValue("@diaLem", lembrete.diaLem);
                command.Parameters.AddWithValue("@semLem", lembrete.semLem);
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

        public bool Remover(int codLem)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Lembrete WHERE codLem = @codLem", connection);
                command.Parameters.AddWithValue("@codLem", codLem);
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

        public bool RemoverTodos(int codAti)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Lembrete WHERE codPar IN (SELECT codPar FROM Participante WHERE codAti = @codAti)", connection);
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

        public LembreteEntity Obter(int codLem)
        {
            LembreteEntity lembrete = new LembreteEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codLem, Lembrete.codPar, datLem, horLem, diaLem, semLem, cpfUsu, Participante.codAti, datAti, horAti FROM Lembrete LEFT JOIN Participante ON Lembrete.codPar = Participante.codPar LEFT JOIN Atividade ON Participante.codAti = Atividade.codAti WHERE codPar = @codPar ORDER BY datLem", connection);
                command.Parameters.AddWithValue("@codLem", codLem);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                lembrete.codLem = ExtraDAO.ObterValor<int>(reader, 0, 0);
                lembrete.codPar = ExtraDAO.ObterValor<int>(reader, 1, 0);
                lembrete.datLem = ExtraDAO.ObterValor<DateTime>(reader, 2, new DateTime()).ToShortDateString();
                lembrete.horLem = ExtraDAO.ObterValor<TimeSpan>(reader, 3, new TimeSpan()).ToString().Substring(0, 5);
                lembrete.diaLem = ExtraDAO.ObterValor<int>(reader, 4, 0);
                lembrete.semLem = ExtraDAO.ObterValor<bool>(reader, 5, false);
                lembrete.cpfUsu = ExtraDAO.ObterValor<string>(reader, 6, null);
                lembrete.codAti = ExtraDAO.ObterValor<int>(reader, 7, 0);
                lembrete.datAti = ExtraDAO.ObterValor<DateTime>(reader, 8, new DateTime()).ToShortDateString();
                lembrete.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 9, new TimeSpan()).ToString().Substring(0, 5);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return lembrete;
        }

        public List<LembreteEntity> ObterTodos(string cpfUsu, int codAti)
        {
            List<LembreteEntity> lembretes = new List<LembreteEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codLem, Lembrete.codPar, datLem, horLem, diaLem, semLem, cpfUsu, Participante.codAti, datAti, horAti FROM Lembrete LEFT JOIN Participante ON Lembrete.codPar = Participante.codPar LEFT JOIN Atividade ON Participante.codAti = Atividade.codAti WHERE cpfUsu = @cpfUsu AND Participante.codAti = @codAti ORDER BY datLem", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                command.Parameters.AddWithValue("@codAti", codAti);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LembreteEntity lembrete = new LembreteEntity();

                    lembrete.codLem = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    lembrete.codPar = ExtraDAO.ObterValor<int>(reader, 1, 0);
                    lembrete.datLem = ExtraDAO.ObterValor<DateTime>(reader, 2, new DateTime()).ToShortDateString();
                    lembrete.horLem = ExtraDAO.ObterValor<TimeSpan>(reader, 3, new TimeSpan()).ToString().Substring(0, 5);
                    lembrete.diaLem = ExtraDAO.ObterValor<int>(reader, 4, 0);
                    lembrete.semLem = ExtraDAO.ObterValor<bool>(reader, 5, false);
                    lembrete.cpfUsu = ExtraDAO.ObterValor<string>(reader, 6, null);
                    lembrete.codAti = ExtraDAO.ObterValor<int>(reader, 7, 0);
                    lembrete.datAti = ExtraDAO.ObterValor<DateTime>(reader, 8, new DateTime()).ToShortDateString();
                    lembrete.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 9, new TimeSpan()).ToString().Substring(0, 5);

                    lembretes.Add(lembrete);
                }
            }
            catch
            { }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return lembretes;
        }

        // Método que verifica lembretes ativos e envia email
        // O método original seria void, porém para fazer o TDD será usado bool para simplificar a codificação
        public bool Verificar(LembreteEntity lembrete)
        {
            
        }
    }
}
