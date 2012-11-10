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
            lembrete.datLem = "10/11/2012";
            lembrete.horLem = "10:02";

            Assert.IsTrue(lembreteDAO.Verificar(lembrete));
        }

        //[ClassInitialize]
        //[TestInitialize]
        //[TestInitialize]
        //[TestCleanup]
        //[ClassCleanup]

    }
}
