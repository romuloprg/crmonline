using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IContratoDAO
    {
        bool Inserir(ContratoEntity contrato);
        bool Atualizar(ContratoEntity contrato);
        bool Cancelar(string cpfUsu);
        bool Remover(string cpfUsu);
        bool RemoverTodos(string cpfUsu);
        ContratoEntity ObterAtivo(string cpfUsu);
        List<ContratoEntity> ObterTodos(string cpfUsu);
    }
}
