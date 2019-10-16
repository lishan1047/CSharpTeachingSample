using System;

namespace OOPSimple
{
    public class Circle
    {
        public double Radius;
        public double GetArea()
        {
            return 3.14 * this.Radius * this.Radius;
        }
    }

    public class CircleTest
    {
        public static void Test()
        {
            Circle c = new Circle(){
                Radius = 3.5
            };
            System.Console.WriteLine("The Circle's Radius is {0}, It's area is {1}.",
                c.Radius, c.GetArea());
        }
    }
}