/*
封装：隐藏对象行为细节，只向外界提供可操纵的接口。
技术：
（1）属性化；
（2）访问控制；
（3）构造函数；
（4）方法/函数；
（5）接口化
 */

namespace Capsulation
{
    /// <summary>
    /// 技术：
    /// （1）属性化；
    /// （2）访问控制；
    /// （3）构造函数；
    /// </summary>
    public class Person
    {
        public Person(string name, string gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Gender
        {
            get;
            private set;
        }

        public int Age
        {
            private get;
            set;
        }
    }

    public class PersonTest
    {
        public static void Test()
        {
            Person p = new Person("Zhang", "男");

            p.Age = 8;

            System.Console.WriteLine("{0} is {1}.", p.Name, p.Gender);
        }
    }
}