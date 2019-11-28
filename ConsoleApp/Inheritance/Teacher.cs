using System;

namespace Inheritance
{
    public class Teacher : Staff
    {
        public Teacher(string staffNo, string name, Gender gender, DateTime birthday)
            : base(staffNo, name, gender, birthday)
        {

        }

        public void Teaching()
        {
            System.Console.WriteLine("Teacher {0}({1}) is {2} years old. {3} is teaching...", 
                this.Name, this.StaffNo, this.Age, this.GenderPronoun);
        }
    }
}