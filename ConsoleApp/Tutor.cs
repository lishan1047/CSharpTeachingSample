using System;

namespace Inheritance
{
    public class Tutor : Teacher
    {
        public Tutor(string staffNo, string name, Gender gender, DateTime birthday)
            : base(staffNo, name, gender, birthday)
        {

        }

        public void CheckThesis()
        {
            System.Console.WriteLine("{0} is checking thesis...", this.GenderPronoun);
        }
    }
}