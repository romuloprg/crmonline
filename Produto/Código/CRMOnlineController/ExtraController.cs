using System;
using System.Data;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class ExtraController : IExtraDAO
    {
        public DataTable listaEstado()
        {
            IExtraDAO iExtraDAO = (IExtraDAO)DAOFactory.CreateDAO<IExtraDAO>();
            return iExtraDAO.listaEstado();
        }

        public DataTable listaCidade(string sigEst)
        {
            IExtraDAO iExtraDAO = (IExtraDAO)DAOFactory.CreateDAO<IExtraDAO>();
            return iExtraDAO.listaCidade(sigEst);
        }
    }
}
