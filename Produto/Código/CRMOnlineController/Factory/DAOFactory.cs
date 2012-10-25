using System;
using System.Reflection;

namespace CRMOnlineController.Factory
{
    class DAOFactory
    {
        public static object CreateDAO<GenericType>()
        {
            try
            {
                // Colocar o caminho para a assembly (CRMOnlineDAO.dll) em um arquivo de configuração
                Assembly testAssembly = Assembly.LoadFile(System.Configuration.ConfigurationManager.AppSettings["caminhoDll"]);
                // Colocar o namespace ("CRMOnlineDAO.") em um arquvo de configuração
                Type calcType = testAssembly.GetType(string.Concat("CRMOnlineDAO.", typeof(GenericType).Name.Substring(1)));

                return Activator.CreateInstance(calcType);
            }
            catch
            {
                return null;
            }
        }
    }
}
