﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMOnlineIDAO;
using CRMOnlineEntity;
using System.Data;
using System.Data.SqlClient;

namespace CRMOnlineDAO
{
    public class ClienteDAO : IClienteDAO
    {
        private SqlConnection connection;

        public ClienteDAO()
        {
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMOnlineDB;Integrated Security=True");
        }

        public void Inserir(Cliente cliente)
        {
            //TODO: Código para inserir no banco de dados
            connection.Open();
            SqlCommand command = new SqlCommand("sproc_InsereCliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Codigo", cliente.codCliente));
            command.Parameters.Add(new SqlParameter("@Nome", cliente.nomeCliente));
            command.Parameters.Add(new SqlParameter("@Email", cliente.enderecoCliente));
            command.Parameters.Add(new SqlParameter("@Cidade", cliente.cidadeCliente));
            command.Parameters.Add(new SqlParameter("@UF", cliente.ufCliente));
            command.Parameters.Add(new SqlParameter("@CodEmpresa", cliente.cnpjEmpresa));
            command.ExecuteNonQuery();
        }


        public void Atualizar(Cliente cliente)
        {
            //TODO: código para atualizar cliente
            connection.Open();
            SqlCommand command = new SqlCommand("sproc_AtualizaCliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Codigo", cliente.codCliente));
            command.Parameters.Add(new SqlParameter("@Nome", cliente.nomeCliente));
            command.Parameters.Add(new SqlParameter("@Email", cliente.enderecoCliente));
            command.Parameters.Add(new SqlParameter("@Cidade", cliente.cidadeCliente));
            command.Parameters.Add(new SqlParameter("@UF", cliente.ufCliente));
            command.Parameters.Add(new SqlParameter("@CodEmpresa", cliente.cnpjEmpresa));
            command.ExecuteNonQuery();
        }

        //----------------------------até aqui OK-------------------------

        public Cliente ObterCliente(int id)
        {
            //TODO: código para selecionar um cliente pelo id
            return null;
        }

        public T ObterValor<T>(IDataReader reader, int indice, T valorDefault)
        {
            if (!reader.IsDBNull(indice))
            {
                return (T)reader.GetValue(indice);
            }
            return valorDefault;
        }

        public List<Cliente> ObterTodos()
        {
            IDbConnection connection = null;
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                //Colocar a string de conexão em um arquivo de configuração
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "Select Nome, Email from Cliente";
                connection.Open();
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    object valor = reader.GetValue(0);

                    cliente.Nome = this.ObterValor<string>(reader, 0, null);
                    cliente.Endereco = this.ObterValor<string>(reader, 1, null);
                    cliente.Cidade = this.ObterValor<string>(reader, 2, null);
                    cliente.UF = this.ObterValor<string>(reader, 3, null);
                    cliente.CodEmpresa = this.ObterValor<string>(reader, 4, null);

                    clientes.Add(cliente);
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return clientes;
        }
    }
}