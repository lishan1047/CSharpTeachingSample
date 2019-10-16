using System;

namespace OOPSimple
{
    public class Person
    {
        public string Name;
        public string Gender;
        public string GetName(){
            return this.Name;
        }
        public string GetGender(){
            return this.Gender;
        }
    }

    /// <summary>
    /// This sample shows the basic OOP.
    /// </summary>
    public class PersonTest
    {
        public static void Test(){
            Person p = new Person();
            p.Name = "Liu";
            p.Gender = "Male";
            System.Console.WriteLine("{0} is {1}", p.GetName(), p.GetGender());
        }
    }
}
