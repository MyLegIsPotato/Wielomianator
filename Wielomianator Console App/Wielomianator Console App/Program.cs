using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielomianator_Console_App
{
    class Number
    {
        int thirdPowerNumber;
        int secondPowerNumber;
        int firstPowerNumber;
        int lastNumber;
        List<int> dzielniki;

        public Number(int tPN, int sPN, int fPN, int ln)
        {
            thirdPowerNumber = tPN;
            secondPowerNumber = sPN;
            firstPowerNumber = fPN;
            lastNumber = ln;
        }

        public void ZnajdzDzielniki()
        {
            dzielniki = new List<int>();
            if (lastNumber >= 0)
            {
                for (int i = -Math.Abs(lastNumber); i <= lastNumber; i++)
                {
                    if (i != 0)
                    {
                        if (lastNumber % i == 0)
                        {
                            dzielniki.Add(i);
                            Console.WriteLine("Znaleziono dzielnik: " + i);
                        }
                    }
                }
            }

            if (lastNumber < 0)
            {
                for (int i = lastNumber; i >= lastNumber; i++)
                {
                    if (i != 0)
                    {
                        if (lastNumber % i == 0)
                        {
                            dzielniki.Add(i);
                            Console.WriteLine("Znaleziono dzielnik: " + i);
                        }
                    }
                }
            }
        }

        public void PorownajWynikDoZera()
        {
            int x;

            foreach (int dzielnik in dzielniki)
            {
                Console.WriteLine("Sprawdzam Dzielnik: " + dzielnik);
                x = dzielnik;

                if(thirdPowerNumber*x*x*x + secondPowerNumber*x*x + firstPowerNumber*x + lastNumber == 0)
                {
                    Console.WriteLine("Wynik: " + dzielnik);
                    Podziel(x, dzielnik);
                    break;
                }
            }
        }

        public void Podziel(int _x, int _dzielnik)
        {
            int x = _x;
            int dzielnik = _dzielnik;
            float wynik;

            wynik = (thirdPowerNumber * x * x * x + secondPowerNumber * x * x + firstPowerNumber * x + lastNumber) / (x - (dzielnik));
            Console.WriteLine("Wynik dzielenia: " + wynik);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int tPN, sPN, fPN, ln;
            Console.WriteLine("Wprowadź liczbę o trzeciej potędze:");
            tPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę o drugiej potędze:");
            sPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę bez potęgi:");
            fPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź wyraz wolny:");
            ln = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(tPN.ToString()+ "x^3 + " + sPN.ToString()+ "x^2 + " + fPN.ToString()+"x + " + ln.ToString());

            Number polynomial = new Number(tPN, sPN, fPN, ln);

            polynomial.ZnajdzDzielniki();
            polynomial.PorownajWynikDoZera();

            Console.ReadLine();
        }



    }
}

