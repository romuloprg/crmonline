using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IClienteDAO
    {
        bool Inserir(ClienteEntity cliente);
        bool Atualizar(ClienteEntity cliente);
        bool Remover(int codCli);
        List<ClienteEntity> ObterTodos();
        ClienteEntity Obter(int codCli);
        List<ClienteEntity> Buscar(string busca);
    }
}
