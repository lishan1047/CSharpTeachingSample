using System;

namespace Inheritance
{
    public class Student : Person
    {
        public Student(string studentNo, string name, Gender gender, DateTime birthday)
            : base(name, gender, birthday)
        {
            this.StudentNo = studentNo;
        }
        public string StudentNo
        {
            get;
            private set;
        }

        public void Study()
        {
            System.Console.WriteLine("Student {0}({1}) is {2} years old. {3} is studying...", 
                this.Name, this.StudentNo, this.Age, this.GenderPronoun);
        }
    }
}