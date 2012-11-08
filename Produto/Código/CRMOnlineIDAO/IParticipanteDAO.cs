using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IParticipanteDAO
    {
        bool Inserir(ParticipanteEntity participante);
        bool Remover(int codAti);
        ParticipanteEntity Obter(string cpfUsu, int codAti);
        List<string> ObterTodos(int codAti);
    }
}
