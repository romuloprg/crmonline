using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class LembreteController : ILembreteDAO
    {
        public bool Inserir(LembreteEntity lembrete)
        {
            ILembreteDAO iLembreteDAO = (ILembreteDAO)DAOFactory.CreateDAO<ILembreteDAO>();
            return iLembreteDAO.Inserir(lembrete);
        }

        public bool Remover(int codLem)
        {
            ILembreteDAO iLembreteDAO = (ILembreteDAO)DAOFactory.CreateDAO<ILembreteDAO>();
            return iLembreteDAO.Remover(codLem);
        }

        public bool RemoverTodos(int codAti)
        {
            ILembreteDAO iLembreteDAO = (ILembreteDAO)DAOFactory.CreateDAO<ILembreteDAO>();
            return iLembreteDAO.Remover(codAti);
        }

        public LembreteEntity Obter(int codLem)
        {
            ILembreteDAO iLembreteDAO = (ILembreteDAO)DAOFactory.CreateDAO<ILembreteDAO>();
            return iLembreteDAO.Obter(codLem);
        }

        public List<LembreteEntity> ObterTodos(string cpfUsu, int codAti)
        {
            ILembreteDAO iLembreteDAO = (ILembreteDAO)DAOFactory.CreateDAO<ILembreteDAO>();
            return iLembreteDAO.ObterTodos(cpfUsu, codAti);
        }

        public bool Verificar(LembreteEntity lembrete)
        {
            ILembreteDAO iLembreteDAO = (ILembreteDAO)DAOFactory.CreateDAO<ILembreteDAO>();
            return iLembreteDAO.Verificar(lembrete);
        }
    }
}
