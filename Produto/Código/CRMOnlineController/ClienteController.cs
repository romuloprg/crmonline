using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class ClienteController
    {
        public bool Inserir(ClienteEntity cliente)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Inserir(cliente);
        }

        public bool Atualizar(ClienteEntity cliente)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Atualizar(cliente);
        }

        public bool Remover(int codCli)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Remover(codCli);
        }

        public List<ClienteEntity> ObterTodos()
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.ObterTodos();
        }

        public ClienteEntity Obter(int codCli)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Obter(codCli);
        }

        public List<ClienteEntity> Buscar(string busca)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Buscar(busca);
        }
    }
}
