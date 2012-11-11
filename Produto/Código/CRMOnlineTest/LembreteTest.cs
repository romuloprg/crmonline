using System;
using System.Configuration;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMOnlineEntity;
using CRMOnlineDAO;

namespace CRMOnlineTest
{
    [TestClass]
    public class LembreteTest
    {
        LembreteEntity lembrete;
        LembreteDAO lembreteDAO;

        [TestInitialize]
        public void TestInitialize1()
        {
            lembrete = new LembreteEntity();
            lembreteDAO = new LembreteDAO();
        }

        [TestMethod]
        public void TestMethod1()
        {
            lembrete.datLem = "11/11/2012";
            lembrete.horLem = "10:58";
            lembrete.diaLem = 0;

            Assert.IsTrue(lembreteDAO.Verificar(lembrete));
        }

        [TestMethod]
        public void TestMethod2()
        {
            lembrete.datAti = "15/11/2012";
            lembrete.horAti = "10:59";
            lembrete.diaLem = 5;
            lembrete.semLem = false;

            Assert.IsTrue(lembreteDAO.Verificar(lembrete));
        }

        [TestMethod]
        public void TestMethod3()
        {
            lembrete.datAti = "15/11/2012";
            lembrete.horAti = "11:25";
            lembrete.diaLem = 5;
            lembrete.semLem = true;

            Assert.IsTrue(lembreteDAO.Verificar(lembrete));
        }
    }
}
