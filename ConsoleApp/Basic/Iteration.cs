using System;

namespace ConsoleApp.Basic
{
    public class Iteration
    {
        public static void Test()
        {
            int s = 0;
            for(int i = 1; i <= 100; i++)
            {
                s += i;
            }
            Console.WriteLine($"S is : { s }");
        }
    }
}