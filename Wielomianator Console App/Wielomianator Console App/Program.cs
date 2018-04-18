using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielomianator_Console_App
{
    class Number
    {
        double thirdPowerNumber;
        double secondPowerNumber;
        double firstPowerNumber;
        double lastNumber;

        public Number(double tPN, double sPN, double fPN, double ln)
        {
            thirdPowerNumber = tPN;
            secondPowerNumber = sPN;
            firstPowerNumber = fPN;
            lastNumber = ln;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double tPN, sPN, fPN, ln;
            Console.WriteLine("Wprowadź liczbę o trzeciej potędze:");
            tPN = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę o drugiej potędze:");
            sPN = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę o bez potęgi:");
            fPN = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Wprowadź wyraz wolny:");
            ln = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(tPN.ToString()+ "x^3 + " + sPN.ToString()+ "x^2 + " + fPN.ToString()+"x + " + ln.ToString());

            Number polynomial = new Number(tPN, sPN, fPN, ln);

            Console.ReadLine();
        }


    }
}

