using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassParamsByRefOrValue
{
    public struct PassParamsByValue_Struct
    {

    }

    public class PassParamsByValue_Reference
    {
        public void UpdateValue(Student stu)
        {
            stu.Name = "Wuuu";
        }

        public Student ChangeReference(Student stu)
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
