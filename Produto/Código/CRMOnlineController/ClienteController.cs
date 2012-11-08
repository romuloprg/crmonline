using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class ClienteController : IClienteDAO
    {
        public bool Inserir(ClienteEntity cliente)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Inserir(cliente);
        }

        public bool Remover(int codCli)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Remover(codCli);
        }

        public ClienteEntity Obter(int codCli)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Obter(codCli);
        }

        public List<ClienteEntity> ObterTodos(string cnpjEmp)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.ObterTodos(cnpjEmp);
        }

        public List<ClienteEntity> Buscar(string cnpjEmp, string busca)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.Buscar(cnpjEmp, busca);
        }
    }
}
