using System;

namespace ConsoleApp.Basic
{
    public class Function
    {
        /// <summary>
        /// 求和函数。
        /// </summary>
        /// <param name="from">起始值。</param>
        /// <param name="to">终止值。</param>
        /// <returns>求和的结果。</returns>
        public static int Sum(int from, int to)
        {
            return Sum(from, to, 1);
        }
        /// <summary>
        /// 函数重载。
        /// </summary>
        /// <param name="from">起始值。</param>
        /// <param name="to">终止值。</param>
        /// <param name="step">步长。</param>
        /// <returns>求和的结果。</returns>
        public static int Sum(int from, int to, int step)
        {
            int s = 0;
            for(int i = from; i <= to; i += step)
            {
                s += i;
            }
            return s;
        }

        public static double Average(int from, int to)
        {
            // 嵌套调用
            return 1.0 * Sum(from, to) / (to - from + 1);
        }

        public static void Test03()
        {
            double avg = Average(1, 4);
            Console.WriteLine($"1 - 3 的平均数：{avg}");
        }

        public static int Factorial(int x)
        {
            // 递归调用
            if(x <= 1) return 1;
            return Factorial(x - 1) * x;
        }

        public static void Test04()
        {
            int f = Factorial(3);
            Console.WriteLine($"3's Factorial: {f}");
            f = Factorial(5);
            Console.WriteLine($"5's Factorial: {f}");
        }

        public static int Power(int a, int x)
        {
            int s = 1;
            for(int i = 0; i < x; i++)
            {
                s *= a;
            }
            return s;
        }

        public static void OutputRect(int length, int width)
        {
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Console.Write($"* ");
                }
                Console.WriteLine();
            }
        }

        public static void Test02()
        {
            int s = Power(10, 2);
            Console.WriteLine($"10^2: {s}");

            //  复合调用
            s = Power(2, Power(2, 3));
            Console.WriteLine($"2^(2^3): {s}");
        }

        public static void Test01()
        {
            int s = Sum(1, 100);
            Console.WriteLine("从 1 加到 100：{0}", s);
            s = Sum(3, 1003);
            Console.WriteLine("从 3 加到 1003：{0}", s);
            Console.Write("输入求和起始值：");
            int from = Convert.ToInt32(Console.ReadLine());
            Console.Write("输入求和终止值：");
            int to = Convert.ToInt32(Console.ReadLine());
            s = Sum(from, to);
            Console.WriteLine("从 {0} 加到 {1}：{2}", from, to, s);
        }

        public static void Test()
        {
            Console.WriteLine($"{Sum(1,6,2)}");
        }
    }
}