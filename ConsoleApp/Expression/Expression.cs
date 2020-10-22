using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp.Expression
{
    public class ExpressionTest
    {
        public static void Test()
        {
            double a = 0.5;
            var x = a + 2 / 3 > 2;
            Console.WriteLine("x : {0}", x);
        }

        public static void Test01()
        {
            int a = 5, b = 4, c = 6, d;
            Console.WriteLine("{0}", d = a > b ? (a > c ? a : c) : b);
        }

        public static void Test02()
        {
            byte a = 2, b = 5;
            Console.WriteLine("{0}", a ^ b);
        }

        public static void Test03()
        {
            int a = 3, b = 4, c = 5;
            Console.WriteLine("{0}", (++a-1) & b + c /2 );
        }

        public static void Test04()
        {
            int a = 2, b = 3; float x = 3.5f, y = 2.5f;
            Console.WriteLine("{0}", (float)(a + b) / 2 + (int)x % (int)y );
        }

        public static void Test05()
        {
            int a = 5, b = 10, c = 15, Max = 0;
            Max = a > b ? a: b;
            Max = c < Max ? c : Max;
            Console.WriteLine("{0}", Max);
        }
    }
}