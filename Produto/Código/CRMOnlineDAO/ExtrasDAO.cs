using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    class ExtrasDAO : IExtrasDAO
    {
        OleDbConnection connection;

        public ExtrasDAO()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Brasil.mdb;");
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
