using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_C_
{
    internal class Student
    {
        public Student()
        {
            Console.WriteLine("hello in Student Class");
        }
        private string name;
        public string Name {  get; set; }
        private int age;
        public int Age
        {
            get
            {
               if(age >= 18)
                 return age;
               return 0;
            }
            set
            {
                if(value >=18)
                  age = value;
                else
                    Console.WriteLine("not allow");
            }
        }
    }
}
