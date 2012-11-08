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
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Usuario VALUES (@cpfUsu, @codGra, @nomUsu, @sexUsu, @endUsu, @cidUsu, @ufUsu, @telUsu, @emaUsu, @senUsu)", connection);
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
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return true;
        }

        public bool Atualizar(UsuarioEntity usuario)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Usuario SET codGra = @codGra, nomUsu = @nomUsu, sexUsu = @sexUsu, endUsu = @endUsu, cidUsu = @cidUsu, ufUsu = @ufUsu, telUsu = @telUsu, emaUsu = @emaUsu, senUsu = @senUsu WHERE cpfUsu = @cpfUsu", connection);
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
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return true;
        }

        public bool Remover(string cpfUsu)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Usuario WHERE cpfUsu = @cpfUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
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

        public UsuarioEntity Obter(string cpfUsu)
        {
            UsuarioEntity usuario = new UsuarioEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Usuario.cpfUsu, nomUsu, sexUsu, endUsu, cidUsu, ufUsu, telUsu, emaUsu, senUsu, Usuario.codGra, nomGra, Contrato.codCar, nomCar, Contrato.cnpjEmp, nomEmp FROM Usuario LEFT JOIN Graduacao ON Usuario.codGra = Graduacao.codGra LEFT JOIN Contrato ON Usuario.cpfUsu = Contrato.cpfUsu LEFT JOIN Cargo ON Contrato.codCar = Cargo.codCar LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE Usuario.cpfUsu = @cpfUsu ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                usuario.cpfUsu = ExtraDAO.ObterValor<string>(reader, 0, null);
                usuario.nomUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                usuario.sexUsu = ExtraDAO.ObterValor<string>(reader, 2, null);
                usuario.endUsu = ExtraDAO.ObterValor<string>(reader, 3, null);
                usuario.cidUsu = ExtraDAO.ObterValor<string>(reader, 4, null);
                usuario.ufUsu = ExtraDAO.ObterValor<string>(reader, 5, null);
                usuario.telUsu = ExtraDAO.ObterValor<string>(reader, 6, null);
                usuario.emaUsu = ExtraDAO.ObterValor<string>(reader, 7, null);
                usuario.senUsu = ExtraDAO.ObterValor<string>(reader, 8, null);
                usuario.codGra = ExtraDAO.ObterValor<int>(reader, 9, 0);
                usuario.nomGra = ExtraDAO.ObterValor<string>(reader, 10, null);
                usuario.codCar = ExtraDAO.ObterValor<int>(reader, 11, 0);
                usuario.nomCar = ExtraDAO.ObterValor<string>(reader, 12, null);
                usuario.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 13, null);
                usuario.nomEmp = ExtraDAO.ObterValor<string>(reader, 14, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return usuario;
        }

        public List<UsuarioEntity> ObterFuncionarios(string cpfUsu)
        {
            List<UsuarioEntity> usuarios = new List<UsuarioEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Usuario.cpfUsu, nomUsu, Cargo.codCar, nomCar, Contrato.cnpjEmp, nomEmp FROM Usuario LEFT JOIN Contrato ON Usuario.cpfUsu = Contrato.cpfUsu LEFT JOIN Cargo ON Contrato.codCar = Cargo.codCar LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE Usuario.cpfUsu <> @cpfUsu AND fimCtr is NULL AND Contrato.codCar <> 3 AND Contrato.cnpjEmp = (SELECT DISTINCT cnpjEmp FROM Contrato WHERE cpfUsu = @cpfUsu) ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UsuarioEntity usuario = new UsuarioEntity();

                    usuario.cpfUsu = ExtraDAO.ObterValor<string>(reader, 0, null);
                    usuario.nomUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                    usuario.codCar = ExtraDAO.ObterValor<int>(reader, 2, 0);
                    usuario.nomCar = ExtraDAO.ObterValor<string>(reader, 3, null);
                    usuario.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                    usuario.nomEmp = ExtraDAO.ObterValor<string>(reader, 5, null);

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

        public List<UsuarioEntity> ObterParteFuncionarios(string cpfUsu)
        {
            List<UsuarioEntity> usuarios = new List<UsuarioEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Usuario.cpfUsu, nomUsu, Cargo.codCar, nomCar, Contrato.cnpjEmp, nomEmp FROM Usuario LEFT JOIN Contrato ON Usuario.cpfUsu = Contrato.cpfUsu LEFT JOIN Cargo ON Contrato.codCar = Cargo.codCar LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE Usuario.cpfUsu <> @cpfUsu AND fimCtr is NULL AND Contrato.cnpjEmp = (SELECT DISTINCT cnpjEmp FROM Contrato WHERE cpfUsu = @cpfUsu) ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UsuarioEntity usuario = new UsuarioEntity();

                    usuario.cpfUsu = ExtraDAO.ObterValor<string>(reader, 0, null);
                    usuario.nomUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                    usuario.codCar = ExtraDAO.ObterValor<int>(reader, 2, 0);
                    usuario.nomCar = ExtraDAO.ObterValor<string>(reader, 3, null);
                    usuario.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                    usuario.nomEmp = ExtraDAO.ObterValor<string>(reader, 5, null);

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

        public List<UsuarioEntity> ObterTodosFuncionarios(string cnpjEmp)
        {
            List<UsuarioEntity> usuarios = new List<UsuarioEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Usuario.cpfUsu, nomUsu, Cargo.codCar, nomCar, Contrato.cnpjEmp, nomEmp FROM Usuario LEFT JOIN Contrato ON Usuario.cpfUsu = Contrato.cpfUsu LEFT JOIN Cargo ON Contrato.codCar = Cargo.codCar LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE fimCtr is NULL AND Contrato.cnpjEmp = @cnpjEmp ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@cnpjEmp", cnpjEmp);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UsuarioEntity usuario = new UsuarioEntity();

                    usuario.cpfUsu = ExtraDAO.ObterValor<string>(reader, 0, null);
                    usuario.nomUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                    usuario.codCar = ExtraDAO.ObterValor<int>(reader, 2, 0);
                    usuario.nomCar = ExtraDAO.ObterValor<string>(reader, 3, null);
                    usuario.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                    usuario.nomEmp = ExtraDAO.ObterValor<string>(reader, 5, null);

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

        public List<UsuarioEntity> BuscarFuncionarios(string cpfUsu, string busca)
        {
            List<UsuarioEntity> usuarios = new List<UsuarioEntity>();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Usuario.cpfUsu, nomUsu, Cargo.codCar, nomCar, Contrato.cnpjEmp, nomEmp FROM Usuario LEFT JOIN Contrato ON Usuario.cpfUsu = Contrato.cpfUsu LEFT JOIN Cargo ON Contrato.codCar = Cargo.codCar LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE Usuario.cpfUsu <> @cpfUsu AND fimCtr is NULL AND Contrato.codCar <> 3 AND Contrato.cnpjEmp = (SELECT DISTINCT cnpjEmp FROM Contrato WHERE cpfUsu = @cpfUsu) AND nomUsu LIKE CONCAT('%', @busca, '%') ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@cpfUsu", cpfUsu);
                command.Parameters.AddWithValue("@busca", busca);
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UsuarioEntity usuario = new UsuarioEntity();

                    usuario.cpfUsu = ExtraDAO.ObterValor<string>(reader, 0, null);
                    usuario.nomUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                    usuario.codCar = ExtraDAO.ObterValor<int>(reader, 2, 0);
                    usuario.nomCar = ExtraDAO.ObterValor<string>(reader, 3, null);
                    usuario.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                    usuario.nomEmp = ExtraDAO.ObterValor<string>(reader, 5, null);

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

        public UsuarioEntity Validar(string emaUsu, string senUsu)
        {
            UsuarioEntity usuario = new UsuarioEntity();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Usuario.cpfUsu, nomUsu, codCar, nomCar, cnpjEmp, nomEmp FROM Usuario LEFT JOIN (SELECT DISTINCT cpfUsu, Cargo.codCar, nomCar, Contrato.cnpjEmp, nomEmp FROM Contrato LEFT JOIN Cargo ON Contrato.codCar = Cargo.codCar LEFT JOIN Empresa ON Contrato.cnpjEmp = Empresa.cnpjEmp WHERE fimCtr IS NULL) AS Result ON Usuario.cpfUsu = Result.cpfUsu WHERE emaUsu = @emaUsu AND senUsu = @senUsu ORDER BY nomUsu", connection);
                command.Parameters.AddWithValue("@emaUsu", emaUsu);
                command.Parameters.AddWithValue("@senUsu", senUsu);
                IDataReader reader = command.ExecuteReader();

                reader.Read();

                usuario.cpfUsu = ExtraDAO.ObterValor<string>(reader, 0, null);
                usuario.nomUsu = ExtraDAO.ObterValor<string>(reader, 1, null);
                usuario.codCar = ExtraDAO.ObterValor<int>(reader, 2, 0);
                usuario.nomCar = ExtraDAO.ObterValor<string>(reader, 3, null);
                usuario.cnpjEmp = ExtraDAO.ObterValor<string>(reader, 4, null);
                usuario.nomEmp = ExtraDAO.ObterValor<string>(reader, 5, null);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return usuario;
        }
    }
}
