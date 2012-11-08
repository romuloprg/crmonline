using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class EmpresaController : IEmpresaDAO
    {
        public bool Inserir(EmpresaEntity empresa)
        {
            IEmpresaDAO iEmpresaDAO = (IEmpresaDAO)DAOFactory.CreateDAO<IEmpresaDAO>();
            return iEmpresaDAO.Inserir(empresa);
        }

        public bool Atualizar(EmpresaEntity empresa)
        {
            IEmpresaDAO iEmpresaDAO = (IEmpresaDAO)DAOFactory.CreateDAO<IEmpresaDAO>();
            return iEmpresaDAO.Atualizar(empresa);
        }

        public bool Remover(string cnpjEmp)
        {
            IEmpresaDAO iEmpresaDAO = (IEmpresaDAO)DAOFactory.CreateDAO<IEmpresaDAO>();
            return iEmpresaDAO.Remover(cnpjEmp);
        }

        public EmpresaEntity Obter(string cnpjEmp)
        {
            IEmpresaDAO iEmpresaDAO = (IEmpresaDAO)DAOFactory.CreateDAO<IEmpresaDAO>();
            return iEmpresaDAO.Obter(cnpjEmp);
        }

        public List<EmpresaEntity> ObterTodos()
        {
            IEmpresaDAO iEmpresaDAO = (IEmpresaDAO)DAOFactory.CreateDAO<IEmpresaDAO>();
            return iEmpresaDAO.ObterTodos();
        }

        public List<EmpresaEntity> ObterTodos(string cnpjEmp)
        {
            IEmpresaDAO iEmpresaDAO = (IEmpresaDAO)DAOFactory.CreateDAO<IEmpresaDAO>();
            return iEmpresaDAO.ObterTodos(cnpjEmp);
        }
    }
}
