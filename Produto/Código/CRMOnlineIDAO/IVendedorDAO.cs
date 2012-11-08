using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IVendedorDAO
    {
        bool Inserir(VendedorEntity vendedor);
        bool Atualizar(VendedorEntity vendedor);
        bool Remover(int codCli);
        List<VendedorEntity> ObterTodos(string cpfUsu);
    }
}
