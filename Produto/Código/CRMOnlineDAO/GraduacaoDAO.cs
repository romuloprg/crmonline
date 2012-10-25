using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class GraduacaoDAO : IGraduacaoDAO
    {
        private SqlConnection connection;

        public GraduacaoDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
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

        public List<GraduacaoEntity> ObterTodos()
        {
            //TODO: código para selecionar todos os graduacaos
            List<GraduacaoEntity> graduacoes = new List<GraduacaoEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("graduacao_ObterTodos", connection);
                command.CommandType = CommandType.StoredProcedure;
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GraduacaoEntity graduacao = new GraduacaoEntity();

                    object valor = reader.GetValue(0);

                    graduacao.codGra = this.ObterValor<int>(reader, 0, 0);
                    graduacao.nomGra = this.ObterValor<string>(reader, 1, null);

                    graduacoes.Add(graduacao);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return graduacoes;
        }
    }
}