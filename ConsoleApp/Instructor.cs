using System;

namespace Inheritance
{
    public class Instructor : Staff
    {
        public Instructor(string staffNo, string name, Gender gender, DateTime birthday)
            : base(staffNo, name, gender, birthday)
        {

        }

        public void CheckDorm()
        {
            System.Console.WriteLine("Instructor {0}({1}) is {2} years old. {3} is checking dorm...",
                this.Name, this.StaffNo, this.Age, this.GenderPronoun);
        }
    }
}