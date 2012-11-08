using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class VendedorController : IVendedorDAO
    {
        public bool Inserir(VendedorEntity vendedor)
        {
            IVendedorDAO iVendedorDAO = (IVendedorDAO)DAOFactory.CreateDAO<IVendedorDAO>();
            return iVendedorDAO.Inserir(vendedor);
        }

        public bool Atualizar(VendedorEntity vendedor)
        {
            IVendedorDAO iVendedorDAO = (IVendedorDAO)DAOFactory.CreateDAO<IVendedorDAO>();
            return iVendedorDAO.Atualizar(vendedor);
        }

        public bool Remover(int codCli)
        {
            IVendedorDAO iVendedorDAO = (IVendedorDAO)DAOFactory.CreateDAO<IVendedorDAO>();
            return iVendedorDAO.Remover(codCli);
        }

        public List<VendedorEntity> ObterTodos(string cpfUsu)
        {
            IVendedorDAO iVendedorDAO = (IVendedorDAO)DAOFactory.CreateDAO<IVendedorDAO>();
            return iVendedorDAO.ObterTodos(cpfUsu);
        }
    }
}
