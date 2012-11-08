using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class ParticipanteDAO : IParticipanteDAO
    {
        private SqlConnection connection;

        public ParticipanteDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(ParticipanteEntity participante)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Participante VALUES (@cpfUsu, @codAti)", connection);
                command.Parameters.AddWithValue("@cpfUsu", participante.cpfUsu);
                command.Parameters.AddWithValue("@codAti", participante.codAti);
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
                SqlCommand command = new SqlCommand("DELETE FROM Participante WHERE codAti = @codAti", connection);
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

        public ParticipanteEntity Obter(string cpfUsu, int codAti)
        {
            ParticipanteEntity participante = new ParticipanteEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codPar, Participante.cpfUsu, Participante.codAti, nomUsu, codCli, datAti, horAti FROM Participante LEFT JOIN Usuario ON Participante.cpfUsu = Usuario.cpfUsu LEFT JOIN Atividade ON Participante.codAti = Atividade.codAti WHERE Participante.cpfUsu = @cpfUsu AND Participante.codAti = @codAti ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                command.Parameters.AddWithValue("@codAti", codAti);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                participante.codPar = ExtraDAO.ObterValor<int>(reader, 0, 0);
                participante.cpfUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                participante.codAti = ExtraDAO.ObterValor<int>(reader, 2, 0);
                participante.nomUsu = ExtraDAO.ObterValor<string>(reader, 3, null);
                participante.codCli = ExtraDAO.ObterValor<int>(reader, 4, 0);
                participante.datAti = ExtraDAO.ObterValor<DateTime>(reader, 5, new DateTime()).ToShortDateString();
                participante.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 6, new TimeSpan()).ToString().Substring(0, 5);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return participante;
        }

        public List<string> ObterTodos(int codAti)
        {
            List<string> participantes = new List<string>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codPar, Participante.cpfUsu, Participante.codAti, nomUsu, codCli, datAti, horAti FROM Participante LEFT JOIN Usuario ON Participante.cpfUsu = Usuario.cpfUsu LEFT JOIN Atividade ON Participante.codAti = Atividade.codAti WHERE Participante.codAti = @codAti ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@codAti", codAti);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ParticipanteEntity participante = new ParticipanteEntity();

                    participante.codPar = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    participante.cpfUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                    participante.codAti = ExtraDAO.ObterValor<int>(reader, 2, 0);
                    participante.nomUsu = ExtraDAO.ObterValor<string>(reader, 3, null);
                    participante.codCli = ExtraDAO.ObterValor<int>(reader, 4, 0);
                    participante.datAti = ExtraDAO.ObterValor<DateTime>(reader, 5, new DateTime()).ToShortDateString();
                    participante.horAti = ExtraDAO.ObterValor<TimeSpan>(reader, 6, new TimeSpan()).ToString().Substring(0, 5);

                    //participantes.Add(participante);
                    participantes.Add(participante.cpfUsu);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return participantes;
        }
    }
}
