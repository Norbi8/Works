using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VasMegye
{
    class Program
    {
        static List<string> Adatok = new List<string>();
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("vas.txt");
            while (!f.EndOfStream) {
                Adatok.Add(f.ReadLine());
            }
            f.Close();
            Console.WriteLine("2. feladat: Adatok beolvasása,tárolása");
            Console.WriteLine("4. feladat: Ellenőrzés");
            for (int i = 0; i < Adatok.Count(); i++)
            {
                if (!CdvElls(Adatok[i])) {
                    Console.WriteLine("\tHibás a {0} személyi azonosító!",Adatok[i]);
                    Adatok.Remove(Adatok[i]);
                    i--;
                }
            }
            Console.WriteLine("5. feladat: Vas megyében a vizsgált évek alatt {0} csecsemő született",Adatok.Count());

            Console.WriteLine("6. feladat: Fiúk száma: {0}",FiukSzamol());


            DateTime min = KovertDate(Adatok[0]);
            DateTime max = KovertDate(Adatok[0]);
            for (int i = 1; i < Adatok.Count(); i++)
            {
                if (min > KovertDate(Adatok[i])) {
                    min = KovertDate(Adatok[i]);
                }

                if (max < KovertDate(Adatok[i]))
                {
                    max = KovertDate(Adatok[i]);
                }
            }

            Console.WriteLine("7. feladat: Vizsgált időszak: {0} - {1}",min.ToString("yyyy"), max.ToString("yyyy"));

            int x = 0;
            while (x<Adatok.Count() && !(KovertDate(Adatok[x]).Year % 4 == 0 && KovertDate(Adatok[x]).Month==2 && KovertDate(Adatok[x]).Day == 24)) {
                x++;
            }
            if (x < Adatok.Count())
            {
                Console.WriteLine("8. feladat : Szőkőnapon született baba!");
            }
            else
            {
                Console.WriteLine("8. feladat : Szőkőnapon NEM született baba!");
            }

            Console.WriteLine("9. feladat : Statisztika");
            List<DateTime> Evek = new List<DateTime>();
            for (int i = 0; i < Adatok.Count(); i++)
            {
                bool joe = true;
                for (int j = 0; j < Evek.Count(); j++)
                {
                    if (KovertDate(Adatok[i]).Year == Evek[j].Year) {
                        joe = false;
                    }
                }
                if (joe) {
                    Evek.Add(KovertDate(Adatok[i]));
                }
            }


            for (int i = 0; i < Evek.Count(); i++)
            {
                int fo = 0;
                for (int j = 0; j < Adatok.Count(); j++)
                {
                    if (Evek[i].Year == KovertDate(Adatok[j]).Year) {
                        fo++;
                    }
                }
                Console.WriteLine("\t{0} - {1} fő",Evek[i].Year,fo);
            }

            Console.ReadLine();
        }

        static DateTime KovertDate(string sor) {
            string datum = "";
            string[] sv = sor.Split('-');
            for (int i = 0; i < sv[1].Length; i++)
            {
                datum += sv[1][i];
                if (i == 1 || i == 3)
                {
                    datum += ".";
                }
            }
            return Convert.ToDateTime(datum);
        }
        static int FiukSzamol() {
            int db = 0;
            for (int i = 0; i < Adatok.Count(); i++)
            {
                if (Adatok[i][0]=='1' || Adatok[i][0] == '3') {
                    db++;
                }
            }
            return db;
        }
        static bool CdvElls(string azonosito) {
            azonosito = azonosito.Replace("-","");
            int szam = 0;
            for (int i = 0; i < azonosito.Length - 1; i++)
            {
                szam += Convert.ToInt32(azonosito[i])*(azonosito.Length-1-i);
            }
            szam = szam % 11;
            if (szam == azonosito[azonosito.Length-1]-'0') {
                return true;
            }
            return false;
        }
    }
}
