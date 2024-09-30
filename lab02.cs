using System;

namespace lab02
{
    internal class Program
    {
        public enum Allapot
        {
            None,
            Vesztes,
            KettoEgyezik,
            HaromEgyezik
        }
        static void Main(string[] args)
        {
            //1.feladat:
            Console.Write("N = ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i < num; i++)
            {
                if (i % 2 == 0) Console.Write($"{i} ");
            }
            //2.feladat:
            string jelszo = "jelszo";
            int count = 0;
            do
            {
                count++;
                if (jelszo == Console.ReadLine())
                {
                    break;
                }
            } while (count < 3);
            Console.Write("Hiba");

            //3.feladat
            Console.Write("N = ");
            int num = int.Parse(Console.ReadLine());
            Random random = new Random();
            int count = 1;
            while (random.Next(1, 1000) != num)
            {
                count++;
            }
            Console.WriteLine($"Probalkozasok szama = {count}");

            //4.feladat
            Console.Write("N = ");
            int num = int.Parse(Console.ReadLine());
            Random random = new Random();
            bool kezdes = false;
            while (!kezdes)
            {
                for (int i = 1; i <= num; i++)
                {
                    int dobas = random.Next(1, 7);

                    Console.ReadLine();
                    if (dobas == 6)
                    {
                        Console.Write($"{i}. jatekos kezd. Dobasa: {dobas}");
                        kezdes = true;
                        break;
                    }
                    else
                    {
                        Console.Write($"{i}. jatekos dobasa: {dobas}");
                    }

                }
            }

            //5.feladat:
            Random random = new Random();
            double gondolat = random.Next();
            Console.Write("Gondoltam egy szamot. Talald ki: ");
            Console.WriteLine(gondolat);
            double otlet;
            double probalkozas = 0;
            while (true)
            {
                probalkozas++;
                otlet = double.Parse(Console.ReadLine());
                if (otlet == gondolat)
                {
                    Console.Write($"Kitalaltad, gratulalok. A gondolt szam = {gondolat} volt.");
                    break;
                }
                else if (otlet > gondolat)
                {
                    Console.Write("A gondolt szam kissebb. Kovi otlet? ");
                }
                else
                {
                    Console.Write("A gondolt szam nagyobb. Kovi otlet? ");
                }
            }

            //6.feladat:
            Console.Write("N = ");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine("Paros");
            }
            else
            {
                Console.WriteLine("Paratlan");
            }
            int osztok = 0;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0) osztok++;
            }
            Console.WriteLine($"Osztok szama = {osztok}");
            if (osztok == 0) { Console.WriteLine("Prim"); } else { Console.WriteLine("Nem prim"); }

            //7.feladat:
            Console.Write("N = ");
            int num = int.Parse(Console.ReadLine());
            Console.Write($"{num}! = {num}");
            int ans = 1;
            for (int i = num - 1; i != 0; i--)
            {
                Console.Write($"*{i}");
                ans *= i + 1;
            }
            Console.Write($" = {ans}");

            //8.feladat:
            Console.Write($"       ");
            for (int i = 1; i < 10; i++)
            {
                Console.Write($" {i.ToString("D2")} ");
            }

            Console.Write("\n       ");

            for (int i = 1; i < 10; i++) { Console.Write(" -- "); }

            Console.Write("\n");

            int k = 1;
            for (int i = 1; i < 10; i++)
            {
                Console.Write($" {k.ToString("D2")} ");
                Console.Write(" | ");
                k++;
                for (int j = 1; j < 10; j++)
                {
                    Console.Write($" {(i * j).ToString("D2")} ");
                }
                Console.Write("\n");
            }

            //9.feladat:
            Console.Write("masodperc = ");
            int masodperc = int.Parse(Console.ReadLine());
            while (masodperc != 0)
            {
                Console.Clear();
                int perc = masodperc / 60;
                int maradek = masodperc - perc * 60;
                Console.Write($"{perc.ToString("D2")}:{maradek.ToString("D2")}");
                System.Threading.Thread.Sleep(1000);
                masodperc--;
            }

            //11. feladat:
            int kredit = 100;
            int tet = 1;
            ConsoleKeyInfo key;
            Random random = new Random();
            bool jatek = true;
            int x = 0, y = 0, z = 0;
            Allapot Jatek = Allapot.None;
            while (kredit > 0 && jatek)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine($"{x} | {y} | {z}");
                    if (Jatek != Allapot.Vesztes) Console.WriteLine($"{(int)Jatek} ugyan olyan.");
                    Console.WriteLine($"Jelenlegi Kredit = {kredit}");
                    Console.Write($"Mostani tet: {tet}");
                    key = Console.ReadKey();
                    if (ConsoleKey.Escape == key.Key) { jatek = false; break; }
                    if (ConsoleKey.DownArrow == key.Key && tet > 0) { tet--; } else if (ConsoleKey.UpArrow == key.Key && tet < kredit) { tet++; }

                } while (key.Key != ConsoleKey.Spacebar || ConsoleKey.Escape == key.Key);

                if (!jatek)
                {
                    break;
                }

                x = random.Next(1, 11);
                y = random.Next(1, 11);
                z = random.Next(1, 11);

                if (x == y || x == z || y == z)
                {
                    if (x == y && y == z)
                    {
                        Jatek = Allapot.HaromEgyezik; 
                        kredit = kredit + tet * 10;
                    }
                    Jatek = Allapot.KettoEgyezik; 
                    kredit = kredit + tet * 2;
                }
                else
                {
                    Jatek = Allapot.Vesztes;
                    kredit = kredit - tet;
                }
            }
        }
    }
}
