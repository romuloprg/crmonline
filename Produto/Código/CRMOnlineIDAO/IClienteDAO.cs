using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IClienteDAO
    {
        bool Inserir(ClienteEntity cliente);
        bool Remover(int codCli);
        ClienteEntity Obter(int codCli);
        List<ClienteEntity> ObterTodos(string cnpjEmp);
        List<ClienteEntity> Buscar(string cnpjEmp, string busca);
    }
}
