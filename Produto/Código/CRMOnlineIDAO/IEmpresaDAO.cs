using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IEmpresaDAO
    {
        bool Inserir(EmpresaEntity empresa, string cpfUsu);
        bool Atualizar(EmpresaEntity empresa);
        bool Remover(string cnpjEmp);
        List<EmpresaEntity> ObterTodos();
        EmpresaEntity Obter(string cnpjEmp);
        List<EmpresaEntity> Buscar(string cpfUsu);
    }
}
