namespace code
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("test.txt");
            //List<string> d = new List<string>();
            int n = Convert.ToInt32(f.ReadLine());

            List<int> tol = new List<int>();
            List<int> ig = new List<int>();

            while (!f.EndOfStream)
            {
                string sor = f.ReadLine();
                string[] sv = sor.Split(' ');
                tol.Add(Convert.ToInt32(sv[0]));
                ig.Add(Convert.ToInt32(sv[1]));
            }
            f.Close();


            for (int i = 0; i < n; i++)
            {
                int primekdb = 0;
                for (int j = tol[i]; j <= ig[i]; j++)
                {
                    int oszto = 0;
                    int k = 1;
                    while (j >= k && oszto<3) {
                        if (j % k == 0) {
                            oszto++;
                        }
                        k++;
                    }
                    if (oszto == 2) {
                        primekdb++;
                    }
                }
                Console.Write(primekdb+" ");
            }



            Console.ReadLine();
        }
    }
}