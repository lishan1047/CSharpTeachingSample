using System;
using OOPSimple;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person aPerson = new Person();
            aPerson.Name = "某个人";

            Person xiaoming = new Person();
            xiaoming.Name = "小明";
            Person xiaohong = new Person();
            xiaohong.Name = "小红";

            Console.WriteLine(aPerson.Name);
            Console.WriteLine(xiaoming.Name);
            Console.WriteLine(xiaohong.Name);
        }
    }
}