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
        int thirdPowerBase;
        int secondPowerBase;
        int firstPowerBase;
        int lastNumber;
        int x;
        List<int> dzielniki;
        Number thirdPower;
        Number secondPower;
        Number firstPower;

        public Polynomial(int tPN, int sPN, int fPN, int ln)
        {
            thirdPowerBase = tPN;
            secondPowerBase = sPN;
            firstPowerBase = fPN;
            lastNumber = ln;
            Number thirdPower = new Number(thirdPowerBase, 3);
            Number secondPower = new Number(secondPowerBase, 2);
            Number firstPower = new Number(firstPowerBase, 1);

        }

        public Polynomial(int tPN, int sPN, int fPN, int ln, int _x)
        {
            thirdPowerBase = tPN;
            secondPowerBase = sPN;
            firstPowerBase = fPN;
            lastNumber = ln;
            x = _x;
            Number thirdPower = new Number(thirdPowerBase, 3);
            Number secondPower = new Number(secondPowerBase, 2);
            Number firstPower = new Number(firstPowerBase, 1);
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

                if(thirdPowerBase*x*x*x + secondPowerBase*x*x + firstPowerBase*x + lastNumber == 0)
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
            int zmiejszenie_stopnia = (thirdPowerBase * x * x * x + secondPowerBase * x * x + firstPowerBase * x + lastNumber) / (x + czynnik1);
            Console.WriteLine(zmiejszenie_stopnia);
            //int wynik1 = (x + czynnik1) * (x + czynnik2) * (x + czynnik3);
            int wynik2 = thirdPowerBase * x * x * x + secondPowerBase * x * x + firstPowerBase * x + lastNumber;
        }

        public void Value()
        {
            float wynik = thirdPowerBase * x * x * x + secondPowerBase * x * x + firstPowerBase * x + lastNumber;
            Console.WriteLine(wynik);
        }

        public void Multiplicate(Polynomial _poly2)
        {
            thirdPowerBase*= _poly2.thirdPowerBase;
            secondPowerBase *= _poly2.secondPowerBase;
            firstPowerBase *= _poly2.firstPowerBase;
            lastNumber *= _poly2.lastNumber;
        }

        public void Write()
        {
            Console.WriteLine(thirdPowerBase.ToString() + "x^3 + " +secondPowerBase.ToString() + "x^2 + " + firstPowerBase.ToString() + "x + " + lastNumber.ToString() + " = ");
        }

        public void WriteWynik()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wynik działania: " + thirdPowerBase.ToString() + "x^3 + " + secondPowerBase.ToString() + "x^2 + " + firstPowerBase.ToString() + "x + " + lastNumber.ToString());
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

