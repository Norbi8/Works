using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

namespace code
{
    class Program
    {
        static int[,] tomb = new int[4,4];
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("test.txt");
            //f.ReadLine();
            List<char> Lepesek = new List<char>();
            int i = 0;
            while (!f.EndOfStream)
            {
                string[] sv = f.ReadLine().Split(' ');
                if (i < 4)
                {
                    for (int j = 0; j < sv.Length; j++)
                    {
                        tomb[i, j] = Convert.ToInt32(sv[j]);
                    }
                }
                else {
                    for (int j = 0; j < sv.Length; j++)
                    {
                        Lepesek.Add(Convert.ToChar(sv[j]));
                    }
                }
                i++;
            }
            f.Close();

            Kiir();

            for (int v = 0; v < Lepesek.Count(); v++)
            {
                if (Lepesek[v] == 'D') {
                    LepLe(); 
                }
                else if (Lepesek[v] == 'U')
                {
                    LepFel();
                }
                else if (Lepesek[v] == 'L')
                {
                    LepBal();
                }
                else if (Lepesek[v] == 'R')
                {
                    LepJobb();
                }
            }

            Kiir();
            List<int> Lista = new List<int>();
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (tomb[x, y] > 0) {
                        Lista.Add(tomb[x, y]);
                    }
                }
            }


            int kettes = Lista.Where(x => x == 2).Count();
            int negyes = Lista.Where(x => x == 4).Count();
            int nyolcas = Lista.Where(x => x == 8).Count();
            int thatos = Lista.Where(x => x == 16).Count();
            int harmickettes = Lista.Where(x => x == 32).Count();
            Console.WriteLine(kettes+" "+negyes+" "+nyolcas+" "+thatos+" "+harmickettes);
            Console.ReadLine();
        }


        static void CsereJobb()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (tomb[i, j] == 0)
                    {
                        if (tomb[i, j - 1] != 0)
                        {
                            tomb[i, j] = tomb[i, j - 1];
                            tomb[i, j - 1] = 0;
                            CsereJobb();
                        }
                    }
                }
            }
        }
        static void LepJobb()
        {
            for (int j = 3; j > 0; j--)// for (int i = 3; i > 0; i--)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (tomb[i, j] == tomb[i, j - 1])
                    {
                        int dupla = tomb[i, j] * 2;
                        tomb[i, j] = dupla;
                        tomb[i, j - 1] = 0;
                    }
                }
            }
            CsereJobb();
        }

        //

        static void CsereBal()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tomb[i, j] == 0) {
                        if (tomb[i,j+1] !=0 ) {
                            tomb[i, j] = tomb[i, j + 1];
                            tomb[i, j + 1] = 0;
                            CsereBal();
                        }
                    }
                }
            }
        }
        static void LepBal()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (tomb[i, j] == tomb[i, j + 1]) {
                        int dupla = tomb[i, j] * 2;
                        tomb[i, j] = dupla;
                        tomb[i, j+1] = 0;
                    }
                }
            }
            CsereBal();
        }


        static void CserelFel()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (tomb[i, j] == 0)
                    {
                        if (i < 3 && tomb[i + 1, j] != 0)
                        {
                            tomb[i, j] = tomb[i + 1, j];
                            tomb[i + 1, j] = 0;
                            CserelFel();
                        }
                    }
                }
            }
        }
        static void LepFel() {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tomb[i, j] == tomb[i + 1, j])
                    {
                        int dupla = tomb[i, j] * 2;
                        tomb[i, j] = dupla;
                        tomb[i + 1, j] = 0;
                    }
                }
            }
            CserelFel();
        }

        static void CserelLe() {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    if (tomb[i, j] == 0)
                    {
                        if (i > 0 && tomb[i-1,j]!=0)
                        {
                            tomb[i, j] = tomb[i - 1, j];
                            tomb[i - 1, j] = 0;
                            CserelLe();
                        }
                    }
                }
            }
        }
        static void LepLe() {
            for (int i = 3; i > 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tomb[i, j] == tomb[i-1, j]) {
                        int dupla = tomb[i, j]*2;
                        tomb[i, j] = dupla;
                        tomb[i - 1, j] = 0;
                    }
                }
            }
            CserelLe();
        }

        static void Kiir() {
            for (int i = 0; i < 4; i++)
            { 
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(tomb[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}