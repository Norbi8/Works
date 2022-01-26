using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki2017
{
    class Mukorcsolya {
        public string nev;
        public string orsz;
        public double techn;
        public double komp;
        public int levon;
        public Mukorcsolya(string nev,string orsz,double techn,double komp,int levon){
            this.nev = nev;
            this.orsz = orsz;
            this.techn = techn;
            this.komp = komp;
            this.levon = levon;
        }
    }

    class DontOrszag
    {
        public string nev;
        public int db;
        public DontOrszag(string nev,int db) {
            this.nev = nev;
            this.db = db;
        }
    
    }

    class Program
    {
        static List<Mukorcsolya> Rovidp = new List<Mukorcsolya>();
        static List<Mukorcsolya> Donto = new List<Mukorcsolya>();
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("rovidprogram.csv");
            f.ReadLine();
            while (!f.EndOfStream) {
                string[] sv = f.ReadLine().Split(';');
                Rovidp.Add(new Mukorcsolya(sv[0],sv[1],Convert.ToDouble(sv[2]),Convert.ToDouble(sv[3]),Convert.ToInt32(sv[4])));
            }
            f.Close();

            StreamReader r = new StreamReader("donto.csv"); 
            r.ReadLine();
            while (!r.EndOfStream)
            {
                string[] sv = r.ReadLine().Split(';');
                Donto.Add(new Mukorcsolya(sv[0], sv[1], Convert.ToDouble(sv[2]), Convert.ToDouble(sv[3]), Convert.ToInt32(sv[4])));
            }
            r.Close();
            Console.WriteLine("2.feladat\n\tA rövdiprogramban {0} induló volt.",Rovidp.Count());
            int x = 0;
            while (x < Donto.Count() && Donto[x].orsz != "HUN") {
                x++;
            }
            if (x < Donto.Count())
            {
                Console.WriteLine("3.feladat\n\tA magyar versenyző bejutott a kűrbe");
            }
            else {
                Console.WriteLine("3.feladat\n\tA magyar versenyző nem jutott a kűrbe");
            }
            Console.Write("5.feladat\n\tKérem a versenyző nevét! ");
            string benev = Console.ReadLine();
            x = 0;
            while (x < Rovidp.Count()&& Rovidp[x].nev!=benev) {
                x++;
            }
            if (x< Rovidp.Count())
            {
                Console.WriteLine("6.feladat\n\tA versenyző összpontszáma: {0}", ÖsszPontszam(benev));
            }
            else {
                Console.WriteLine("\tIlyen nevű induló nem volt");
            }

            List<DontOrszag> orszagok = new List<DontOrszag>();
            for (int i = 0; i < Donto.Count(); i++)
            {
                bool vane = false;
                int mentj=0;
                for (int j = 0; j < orszagok.Count; j++)
                {
                    if (Donto[i].orsz ==orszagok[j].nev) {
                        vane = true;
                        mentj = j;
                    }
                }
                if (vane == false)
                {
                    orszagok.Add(new DontOrszag(Donto[i].orsz, 1));
                }
                else {
                    orszagok[mentj].db++;
                }
            }
            Console.WriteLine("7.feladat");
            for (int i = 0; i < orszagok.Count(); i++)
            {
                if (orszagok[i].db > 1) {
                    Console.WriteLine("\t{0} {1}", orszagok[i].nev, orszagok[i].db);
                }
            }
            //rendezés
            for (int i = 0; i < Donto.Count()-1; i++)
            {
                for (int j = i+1; j < Donto.Count(); j++)
                {
                    if (ÖsszPontszam(Donto[i].nev) < ÖsszPontszam(Donto[j].nev)) {
                        Mukorcsolya ment = new Mukorcsolya(Donto[j].nev,Donto[j].orsz,Donto[j].techn,Donto[j].komp,Donto[j].levon);
                        Donto[j] = Donto[i];
                        Donto[i] = ment;
                    }
                }
            }

            StreamWriter sw = new StreamWriter("vegeredmeny.csv");
            for (int i = 0; i < Donto.Count(); i++)
            {
                sw.WriteLine("{0};{1};{2};{3}",i+1,Donto[i].nev,Donto[i].orsz,ÖsszPontszam(Donto[i].nev));
            }
            sw.Close();
            Console.ReadLine();
        }
        static double ÖsszPontszam(string nev) {
            double pontszam = 0;
            for (int i = 0; i < Rovidp.Count; i++)
            {
                if (Rovidp[i].nev == nev) {
                    pontszam = Rovidp[i].komp + Rovidp[i].techn - Rovidp[i].levon;
                }
            }
            for (int i = 0; i < Donto.Count; i++)
            {
                if (Donto[i].nev == nev)
                {
                    pontszam += Donto[i].komp + Donto[i].techn - Donto[i].levon;
                }
            }
            return pontszam;
        }
    }
}
