using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class UsuarioController : IUsuarioDAO
    {
        public bool Inserir(UsuarioEntity usuario)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Inserir(usuario);
        }

        public bool Atualizar(UsuarioEntity usuario)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Atualizar(usuario);
        }

        public bool Remover(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Remover(cpfUsu);
        }

        public UsuarioEntity Obter(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Obter(cpfUsu);
        }

        public List<UsuarioEntity> ObterFuncionarios(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.ObterFuncionarios(cpfUsu);
        }

        public List<UsuarioEntity> ObterParteFuncionarios(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.ObterParteFuncionarios(cpfUsu);
        }

        public List<UsuarioEntity> ObterTodosFuncionarios(string cnpjEmp)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.ObterTodosFuncionarios(cnpjEmp);
        }
        
        public List<UsuarioEntity> BuscarFuncionarios(string cnpjEmp, string busca)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.BuscarFuncionarios(cnpjEmp, busca);
        }

        public UsuarioEntity Validar(string emaUsu, string senUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Validar(emaUsu, senUsu);
        }
    }
}
