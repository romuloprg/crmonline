using System;
using System.Collections.Generic;
using System.Data;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IExtrasDAO
    {
        DataTable listaEstado();
        DataTable listaCidade(string sigEst);
    }
}
