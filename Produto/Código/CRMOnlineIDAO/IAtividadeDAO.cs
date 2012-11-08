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
        AtividadeEntity Obter(int codAti);
        List<AtividadeEntity> ObterTodos(string cpfUsu);
        List<AtividadeEntity> Buscar(string cpfUsu, string busca);
        AtividadeEntity ObterUltimo();
    }
}
