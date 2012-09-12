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
        public void Inserir(Cliente cliente)
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            iClienteDAO.Inserir(cliente);
        }

        public List<Cliente> ObterTodos()
        {
            IClienteDAO iClienteDAO = (IClienteDAO)DAOFactory.CreateDAO<IClienteDAO>();
            return iClienteDAO.ObterTodos();
        }
    }
}
