using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IEmpresaDAO
    {
        bool Inserir(EmpresaEntity empresa);
        bool Atualizar(EmpresaEntity empresa);
        bool Remover(string cnpjEmp);
        EmpresaEntity Obter(string cnpjEmp);
        List<EmpresaEntity> ObterTodos();
        List<EmpresaEntity> ObterTodos(string cnpjEmp);
    }
}
