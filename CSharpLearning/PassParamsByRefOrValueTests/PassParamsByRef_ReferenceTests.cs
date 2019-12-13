using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassParamsByRefOrValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassParamsByRefOrValue.Tests
{
    [TestClass()]
    public class PassParamsByRef_ReferenceTests
    {
        [TestMethod()]
        public void UpdateValueTest()
        {
            Student myStu = new Student()
            {
                ID = 325,
                Name = "Wu",
                Age = 3
            };

            PassParamsByRef_Reference passParams = new PassParamsByRef_Reference();
            passParams.UpdateValue(ref myStu);

            Assert.AreEqual<string>("Wuuu", myStu.Name);
        }

        [TestMethod()]
        public void ChangeReferenceTest()
        {
            Student myStu = new Student()
            {
                ID = 325,
                Name = "Wu",
                Age = 3
            };

            PassParamsByRef_Reference passParams = new PassParamsByRef_Reference();
            Student newStu = passParams.ChangeReference(ref myStu);

            Assert.AreSame(myStu, newStu);  // True
            Assert.AreEqual<int>(myStu.ID, newStu.ID);  // True
            Assert.AreNotEqual<int>(325, myStu.ID);    // True
        }
    }
}