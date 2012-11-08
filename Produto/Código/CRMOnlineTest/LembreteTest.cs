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
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }

        //[ClassInitialize]
        //[TestInitialize]
        //[TestInitialize]
        //[TestCleanup]
        //[ClassCleanup]
    }
}
