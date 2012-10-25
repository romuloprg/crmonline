using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class GraduacaoController
    {
        public List<GraduacaoEntity> ObterTodos()
        {
            IGraduacaoDAO iGraduacaoDAO = (IGraduacaoDAO)DAOFactory.CreateDAO<IGraduacaoDAO>();
            return iGraduacaoDAO.ObterTodos();
        }
    }
}
