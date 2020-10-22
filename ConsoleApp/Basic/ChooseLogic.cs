using System;

namespace ConsoleApp.Basic
{
    public class ChooseLogic
    {
        public static void Test()
        {
            Console.Write("今天天气好吗？");
            int weather = Convert.ToInt32(Console.ReadLine());
            //int shopping = 0;
            if(weather == 1)
            {
                //shopping = 1;
                Console.WriteLine("Shopping...");
            }
            else
            {
                Console.Write("有人来叫我 Play basketball？");
                int ask = Convert.ToInt32(Console.ReadLine());
                //int playball = 0;
                //int sleeping = 0;
                if(ask == 1)
                {
                    //playball = 1;
                    //sleeping = 0;
                    Console.WriteLine("Play basketball...");
                }
                else
                {
                    //playball = 0;
                    //sleeping = 1;
                    Console.WriteLine("Sleeping...");
                }
            }
        }
    }
}