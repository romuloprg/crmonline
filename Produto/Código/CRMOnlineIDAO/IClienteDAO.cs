using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IClienteDAO
    {
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        Cliente ObterCliente(int id);
        List<Cliente> ObterTodos();
    }
}
