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
        static List<string> Adatok = new List<string>();
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("test.txt");
            int szam = Convert.ToInt32(f.ReadLine());
            
            while (!f.EndOfStream)
            {
                /*string[] sv = f.ReadLine().Split(' ');
                for (int i = 0; i < sv.Length; i++)
                {
                    Adatok.Add(Convert.ToInt32(sv[i]));
                }*/
            }
            f.Close();

            string msh = "bcdfghjklmnprstvwxz";
            string mgh = "aeiou ";
            int A = 445;
            int C = 700001;
            int M = 2097152;
            int Mszam;

            for (int i = 0; i < 900000; i++)
            {
                int n = 0;
                string VegSzo = "";
                while (n < 6)
                {
                    szam = (A * szam + C) % M;
                    if (n % 2 == 0)
                    {
                        Mszam = szam % 19;
                        VegSzo += msh[Mszam];
                    }
                    else
                    {
                        Mszam = szam % 5;
                        VegSzo += mgh[Mszam]; ;
                    }
                    n++;
                }
                Adatok.Add(VegSzo);
            }
            Adatok.Sort();
            string akt = Adatok[0];
            int aktdb = 1;
            int aktMaxdb = 0 ;
            string aktMax="";
            for (int i = 1; i < Adatok.Count()-1; i++)
            {
                if (akt == Adatok[i + 1])
                {
                    aktdb++;
                }
                else {
                    if (aktdb > aktMaxdb) {
                        aktMax = akt;
                        aktMaxdb = aktdb;
                    }
                    akt = Adatok[i + 1];
                    aktdb = 1;
                }
            }

            Console.WriteLine(aktMax);
            Console.ReadLine();
        }
    }
}