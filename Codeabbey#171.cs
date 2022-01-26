using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace codeabbey
{
    class Tree {
        public int D;
        public double B;
        public Tree(string sor) {
            string[] sv = sor.Split(' ');
            D = Convert.ToInt32(sv[0]);
            B = Convert.ToDouble(sv[1].Replace('.',',')) ;
        }
    }
    class Program
    {
        static List<Tree> Adatok = new List<Tree>();
        static void Main(string[] args)
        {
            FajlBeolvasas();

            for (int i = 0; i < Adatok.Count; i++)
            {
                double H = Math.Tan((Adatok[i].B * Math.PI)/180);
                H = Math.Round(Math.Abs(Adatok[i].D / H),0);
                Console.Write("{0} ",H);
            }
            Console.ReadLine();
        }

        static void FajlBeolvasas() {
            StreamReader f = new StreamReader("fajl.txt");
            f.ReadLine();
            while (!f.EndOfStream) {
                Adatok.Add(new Tree(f.ReadLine()));
            }
        }
    }
}