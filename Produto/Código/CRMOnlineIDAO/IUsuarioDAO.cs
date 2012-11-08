using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IUsuarioDAO
    {
        bool Inserir(UsuarioEntity usuario);
        bool Atualizar(UsuarioEntity usuario);
        bool Remover(string cpfUsu);
        UsuarioEntity Obter(string cpfUsu);
        List<UsuarioEntity> ObterFuncionarios(string cpfUsu);
        List<UsuarioEntity> ObterParteFuncionarios(string cpfUsu);
        List<UsuarioEntity> ObterTodosFuncionarios(string cnpjEmp);
        List<UsuarioEntity> BuscarFuncionarios(string cnpjEmp, string busca);
        UsuarioEntity Validar(string emaUsu, string senUsu);
    }
}
