using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassParamsByRefOrValue
{
    public class PassParamsByRef_Struct
    {

    }

    public class PassParamsByRef_Reference
    {
        public void UpdateValue(ref Student stu)
        {
            stu.Name = "Wuuu";
        }

        public Student ChangeReference(ref Student stu)
        {
            stu = new Student()
            {
                ID = 001,
                Name = "Test",
                Age = -1
            };

            return stu;
        }
    }
}
