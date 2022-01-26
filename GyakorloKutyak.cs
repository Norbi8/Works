using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Kutyak
{
    class Kutyanevek{
        public int id;
        public string nev;
        public Kutyanevek(string sor) {
            string[] sv = sor.Split(';');
            id = Convert.ToInt32(sv[0]);
            nev = sv[1];
        }
    }

    class KutyaFajtak {
        public int id;
        public string fajta;
        public string nev;
        public KutyaFajtak(string sor) {
            string[] sv = sor.Split(';');
            id = Convert.ToInt32(sv[0]);
            fajta = sv[1];
            nev = sv[2];
        }
    }

    class Kutyak
    {
        public int id;
        public int fajtaid;
        public int nevid;
        public int kor;
        public string datum;
        public Kutyak(string sor)
        {
            string[] sv = sor.Split(';');
            id = Convert.ToInt32(sv[0]);
            fajtaid = Convert.ToInt32(sv[1]);
            nevid = Convert.ToInt32(sv[2]);
            kor = Convert.ToInt32(sv[3]);
            datum = sv[4];
        }
    }

    class KutyaNevekdb {
        public string nev;
        public int db;
        public KutyaNevekdb(string nev,int db) {
            this.nev = nev;
            this.db = db;
        }
    }
    class Program
    {
        static List<Kutyanevek> KutyaNevAdatok = new List<Kutyanevek>();
        static List<KutyaFajtak> KutyaFajtaAdatok = new List<KutyaFajtak>();
        static List<Kutyak> KutyakAdatok = new List<Kutyak>();
        static void Main(string[] args)
        {
            Beolvasas("KutyaNevek.csv");
            Console.WriteLine("3. feladat: Kutyanevek száma: {0}",KutyaNevAdatok.Count());
            Beolvasas("KutyaFajtak.csv");
            Beolvasas("Kutyak.csv");
            AtlagKor();
            Legidosebb();
            Januar18();
            Leterhelt();
            Nevstat();
            Console.ReadLine();
        }

        static void Leterhelt()
        {
            List<string> napok = new List<string>();
            for (int i = 0; i < KutyakAdatok.Count(); i++)
            {
                napok.Add(KutyakAdatok[i].datum);
            }
            napok.Sort();
            int max = 0;
            int maxi = 0;
            for (int i = 0; i < napok.Count; i++)
            {
                int j = i + 1;
                while (j < napok.Count() && napok[i]==napok[j]) {
                    j++;
                }
                if (j-i>=max) {
                    max = (j - i)+1;
                    maxi = i;
                }
                i = j;
            }

            Console.WriteLine("9. feladat: Legjobban leterhelt nap: {0} : {1} kutya",napok[maxi],max);
        }
        static void Januar18() {
            List<string> Fajtak = new List<string>();
            for (int i = 0; i < KutyakAdatok.Count(); i++)
            {
                if (KutyakAdatok[i].datum == "2018.01.10") {
                    Fajtak.Add(FajtaKeres(KutyakAdatok[i].fajtaid));
                }
            }
            Console.WriteLine("8. feladat: Január 10.-én vizsgált kutya fajták:");
            for (int i = 0; i < Fajtak.Count(); i++)
            {
                int db = 1;
                for (int j = i+1; j < Fajtak.Count()-1; j++)
                {
                    if (Fajtak[i]==Fajtak[j]) {
                        Fajtak.RemoveAt(j);
                        j--;
                    }
                }
                Console.WriteLine("\t{0}: {1} kutya",Fajtak[i],db);
            }
        }
        static void Nevstat() {
            List<KutyaNevekdb> Kutyaknevei = new List<KutyaNevekdb>();
            for (int i = 0; i < KutyaNevAdatok.Count(); i++)
            {
                Kutyaknevei.Add(new KutyaNevekdb(KutyaNevAdatok[i].nev,Keresdb(KutyaNevAdatok[i].id)));
            }

            for (int i = 0; i < Kutyaknevei.Count-1; i++)
            {
                for (int j = i+1; j < Kutyaknevei.Count; j++)
                {
                    if (Kutyaknevei[i].db<Kutyaknevei[j].db) {
                        KutyaNevekdb peldany = Kutyaknevei[i];
                        Kutyaknevei[i] = Kutyaknevei[j];
                        Kutyaknevei[j] = peldany;
                    }
                }
            }

            StreamWriter sw = new StreamWriter("névstatisztika.txt");
            for (int i = 0; i < Kutyaknevei.Count; i++)
            {
                sw.WriteLine("{0};{1}",Kutyaknevei[i].nev,Kutyaknevei[i].db);
            }
            sw.Close();
            Console.WriteLine("10. feladat: névstatisztika.txt");
        }

        static int Keresdb(int kid) {
            int db = 0;
            for (int i = 0; i < KutyakAdatok.Count(); i++)
            {
                if (KutyakAdatok[i].nevid==kid) {
                    db++;
                }
            }
            return db;
        }

        static void Legidosebb() {
            int max = KutyakAdatok[0].kor;
            int maxi = 0;
            for (int i = 0; i < KutyakAdatok.Count(); i++)
            {
                if (KutyakAdatok[i].kor>max) {
                    max = KutyakAdatok[i].kor;
                    maxi = i;
                }
            }
            Console.WriteLine("7. feladat: Legidősebb kutya neve és fajtája: {0}, {1}", NevKeres(KutyakAdatok[maxi].nevid), FajtaKeres(KutyakAdatok[maxi].fajtaid));
        }
        static string FajtaKeres(int fajtaid)
        {
            for (int i = 0; i < KutyaFajtaAdatok.Count; i++)
            {
                if (fajtaid == KutyaFajtaAdatok[i].id)
                {
                    return KutyaFajtaAdatok[i].fajta;
                }
            }
            return "";
        }
        static string NevKeres(int nevid) {
            for (int i = 0; i < KutyaNevAdatok.Count; i++)
            {
                if (nevid== KutyaNevAdatok[i].id) {
                    return KutyaNevAdatok[i].nev;
                }
            }
            return "";
        }
        static void AtlagKor() {
            double sum = 0;
            for (int i = 0; i < KutyakAdatok.Count(); i++)
            {
                sum += KutyakAdatok[i].kor;
            }
            sum = Math.Round(sum / KutyakAdatok.Count(),2);
            Console.WriteLine("6. feladat: Kutyák átlag életkora: {0}",sum);
        }
        static void Beolvasas(string fnev) {
            if (fnev == "KutyaNevek.csv")
            {
                StreamReader f = new StreamReader(fnev);
                f.ReadLine();
                while (!f.EndOfStream)
                {
                    KutyaNevAdatok.Add(new Kutyanevek(f.ReadLine()));
                }
                f.Close();
            }
            if (fnev == "KutyaFajtak.csv")
            {
                StreamReader f = new StreamReader(fnev);
                f.ReadLine();
                while (!f.EndOfStream)
                {
                    KutyaFajtaAdatok.Add(new KutyaFajtak(f.ReadLine()));
                }
                f.Close();
            }
            if (fnev == "Kutyak.csv")
            {
                StreamReader f = new StreamReader(fnev);
                f.ReadLine();
                while (!f.EndOfStream)
                {
                    KutyakAdatok.Add(new Kutyak(f.ReadLine()));
                }
                f.Close();
            }
        }
    }
}
