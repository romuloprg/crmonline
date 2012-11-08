using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class ParticipanteController : IParticipanteDAO
    {
        public bool Inserir(ParticipanteEntity participante)
        {
            IParticipanteDAO iParticipanteDAO = (IParticipanteDAO)DAOFactory.CreateDAO<IParticipanteDAO>();
            return iParticipanteDAO.Inserir(participante);
        }

        public bool Remover(int codAti)
        {
            IParticipanteDAO iParticipanteDAO = (IParticipanteDAO)DAOFactory.CreateDAO<IParticipanteDAO>();
            return iParticipanteDAO.Remover(codAti);
        }

        public ParticipanteEntity Obter(string cpfUsu, int codAti)
        {
            IParticipanteDAO iParticipanteDAO = (IParticipanteDAO)DAOFactory.CreateDAO<IParticipanteDAO>();
            return iParticipanteDAO.Obter(cpfUsu, codAti);
        }

        public List<string> ObterTodos(int codAti)
        {
            IParticipanteDAO iParticipanteDAO = (IParticipanteDAO)DAOFactory.CreateDAO<IParticipanteDAO>();
            return iParticipanteDAO.ObterTodos(codAti);
        }
    }
}
