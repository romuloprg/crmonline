using System;
using System.Collections.Generic;
using CRMOnlineEntity;
using CRMOnlineIDAO;
using CRMOnlineController.Factory;

namespace CRMOnlineController
{
    public class UsuarioController
    {
        public bool Inserir(UsuarioEntity usuario)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Inserir(usuario);
        }

        public bool InserirContrato(string cpfUsu, string cnpjEmp, int codCar)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.InserirContrato(cpfUsu, cnpjEmp, codCar);
        }

        public bool Atualizar(UsuarioEntity usuario)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Atualizar(usuario);
        }

        public bool AtualizarContrato(string cpfUsu, string cnpjEmp, int codCar)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.AtualizarContrato(cpfUsu, cnpjEmp, codCar);
        }

        public bool Remover(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Remover(cpfUsu);
        }

        public bool RemoverContrato(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.RemoverContrato(cpfUsu);
        }

        public UsuarioEntity Obter(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Obter(cpfUsu);
        }

        public ContratoEntity ObterContrato(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.ObterContrato(cpfUsu);
        }

        public List<UsuarioEntity> Buscar(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Buscar(cpfUsu);
        }

        public List<ContratoEntity> BuscarContrato(string cpfUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.BuscarContrato(cpfUsu);
        }

        public List<string> Validar(string emaUsu, string senUsu)
        {
            IUsuarioDAO iUsuarioDAO = (IUsuarioDAO)DAOFactory.CreateDAO<IUsuarioDAO>();
            return iUsuarioDAO.Validar(emaUsu, senUsu);
        }
    }
}
