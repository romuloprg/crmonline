using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRMOnlineIDAO;
using CRMOnlineEntity;

namespace CRMOnlineDAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private SqlConnection connection;

        public UsuarioDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public bool Inserir(UsuarioEntity usuario)
        {
            //TODO: Código para inserir Usuario
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usuario_Inserir", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", usuario.cpfUsu);
                command.Parameters.AddWithValue("@codGra", usuario.codGra);
                command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                command.Parameters.AddWithValue("@sexUsu", usuario.sexUsu);
                command.Parameters.AddWithValue("@endUsu", usuario.endUsu);
                command.Parameters.AddWithValue("@cidUsu", usuario.cidUsu);
                command.Parameters.AddWithValue("@ufUsu", usuario.ufUsu);
                command.Parameters.AddWithValue("@telUsu", usuario.telUsu);
                command.Parameters.AddWithValue("@emaUsu", usuario.emaUsu);
                command.Parameters.AddWithValue("@senUsu", usuario.senUsu);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool InserirContrato(string cpfUsu, string cnpjEmp, int codCar)
        {
            //TODO: Código para atualizar usuário
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("contrato_Inserir", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                command.Parameters.AddWithValue("@codCar", codCar);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Atualizar(UsuarioEntity usuario)
        {
            //TODO: Código para atualizar usuário
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usuario_Atualizar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", usuario.cpfUsu);
                command.Parameters.AddWithValue("@codGra", usuario.codGra);
                command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                command.Parameters.AddWithValue("@sexUsu", usuario.sexUsu);
                command.Parameters.AddWithValue("@endUsu", usuario.endUsu);
                command.Parameters.AddWithValue("@cidUsu", usuario.cidUsu);
                command.Parameters.AddWithValue("@ufUsu", usuario.ufUsu);
                command.Parameters.AddWithValue("@telUsu", usuario.telUsu);
                command.Parameters.AddWithValue("@emaUsu", usuario.emaUsu);
                command.Parameters.AddWithValue("@senUsu", usuario.senUsu);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool AtualizarContrato(string cpfUsu, string cnpjEmp, int codCar)
        {
            //TODO: Código para atualizar usuário
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("contrato_Atualizar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                command.Parameters.AddWithValue("@codCar", codCar);
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Remover(string cpfUsu)
        {
            //TODO: código para remover usuário
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usuario_Remover", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                command.ExecuteNonQuery();
                RemoverContrato(cpfUsu);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoverContrato(string cpfUsu)
        {
            //TODO: código para remover usuário
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Contrato_Remover", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
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

        public UsuarioEntity Obter(string cpfUsu)
        {
            //TODO: código para selecionar um usuário pelo cpf
            UsuarioEntity usuario = new UsuarioEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usuario_Obter", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                usuario.cpfUsu = this.ObterValor<string>(reader, 0, null);
                usuario.nomUsu = this.ObterValor<string>(reader, 1, null);
                usuario.sexUsu = this.ObterValor<string>(reader, 2, null);
                usuario.endUsu = this.ObterValor<string>(reader, 3, null);
                usuario.cidUsu = this.ObterValor<string>(reader, 4, null);
                usuario.ufUsu = this.ObterValor<string>(reader, 5, null);
                usuario.telUsu = this.ObterValor<string>(reader, 6, null);
                usuario.emaUsu = this.ObterValor<string>(reader, 7, null);
                usuario.senUsu = this.ObterValor<string>(reader, 8, null);
                usuario.codGra = this.ObterValor<int>(reader, 9, 0);
                usuario.nomGra = this.ObterValor<string>(reader, 10, null);
                usuario.codCar = this.ObterValor<int>(reader, 11, 0);
                usuario.nomCar = this.ObterValor<string>(reader, 12, null);
                usuario.cnpjEmp = this.ObterValor<string>(reader, 13, null);
                usuario.nomEmp = this.ObterValor<string>(reader, 14, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return usuario;
        }

        public ContratoEntity ObterContrato(string cpfUsu)
        {
            ContratoEntity contrato = new ContratoEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("contrato_Obter", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                contrato.codCtr = this.ObterValor<int>(reader, 0, 0);
                contrato.cpfUsu = this.ObterValor<string>(reader, 1, null);
                contrato.nomUsu = this.ObterValor<string>(reader, 2, null);
                contrato.cnpjEmp = this.ObterValor<string>(reader, 3, null);
                contrato.nomEmp = this.ObterValor<string>(reader, 4, null);
                contrato.codCar = this.ObterValor<int>(reader, 5, 0);
                contrato.nomCar = this.ObterValor<string>(reader, 6, null);
                contrato.iniCtr = this.ObterValor<DateTime>(reader, 7, new DateTime()).ToShortDateString();
                contrato.fimCtr = this.ObterValor<DateTime>(reader, 8, new DateTime()).ToShortDateString();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return contrato;
        }

        public List<UsuarioEntity> Buscar(string cpfUsu)
        {
            //TODO: código para selecionar usuários
            List<UsuarioEntity> usuarios = new List<UsuarioEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usuario_Buscar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UsuarioEntity usuario = new UsuarioEntity();

                    usuario.cpfUsu = this.ObterValor<string>(reader, 0, null);
                    usuario.nomUsu = this.ObterValor<string>(reader, 1, null);
                    usuario.codCar = this.ObterValor<int>(reader, 2, 0);
                    usuario.nomCar = this.ObterValor<string>(reader, 3, null);
                    usuario.cnpjEmp = this.ObterValor<string>(reader, 4, null);
                    usuario.nomEmp = this.ObterValor<string>(reader, 5, null);

                    usuarios.Add(usuario);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return usuarios;
        }

        public List<ContratoEntity> BuscarContrato(string cpfUsu)
        {
            //TODO: código para selecionar usuários
            List<ContratoEntity> contratos = new List<ContratoEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("contrato_Buscar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ContratoEntity contrato = new ContratoEntity();

                    contrato.codCtr = this.ObterValor<int>(reader, 0, 0);
                    contrato.cpfUsu = this.ObterValor<string>(reader, 1, null);
                    contrato.nomUsu = this.ObterValor<string>(reader, 2, null);
                    contrato.cnpjEmp = this.ObterValor<string>(reader, 3, null);
                    contrato.nomEmp = this.ObterValor<string>(reader, 4, null);
                    contrato.codCar = this.ObterValor<int>(reader, 5, 0);
                    contrato.nomCar = this.ObterValor<string>(reader, 6, null);
                    contrato.iniCtr = this.ObterValor<DateTime>(reader, 7, new DateTime()).ToShortDateString();
                    contrato.fimCtr = this.ObterValor<DateTime>(reader, 8, new DateTime()).ToShortDateString();

                    contratos.Add(contrato);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return contratos;
        }

        public List<string> Validar(string emaUsu, string senUsu)
        {
            string cpfUsu = null;
            string nomUsu = null;
            string nomCar = null;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usuario_Validar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@emaUsu", emaUsu);
                command.Parameters.AddWithValue("@senUsu", senUsu);
                IDataReader reader = command.ExecuteReader();

                reader.Read();
                cpfUsu = this.ObterValor<string>(reader, 0, null);
                nomUsu = this.ObterValor<string>(reader, 1, null);
                nomCar = this.ObterValor<string>(reader, 2, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            List<string> lista = new List<string>();
            lista.Add(cpfUsu);
            lista.Add(nomUsu);
            lista.Add(nomCar);

            return lista;
        }
    }
}
