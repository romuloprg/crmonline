using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class ContratoController : IContratoDAO
    {
        public bool Inserir(ContratoEntity contrato)
        {
            IContratoDAO iContratoDAO = (IContratoDAO)DAOFactory.CreateDAO<IContratoDAO>();
            return iContratoDAO.Inserir(contrato);
        }

        public bool Atualizar(ContratoEntity contrato)
        {
            IContratoDAO iContratoDAO = (IContratoDAO)DAOFactory.CreateDAO<IContratoDAO>();
            return iContratoDAO.Atualizar(contrato);
        }

        public bool Cancelar(string cpfUsu)
        {
            IContratoDAO iContratoDAO = (IContratoDAO)DAOFactory.CreateDAO<IContratoDAO>();
            return iContratoDAO.Cancelar(cpfUsu);
        }

        public bool Remover(string cpfUsu)
        {
            IContratoDAO iContratoDAO = (IContratoDAO)DAOFactory.CreateDAO<IContratoDAO>();
            return iContratoDAO.Remover(cpfUsu);
        }

        public bool RemoverTodos(string cpfUsu)
        {
            IContratoDAO iContratoDAO = (IContratoDAO)DAOFactory.CreateDAO<IContratoDAO>();
            return iContratoDAO.RemoverTodos(cpfUsu);
        }

        public ContratoEntity ObterAtivo(string cpfUsu)
        {
            IContratoDAO iContratoDAO = (IContratoDAO)DAOFactory.CreateDAO<IContratoDAO>();
            return iContratoDAO.ObterAtivo(cpfUsu);
        }

        public List<ContratoEntity> ObterTodos(string cpfUsu)
        {
            IContratoDAO iContratoDAO = (IContratoDAO)DAOFactory.CreateDAO<IContratoDAO>();
            return iContratoDAO.ObterTodos(cpfUsu);
        }
    }
}
