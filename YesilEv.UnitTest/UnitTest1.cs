using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YesilEv.DAL.Concrete;

namespace YesilEv.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CategoryDal catDal = new CategoryDal();
            var result =catDal.GetAll();
        }
    }
}
