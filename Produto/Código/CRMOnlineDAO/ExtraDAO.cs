using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class ExtraDAO : IExtraDAO
    {
        OleDbConnection connection;

        public ExtraDAO()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Brasil.mdb;");
        }

        static public T ObterValor<T>(IDataReader reader, int indice, T valorDefault)
        {
            try
            {
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

        public DataTable listaEstado()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT codEst, sigEst, nomEst FROM Estados ORDER BY sigEst", connection);
                da.Fill(dt);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return dt;
        }

        public DataTable listaCidade(string sigEst)
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT codCid, nomCid FROM Cidades WHERE codEst = (SELECT codEst FROM Estados WHERE sigEst = '" + sigEst + "') ORDER BY nomCid", connection);
                da.Fill(dt);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return dt;
        }
    }
}
