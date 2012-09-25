using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class ClienteController
    {
        public void Inserir(ClienteEntity cliente)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            iClienteDAO.Inserir(cliente);
        }

        public void Atualizar(ClienteEntity cliente)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            iClienteDAO.Atualizar(cliente);
        }

        public ClienteEntity ObterCliente(int id)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.ObterCliente(id);
        }

        public List<ClienteEntity> ObterTodos()
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.ObterTodos();
        }

        public void Remover(int id)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            iClienteDAO.Remover(id);
        }
    }
}
