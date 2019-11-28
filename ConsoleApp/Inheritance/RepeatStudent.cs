using System;

namespace Inheritance
{
    public class RepeatStudent : Student
    {
        public RepeatStudent(string studentNo, string name, Gender gender, DateTime birthday)
            : base(studentNo, name, gender, birthday)
        {

        }

        public void RepeatStudy()
        {
            System.Console.WriteLine("Student {0}({1}) is {2} years old. {3} is studying repeatly...", 
                this.Name, this.StudentNo, this.Age, this.GenderPronoun);
        }
    }
}