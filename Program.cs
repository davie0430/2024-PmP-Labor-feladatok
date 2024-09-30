using System.Collections.Generic;

namespace lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1. feladat:
            string[] szinek = { "Kőr", "Káró", "Treff", "Pikk" };
            string[] magassag = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász" };
            string[] kartyak = new string[52];
            int count = 0;
            for (int i = 0; i < szinek.Length; i++)
            {
                for (int j = 0; j < magassag.Length; j++)
                {
                    kartyak[count++] = $"{szinek[i]} {magassag[j]}";
                }
            }
            //foreach (string kartya in kartyak)
            //{
            //    Console.WriteLine(kartya);
            //}

            //2. feladat:
            Random random = new Random();
            int rand;
            string temp;
            for (int i = 0; i < kartyak.Length - 1; i++)
            {
                rand = random.Next(i, 52);
                temp = kartyak[i];
                kartyak[i] = kartyak[rand];
                kartyak[rand] = temp;
            }
            //egyszerubb csere:
            //(kartyak[i], kartyak[j]) = (kartyak[j], kartyak[i]);

            foreach (string kartya in kartyak)
            {
                Console.WriteLine(kartya);
            }

            //3. feladat:
            Console.Write("Adj meg 3 darab szót: ");
            string[] szavak = new string[3];
            int count = 0;
            while (count < 3)
            {
                szavak[count++] = Console.ReadLine();
            }
            Console.Write("Kerek egy további szót: ");
            string ujSzo = Console.ReadLine();

            int index = 0;
            //Array.IndexOf(szavak, keresttSzo);
            foreach (string szo in szavak)
            {
                if (ujSzo == szo) { Console.WriteLine($"Benne van, {index + 1}. szó lesz az"); return; }
                index++;
            }
            Console.WriteLine("Nincs benne a tömbben.");

            //5. feladat:
            string nev;
            int eletkor;
            bool tapasztalat;
            int emberekSzama = 0;

            List<string> nevek = new List<string>();
            List<int> eletkorok = new List<int>();
            List<bool> tapasztalatok = new List<bool>();


            while (true)
            {
                Console.Write("Mi a neved? ");
                nev = Console.ReadLine();
                if (nev == "") break;
                nevek.Add(nev);

                Console.Write("Hány éves vagy? ");
                eletkor = int.Parse(Console.ReadLine());
                eletkorok.Add(eletkor);

                Console.Write("Rendelkezel programozói tapasztalattal? ");
                tapasztalat = bool.Parse(Console.ReadLine());
                tapasztalatok.Add(tapasztalat);

            }

            double atlag = 0;
            double tatlag = 0;
            int hanyTapasztalatlan = 0;
            int legidosebbTapasztalt = 0;
            string legidosebbTapasztaltNeve = "\0";

            foreach (int eletk in eletkorok)
            {
                atlag += eletk;

            }
            atlag = atlag / eletkorok.Count;

            for (int i = 0; i < eletkorok.Count; i++)
            {
                tatlag += eletkorok[i];
                if (tapasztalatok[i] == false) { hanyTapasztalatlan++; } else { if (legidosebbTapasztalt < eletkorok[i]) { legidosebbTapasztalt = eletkorok[i]; legidosebbTapasztaltNeve = nevek[i]; } }
            }
            tatlag = tatlag / hanyTapasztalatlan;

            Console.WriteLine($"Atlageletkor = {atlag}");
            Console.WriteLine($"Atlageletkor a tapasztalattal nem rendelkezoknel = {tatlag}");
            Console.WriteLine($"A legidősebb és tapasztalt ember neve: {legidosebbTapasztaltNeve}, életkora: {legidosebbTapasztalt}");

            //6. feladat:
            int N = 3;
            int M = 4;
            int[,] ketDimenzios = new int[N, M];
            int[,] ketDimanzios2 = new int[,] { { 3, 7, 9 },
                                                { 4, 6, 5 },
                                                { 5, 3, 4 } };
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    ketDimenzios[i, j] = random.Next(0, 10);
                }
            }

            for (int i = 0; i < ketDimenzios.GetLength(0); i++)
            {
                for (int j = 0; j < ketDimenzios.GetLength(1); j++)
                {
                    Console.Write($"{ketDimenzios[i, j]} ");
                }
                Console.WriteLine();
            }

            int[,] transzponalt = new int[M, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    transzponalt[j, i] = ketDimenzios[i, j];
                }
            }

            Console.WriteLine();

            for (int i = 0; i < transzponalt.GetLength(0); i++)
            {
                for (int j = 0; j < transzponalt.GetLength(1); j++)
                {
                    Console.Write($"{transzponalt[i, j]} ");
                }
                Console.WriteLine();
            }

            //8. feladat:
            List<int> list = new List<int>();
            int K = 0;
            while (K != 1)
            {
                Console.Write("Adj meg egy pozitiv egesz szamot! ");
                K = int.Parse(Console.ReadLine());
                list.Add(K);
                if (K % 2 == 0)
                {
                    list.Add(K / 2);
                }
                else
                {
                    list.Add(3 * K + 1);
                }
            }
            foreach (int i in list) { Console.Write($"{i} "); }

            //9. feladat:
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int i = 0; i < 4; i++)
            {
                int tmp = x[i];
                x[i] = x[x.Length - i - 1];
                x[x.Length - i - 1] = tmp;
            }
            foreach (int a in x) { Console.Write($"{a} "); }
        }
    }

}