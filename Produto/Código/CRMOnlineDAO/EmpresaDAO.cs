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

        public bool Inserir(EmpresaEntity empresa, string cpfUsu)
        {
            //TODO: Código para inserir Empresa
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("empresa_Inserir", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cnpjEmp", empresa.cnpjEmp);
                command.Parameters.AddWithValue("@razEmp", empresa.razEmp);
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

            return true;
        }

        public bool Atualizar(EmpresaEntity empresa)
        {
            //TODO: Código para atualizar empresa
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("empresa_Atualizar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cnpjEmp", empresa.cnpjEmp);
                command.Parameters.AddWithValue("@razEmp", empresa.razEmp);
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

            return true;
        }

        public bool Remover(string cnpjEmp)
        {
            //TODO: código para remover Empresa
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("empresa_Remover", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
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
                {
                    return (T)reader.GetValue(indice);
                }
                return valorDefault;
            }
            catch
            {
                return valorDefault;
            }
        }

        public List<EmpresaEntity> ObterTodos()
        {
            //TODO: código para selecionar todas as Empresas
            List<EmpresaEntity> empresas = new List<EmpresaEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("empresa_ObterTodos", connection);
                command.CommandType = CommandType.StoredProcedure;
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmpresaEntity empresa = new EmpresaEntity();

                    object valor = reader.GetValue(0);

                    empresa.cnpjEmp = this.ObterValor<string>(reader, 0, null);
					empresa.razEmp = this.ObterValor<string>(reader, 1, null);
					empresa.nomEmp = this.ObterValor<string>(reader, 2, null);
					empresa.endEmp = this.ObterValor<string>(reader, 3, null);
					empresa.cidEmp = this.ObterValor<string>(reader, 4, null);
					empresa.ufEmp = this.ObterValor<string>(reader, 5, null);
					empresa.telEmp = this.ObterValor<string>(reader, 6, null);

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

        public EmpresaEntity Obter(string cnpjEmp)
        {
            //TODO: código para selecionar uma empresa pelo código (CNPJ)
            EmpresaEntity empresa = new EmpresaEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("empresa_Obter", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                IDataReader reader = command.ExecuteReader();

                reader.Read();
                object valor = reader.GetValue(0);

                empresa.cnpjEmp = this.ObterValor<string>(reader, 0, null);
                empresa.razEmp = this.ObterValor<string>(reader, 1, null);
                empresa.nomEmp = this.ObterValor<string>(reader, 2, null);
                empresa.endEmp = this.ObterValor<string>(reader, 3, null);
                empresa.cidEmp = this.ObterValor<string>(reader, 4, null);
                empresa.ufEmp = this.ObterValor<string>(reader, 5, null);
                empresa.telEmp = this.ObterValor<string>(reader, 6, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return empresa;
        }

        public List<EmpresaEntity> Buscar(string cpfUsu)
        {
            //TODO: código para selecionar empresas
            List<EmpresaEntity> empresas = new List<EmpresaEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("empresa_Buscar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmpresaEntity empresa = new EmpresaEntity();

                    object valor = reader.GetValue(0);

                    empresa.cnpjEmp = this.ObterValor<string>(reader, 0, null);
                    empresa.razEmp = this.ObterValor<string>(reader, 1, null);
                    empresa.nomEmp = this.ObterValor<string>(reader, 2, null);
                    empresa.endEmp = this.ObterValor<string>(reader, 3, null);
                    empresa.cidEmp = this.ObterValor<string>(reader, 4, null);
                    empresa.ufEmp = this.ObterValor<string>(reader, 5, null);
                    empresa.telEmp = this.ObterValor<string>(reader, 6, null);

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
