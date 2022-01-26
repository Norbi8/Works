using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace advent
{
    class szamok
    {
        public int ertek;
        public List<int> indexek;
        public szamok(int ertek, int Index)
        {
            this.ertek = ertek;
            indexek = new List<int>();
            indexek.Add(Index);
        }
    }

    class Program
    {
        static int n;
        static void Main(string[] args)
        {

            List<szamok> Lista = new List<szamok>();
            //Dictionary <int, List<int> > konyvtar = new Dictionary<int, List<int>>();
            StreamReader f = new StreamReader("adat.txt");
            while (!f.EndOfStream)
            {
                string sor = f.ReadLine();
                string[] sv = sor.Split(',');
                n = sv.Length;
                for (int i = 0; i < n; i++)
                {
                    Lista.Add(new szamok(Convert.ToInt32(sv[i]), i));
                    //konyvtar.Add(Convert.ToInt32(sv[i]), new List<int>  { i });
                }
            }
            f.Close();

            int Last = 0;
            int eredmeny = 0;
            for (int i = n; i < 30000000; i++)
            {
                //var lekerdez = Lista.Where(c => c.ertek == Last).ToList();
                int hol = Lista.FindIndex(c => c.ertek == Last);
                if (hol > -1)
                {
                    //int hol = Holvolt(Last);
                    Lista[hol].indexek.Add(i);
                    eredmeny = Last;
                    Last = Lista[hol].indexek[Lista[hol].indexek.Count() - 1] - Lista[hol].indexek[Lista[hol].indexek.Count() - 2];
                    Lista[hol].indexek.RemoveAt(0); 
                }
                else
                {
                    Lista.Add(new szamok(Last, i));
                    eredmeny = Last;
                    Last = 0;
                }
                Console.Write(i+" ");
            }

           /*foreach (var adat in Lista)
            {
                Console.Write("ertek: " + adat.ertek + " index(ek): ");
                for (int i = 0; i < adat.indexek.Count(); i++)
                {
                    Console.Write((adat.indexek[i]+1) + ",");
                }
                Console.WriteLine();
            }*/

            Console.WriteLine("Eredmény:" + eredmeny);

            Console.ReadLine();
        }
    }
}