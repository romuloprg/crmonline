using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IClienteDAO
    {
        void Inserir(ClienteEntity cliente);
        void Atualizar(ClienteEntity cliente);
        ClienteEntity ObterCliente(int id);
        List<ClienteEntity> ObterTodos();
        void Remover(int id);
    }
}
