using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class EmpresaDAO : IEmpresaDAO
    {
        private SqlConnection connection;

        public EmpresaDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(EmpresaEntity empresa)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Empresa VALUES (@cnpjEmp, @nomEmp, @endEmp, @cidEmp, @ufEmp, @telEmp)", connection);
                command.Parameters.AddWithValue("@cnpjEmp", empresa.cnpjEmp);
                command.Parameters.AddWithValue("@nomEmp", empresa.nomEmp);
                command.Parameters.AddWithValue("@endEmp", empresa.endEmp);
                command.Parameters.AddWithValue("@cidEmp", empresa.cidEmp);
                command.Parameters.AddWithValue("@ufEmp", empresa.ufEmp);
                command.Parameters.AddWithValue("@telEmp", empresa.telEmp);
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

        public bool Atualizar(EmpresaEntity empresa)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Empresa SET nomEmp = @nomEmp, endEmp = @endEmp, cidEmp = @cidEmp, ufEmp = @ufEmp, telEmp = @telEmp WHERE cnpjEmp = @cnpjEmp", connection);
                command.Parameters.AddWithValue("@cnpjEmp", empresa.cnpjEmp);
                command.Parameters.AddWithValue("@nomEmp", empresa.nomEmp);
                command.Parameters.AddWithValue("@endEmp", empresa.endEmp);
                command.Parameters.AddWithValue("@cidEmp", empresa.cidEmp);
                command.Parameters.AddWithValue("@ufEmp", empresa.ufEmp);
                command.Parameters.AddWithValue("@telEmp", empresa.telEmp);
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

        public bool Remover(string cnpjEmp)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Empresa WHERE cnpjEmp = @cnpjEmp", connection);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
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

        public EmpresaEntity Obter(string cnpjEmp)
        {
            EmpresaEntity empresa = new EmpresaEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT cnpjEmp, nomEmp, endEmp, cidEmp, ufEmp, telEmp FROM Empresa WHERE cnpjEmp = @cnpjEmp ORDER BY nomEmp", connection);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                empresa.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 0, null);
                empresa.nomEmp = ExtraDAO.ObterValor<string>(reader, 1, null);
                empresa.endEmp = ExtraDAO.ObterValor<string>(reader, 2, null);
                empresa.cidEmp = ExtraDAO.ObterValor<string>(reader, 3, null);
                empresa.ufEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                empresa.telEmp = ExtraDAO.ObterValor<string>(reader, 5, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return empresa;
        }

        public List<EmpresaEntity> ObterTodos()
        {
            List<EmpresaEntity> empresas = new List<EmpresaEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT cnpjEmp, nomEmp, endEmp, cidEmp, ufEmp, telEmp FROM Empresa ORDER BY nomEmp", connection);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmpresaEntity empresa = new EmpresaEntity();

                    empresa.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 0, null);
                    empresa.nomEmp = ExtraDAO.ObterValor<string>(reader, 1, null);
                    empresa.endEmp = ExtraDAO.ObterValor<string>(reader, 2, null);
                    empresa.cidEmp = ExtraDAO.ObterValor<string>(reader, 3, null);
                    empresa.ufEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                    empresa.telEmp = ExtraDAO.ObterValor<string>(reader, 5, null);

                    empresas.Add(empresa);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return empresas;
        }

        public List<EmpresaEntity> ObterTodos(string cnpjEmp)
        {
            List<EmpresaEntity> empresas = new List<EmpresaEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT cnpjEmp, nomEmp, endEmp, cidEmp, ufEmp, telEmp FROM Empresa WHERE cnpjEmp <> @cnpjEmp AND cnpjEmp NOT IN (SELECT DISTINCT cnpjCli FROM Cliente WHERE cnpjEmp = @cnpjEmp) ORDER BY nomEmp", connection);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmpresaEntity empresa = new EmpresaEntity();

                    empresa.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 0, null);
                    empresa.nomEmp = ExtraDAO.ObterValor<string>(reader, 1, null);
                    empresa.endEmp = ExtraDAO.ObterValor<string>(reader, 2, null);
                    empresa.cidEmp = ExtraDAO.ObterValor<string>(reader, 3, null);
                    empresa.ufEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                    empresa.telEmp = ExtraDAO.ObterValor<string>(reader, 5, null);

                    empresas.Add(empresa);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return empresas;
        }
    }
}
