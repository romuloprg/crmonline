using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class AtividadeController : IAtividadeDAO
    {
        public bool Inserir(AtividadeEntity atividade)
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.Inserir(atividade);
        }

        public bool Atualizar(AtividadeEntity atividade)
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.Atualizar(atividade);
        }

        public bool Remover(int codAti)
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.Remover(codAti);
        }

        public AtividadeEntity Obter(int codAti)
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.Obter(codAti);
        }

        public List<AtividadeEntity> ObterTodos(string cpfUsu)
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.ObterTodos(cpfUsu);
        }

        public List<AtividadeEntity> Buscar(string cpfUsu, string busca)
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.Buscar(cpfUsu, busca);
        }

        public AtividadeEntity ObterUltimo()
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.ObterUltimo();
        }
    }
}
