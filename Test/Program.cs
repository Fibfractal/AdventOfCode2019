using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = (01234 % 100000) / 10000;
            var b = (1234 % 100000) / 1000;


            Console.WriteLine(b);
            Console.ReadLine();

        }
    }
}
