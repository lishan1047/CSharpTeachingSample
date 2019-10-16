using System;

namespace OOPSimple
{
    public class Dog
    {
        public string Name;
        public string Gender;
        public string Further;
        public int Age;
        public string Bark(){
            return string.Format("{0} is a {2} {1} dog. It is {3} years old. It is barking...", 
                this.Name, this.Gender, this.Further, this.Age);
        }
    }

    public class DogTest
    {
        public static void Test()
        {
            Dog dog1 = new Dog(){
                Name = "毛毛",
                Gender = "公",
                Further = "金色",
                Age = 3
            };
            System.Console.WriteLine(dog1.Bark());
        }
    }
}
