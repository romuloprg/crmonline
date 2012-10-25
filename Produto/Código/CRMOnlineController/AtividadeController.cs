using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class AtividadeController
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

        public List<AtividadeEntity> ObterTodos()
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.ObterTodos();
        }

        public AtividadeEntity Obter(int codAti)
        {
            IAtividadeDAO iClienteDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iClienteDAO.Obter(codAti);
        }

        public List<AtividadeEntity> Buscar(string busca)
        {
            IAtividadeDAO iAtividadeDAO = (IAtividadeDAO)DAOFactory.CreateDAO<IAtividadeDAO>();
            return iAtividadeDAO.Buscar(busca);
        }
    }
}
