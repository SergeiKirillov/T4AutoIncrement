using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberYear = (int)DateTime.Now.Year;
            int NumberMonth = (int)DateTime.Now.Month;
            int day = (int)DateTime.Now.Day;

            int NumberMinut = ((int)DateTime.Now.Hour * 60) + ((int)DateTime.Now.Minute);

            Console.WriteLine("Время действовать.");

            Console.ReadLine();

        }
    }
}
