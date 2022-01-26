namespace codeabbey
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("test.txt");
            List<double> rszamok = new List<double>();
           // int n = Convert.ToInt32(f.ReadLine());

            while (!f.EndOfStream)
            {
                string sor = f.ReadLine();
                string[] sv = sor.Split(' ');
                for (int i = 0; i < 52; i++)
                {
                    rszamok.Add(Convert.ToInt32(sv[i]));
                }
            }
            f.Close();

            string[] suits = new string[] { "C", "D", "H", "S" };
            string[] ranks = new string[] { "A" , "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };

            List<string> deck = new List<string>();

            //feltolt
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    deck.Add(suits[i] + ranks[j]);
                }
            }

            for (int i = 0; i < deck.Count; i++)
            {
                Console.Write(deck[i] + " ");
            }

            //csere
            Random r = new Random();
            for (int i = 0; i < 52; i++)
            {
                string swap = deck[i];
                if (rszamok[i] > 51){
                    rszamok[i] = (rszamok[i] % 52);
                }
                int j = Convert.ToInt32(rszamok[i]);
                deck[i] = deck[j];
                deck[j] = swap;
            }

            Console.WriteLine();

            for (int i = 0; i < deck.Count; i++)
            {
                Console.Write(deck[i] + " ");
            }




            Console.ReadLine();
        }
    }
}