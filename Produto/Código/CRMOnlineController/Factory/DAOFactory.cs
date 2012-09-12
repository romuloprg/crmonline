using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CRMOnlineController.Factory
{
    class DAOFactory
    {
        public static object CreateDAO<GenericType>()
        {
            //colocar o caminho para a assembly (CRMOnlineDAO.dll) em um arquivo de configuração
            Assembly testAssembly = Assembly.LoadFile(@"C:\CRMOnlineDAO.dll");
            //colocar o namespace ("CRMOnlineDAO.") em um arquvo de configuração
            Type calcType = testAssembly.GetType(string.Concat("CRMOnlineDAO.", typeof(GenericType).Name.Substring(1)));

            return Activator.CreateInstance(calcType);
        }
    }
}
