using System;
using System.Collections.Generic;
using System.Data;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class ExtrasController
    {
        public DataTable listaEstado()
        {
            IExtrasDAO iExtrasDAO = (IExtrasDAO)DAOFactory.CreateDAO<IExtrasDAO>();
            return iExtrasDAO.listaEstado();
        }

        public DataTable listaCidade(string sigEst)
        {
            IExtrasDAO iExtrasDAO = (IExtrasDAO)DAOFactory.CreateDAO<IExtrasDAO>();
            return iExtrasDAO.listaCidade(sigEst);
        }
    }
}
