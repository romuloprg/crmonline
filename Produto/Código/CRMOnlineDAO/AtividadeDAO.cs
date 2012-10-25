using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class AtividadeDAO: IAtividadeDAO
    {
        private SqlConnection connection;

        public AtividadeDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(AtividadeEntity atividade)
        {
            //TODO: Código para inserir atividade
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("atividade_Inserir", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@desAti", atividade.desAti);
                command.Parameters.AddWithValue("@tipAti", atividade.tipAti);
                command.Parameters.AddWithValue("@datAti", atividade.datAti);
                command.Parameters.AddWithValue("@horAti", atividade.horAti);
                command.Parameters.AddWithValue("@durAti", atividade.durAti);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(AtividadeEntity atividade)
        {
            //TODO: Código para atualizar atividade
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("atividade_Atualizar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codAti", atividade.codAti);
                command.Parameters.AddWithValue("@desAti", atividade.desAti);
                command.Parameters.AddWithValue("@tipAti", atividade.tipAti);
                command.Parameters.AddWithValue("@datAti", atividade.datAti);
                command.Parameters.AddWithValue("@horAti", atividade.horAti);
                command.Parameters.AddWithValue("@durAti", atividade.durAti);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Remover(int codAti)
        {
            //TODO: código para remover atividade
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("atividade_Remover", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codAti", codAti);
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

        public List<AtividadeEntity> ObterTodos()
        {
            //TODO: código para selecionar todos os clientes
            List<AtividadeEntity> atividades = new List<AtividadeEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("atividade_ObterTodos", connection);
                command.CommandType = CommandType.StoredProcedure;
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AtividadeEntity atividade = new AtividadeEntity();

                    object valor = reader.GetValue(0);

                    atividade.codAti = this.ObterValor<int>(reader, 0, 0);
                    atividade.desAti = this.ObterValor<string>(reader, 1, null);
                    atividade.tipAti = this.ObterValor<string>(reader, 2, null);
                    atividade.datAti = this.ObterValor<DateTime>(reader, 3, new DateTime()).ToShortDateString();
                    atividade.horAti = this.ObterValor<TimeSpan>(reader, 4, new TimeSpan()).ToString();
                    atividade.durAti = this.ObterValor<int>(reader, 5, 0);

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

        public AtividadeEntity Obter(int codAti)
        {
            //TODO: código para selecionar uma atividade pelo código
            AtividadeEntity atividade = new AtividadeEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("atividade_Obter", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codAti", codAti);
                IDataReader reader = command.ExecuteReader();

                reader.Read();
                object valor = reader.GetValue(0);

                atividade.codAti = this.ObterValor<int>(reader, 0, 0);
                atividade.desAti = this.ObterValor<string>(reader, 1, null);
                atividade.tipAti = this.ObterValor<string>(reader, 2, null);
                atividade.datAti = this.ObterValor<DateTime>(reader, 3, new DateTime()).ToShortDateString();
                atividade.horAti = this.ObterValor<TimeSpan>(reader, 4, new TimeSpan()).ToString();
                atividade.durAti = this.ObterValor<int>(reader, 5, 0);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return atividade;
        }

        public List<AtividadeEntity> Buscar(string busca)
        {
            //TODO: código para selecionar atividades
            List<AtividadeEntity> atividades = new List<AtividadeEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("atividade_Buscar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@busca", busca);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AtividadeEntity atividade = new AtividadeEntity();

                    object valor = reader.GetValue(0);

                    atividade.codAti = this.ObterValor<int>(reader, 0, 0);
                    atividade.desAti = this.ObterValor<string>(reader, 1, null);
                    atividade.tipAti = this.ObterValor<string>(reader, 2, null);
                    atividade.datAti = this.ObterValor<DateTime>(reader, 3, new DateTime()).ToShortDateString();
                    atividade.horAti = this.ObterValor<TimeSpan>(reader, 4, new TimeSpan()).ToString();
                    atividade.durAti = this.ObterValor<int>(reader, 5, 0);

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
    }
}