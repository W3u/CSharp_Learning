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
    public class PassParamsByValue_ReferenceTests
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

            PassParamsByValue_Reference passParams = new PassParamsByValue_Reference();
            passParams.UpdateValue(myStu);

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

            PassParamsByValue_Reference passParams = new PassParamsByValue_Reference();
            Student newStu = passParams.ChangeReference(myStu);

            Assert.AreNotSame(myStu, newStu);  // True
            Assert.AreNotEqual<int>(myStu.ID, newStu.ID);  // True
            Assert.AreEqual<int>(325, myStu.ID);    // True
        }
    }
}