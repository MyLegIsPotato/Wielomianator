using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielomianator_Console_App
{
    class Number
    {
        int _base;
        int _power;

        public Number(int numBase, int numPower)
        {
            _base = numBase;
            _power = numPower;
        }
    }

    class Polynomial
    {
        int thirdPowerNumber;
        int secondPowerNumber;
        int firstPowerNumber;
        int lastNumber;
        int x;
        List<int> dzielniki;

        public Polynomial(int tPN, int sPN, int fPN, int ln)
        {
            thirdPowerNumber = tPN;
            secondPowerNumber = sPN;
            firstPowerNumber = fPN;
            lastNumber = ln;
        }

        public Polynomial(int tPN, int sPN, int fPN, int ln, int _x)
        {
            thirdPowerNumber = tPN;
            secondPowerNumber = sPN;
            firstPowerNumber = fPN;
            lastNumber = ln;
            x = _x;
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
            foreach (int dzielnik in dzielniki)
            {
                Console.WriteLine("Sprawdzam Dzielnik: " + dzielnik);
                int x = dzielnik;

                if(thirdPowerNumber*x*x*x + secondPowerNumber*x*x + firstPowerNumber*x + lastNumber == 0)
                {
                    Console.WriteLine("Wynik: " + dzielnik);
                    Podziel(dzielnik);
                    break;
                }
            }
        }

        public void Podziel(int _dzielnik)
        {
            Console.WriteLine("Podaj przykładowego X, który nie jest: " + _dzielnik);
            int x = Convert.ToInt32(Console.ReadLine());
            int dzielnik = _dzielnik;
            int czynnik1;
            int czynnik2;
            int czynnik3;

            czynnik1 = -dzielnik;
            int zmiejszenie_stopnia = (thirdPowerNumber * x * x * x + secondPowerNumber * x * x + firstPowerNumber * x + lastNumber) / (x + czynnik1);
            Console.WriteLine(zmiejszenie_stopnia);
            //int wynik1 = (x + czynnik1) * (x + czynnik2) * (x + czynnik3);
            int wynik2 = thirdPowerNumber * x * x * x + secondPowerNumber * x * x + firstPowerNumber * x + lastNumber;
        }

        public void Value()
        {
            float wynik = thirdPowerNumber * x * x * x + secondPowerNumber * x * x + firstPowerNumber * x + lastNumber;
            Console.WriteLine(wynik);
        }

        public void Multiplicate(Polynomial _poly2)
        {
            thirdPowerNumber*= _poly2.thirdPowerNumber;
            secondPowerNumber *= _poly2.secondPowerNumber;
            firstPowerNumber *= _poly2.firstPowerNumber;
            lastNumber *= _poly2.lastNumber;
        }

        public void Write()
        {
            Console.WriteLine(thirdPowerNumber.ToString() + "x^3 + " +secondPowerNumber.ToString() + "x^2 + " + firstPowerNumber.ToString() + "x + " + lastNumber.ToString() + " = ");
        }

        public void WriteWynik()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wynik działania: " + thirdPowerNumber.ToString() + "x^3 + " + secondPowerNumber.ToString() + "x^2 + " + firstPowerNumber.ToString() + "x + " + lastNumber.ToString());
            Console.ResetColor();
        }
    }

    class Program
    {
        public static Polynomial ReadData()
        {
            Polynomial polynomial;

            int tPN, sPN, fPN, ln, x;
            Console.WriteLine("Wprowadź liczbę o trzeciej potędze:");
            tPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę o drugiej potędze:");
            sPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę bez potęgi:");
            fPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź wyraz wolny:");
            ln = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź wartość x:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(tPN.ToString() + "x^3 + " + sPN.ToString() + "x^2 + " + fPN.ToString() + "x + " + ln.ToString() + " = ");

            return polynomial = new Polynomial(tPN, sPN, fPN, ln, x); ;
        }

        public static Polynomial ReadDataNoX()
        {
            Polynomial polynomial;

            int tPN, sPN, fPN, ln, x;
            Console.WriteLine("Wprowadź liczbę o trzeciej potędze:");
            tPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę o drugiej potędze:");
            sPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź liczbę bez potęgi:");
            fPN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Wprowadź wyraz wolny:");
            ln = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(tPN.ToString() + "x^3 + " + sPN.ToString() + "x^2 + " + fPN.ToString() + "x + " + ln.ToString() + "= ");
            return polynomial = new Polynomial(tPN, sPN, fPN, ln); ;
        }

        static void Main(string[] args)
        {
                Console.WriteLine("Co chcesz zrobić?");
                Console.WriteLine("1. Obliczyć wartość wielomianu.");
                Console.WriteLine("2. Pomnożyć wielomian.");
                Console.WriteLine("3. Rozłożyć wielomian na czynniki.");
                Console.WriteLine("4. Zmienić kolor konsoli i tekstu.");


                switch (Convert.ToInt16(Console.ReadLine()))
                {
                    case 1:
                        {
                            Polynomial poly = ReadData();
                            poly.Value();
                            break;
                        }

                    case 2:
                        {
                            Polynomial poly1 = ReadDataNoX();
                            Console.WriteLine("Pierwszy wielomian:");
                            poly1.Write();
                            Polynomial poly2 = ReadDataNoX();
                            Console.WriteLine("Drugi wielomian:");
                            poly2.Write();
                            poly1.Multiplicate(poly2);
                            Console.WriteLine();
                            poly1.WriteWynik();
                            break;
                        }

                    case 3:
                        {
                        Polynomial poly1 = ReadData();
                        poly1.ZnajdzDzielniki();
                        poly1.PorownajWynikDoZera();
                        break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybierz kolor tła:");
                            Console.WriteLine("1. Czarny");
                            Console.WriteLine("2. Szary");
                            Console.WriteLine("3. Biały");
                            switch (Convert.ToInt16(Console.ReadLine()))
                            {
                                case 1:
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.WriteLine("Color Changed!");
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.BackgroundColor = ConsoleColor.Gray;
                                         Console.WriteLine("Color Changed!");
                                          break;
                                    }
                                case 3:
                                    {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Color Changed!");
                                    break;
                                    }

                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }


                Console.ReadLine();
            }
        }
}

