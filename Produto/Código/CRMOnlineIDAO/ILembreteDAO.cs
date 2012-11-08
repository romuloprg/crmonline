using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface ILembreteDAO
    {
        bool Inserir(LembreteEntity lembrete);
        bool Remover(int codLem);
        bool RemoverTodos(int codAti);
        LembreteEntity Obter(int codLem);
        List<LembreteEntity> ObterTodos(string cpfUsu, int codAti);
        bool Verificar(LembreteEntity lembrete);
    }
}
