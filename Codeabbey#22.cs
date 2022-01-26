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
    class Nyomatato {
        public int elso;
        public int masodik;
        public int db;

        public Nyomatato(int elso,int masodik,int db) {
            this.elso = elso;
            this.masodik = masodik;
            this.db = db;
        }
    
    }
    class Program
    {

        static List<Nyomatato> Adatok = new List<Nyomatato>();
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("test.txt");
            f.ReadLine();

            while (!f.EndOfStream)
            {
                string[] sv = f.ReadLine().Split(' ');
                Adatok.Add(new Nyomatato(Convert.ToInt32(sv[0]),Convert.ToInt32(sv[1]), Convert.ToInt32(sv[2])));
            }
            f.Close();

            for (int i = 0; i < Adatok.Count(); i++)
            {
                int elso = Adatok[i].elso;
                int masodik = Adatok[i].masodik;
                int db = 1;
                int mp;
                if (elso > masodik)
                {
                    mp = masodik;
                }
                else if (masodik > elso)
                {
                    mp = elso;
                }
                else {
                    mp = elso;
                    db = 2;
                }

                while (db < Adatok[i].db)
                {
                    mp++;
                    if (mp % elso == 0)
                    {
                        db++;
                    }
                    if (mp % masodik == 0)
                    {
                        db++;
                    }
                }
                Console.Write(mp+" ");
            }
            Console.ReadLine();
        }
    }
}