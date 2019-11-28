using System;

namespace Inheritance
{
    public class PersonTest
    {
        public static void Test()
        {
            Student s = new Student("20170410070101", "Zhang", Gender.Female, new DateTime(1999,3,4));
            s.Study();
            Instructor i = new Instructor("1088", "Liu", Gender.Female, new DateTime(1985,6,3));
            i.CheckDorm();
            Tutor t = new Tutor("1047", "Li", Gender.Male, new DateTime(1977,2,19));
            t.Teaching();
            t.CheckThesis();
            RepeatStudent rs = new RepeatStudent("20140410070103", "Chen", Gender.Male, new DateTime(1996,5,6));
            rs.RepeatStudy();
        }
    }
}