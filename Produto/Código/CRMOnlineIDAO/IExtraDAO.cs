using System;
using System.Collections.Generic;
using System.Data;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IExtraDAO
    {
        DataTable listaEstado();
        DataTable listaCidade(string sigEst);
    }
}
