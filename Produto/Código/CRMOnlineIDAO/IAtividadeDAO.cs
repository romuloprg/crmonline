using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IAtividadeDAO
    {
        bool Inserir(AtividadeEntity atividade);
        bool Atualizar(AtividadeEntity atividade);
        bool Remover(int codAti);
        List<AtividadeEntity> ObterTodos();
        AtividadeEntity Obter(int codAti);
        List<AtividadeEntity> Buscar(string busca);
    }
}
