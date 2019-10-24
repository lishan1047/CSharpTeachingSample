using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OOPSimple.PersonTest.Test();
            OOPSimple.DogTest.Test();
            OOPSimple.CircleTest.Test();

            Capsulation.PersonTest.Test();
            Capsulation.BoxTest.Test();

            Capsulation.CalculatorTest.Test();
        }
    }
}
