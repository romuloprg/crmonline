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

        public List<GraduacaoEntity> ObterTodos()
        {
            List<GraduacaoEntity> graduacoes = new List<GraduacaoEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT codGra, nomGra FROM Graduacao ORDER BY nomGra", connection);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GraduacaoEntity graduacao = new GraduacaoEntity();

                    graduacao.codGra = ExtraDAO.ObterValor<int>(reader, 0, 0);
                    graduacao.nomGra = ExtraDAO.ObterValor<string>(reader, 1, null);

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
