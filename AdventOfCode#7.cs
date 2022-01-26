using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace advent
{
    class Program
    {

        static List<string> AllBag = new List<string>();
        static List<string> VegBag = new List<string>();
        static void Main(string[] args)
        {

            StreamReader f = new StreamReader("adat.txt");
            while (!f.EndOfStream)
            {
                string sor = f.ReadLine();
                AllBag.Add(sor);
            }
            f.Close();

            string bag = "shiny gold bag";
            Kigyujt(bag);
            for (int i = 0; i < VegBag.Count(); i++)
            {
                bag = VegBag[i];
                Kigyujt(bag);
            }

            VegBag.Sort();
            int vi = 1;
            string jel = VegBag[0];
            for (int i = 1; i < VegBag.Count()-1; i++)
            {
                if (jel != VegBag[i + 1]) {
                    jel = VegBag[i + 1];
                    vi++;
                }
            }
            Console.WriteLine(vi);
            Console.ReadLine();
        }

        static void Kigyujt(string bag)
        {
            for (int i = 0; i < AllBag.Count(); i++)
            {
                if (AllBag[i].Contains(bag+"s contain")==false && AllBag[i].Contains(bag)) {
                    Kivalaszt(AllBag[i]);
                }
            }
        }

        static void Kivalaszt(string sor) {
            int i = 0;
            string bag = "";
            while (bag.Contains("bag") == false) {
                bag += sor[i];
                i++;
            }
            VegBag.Add(bag);
        }
    }
}