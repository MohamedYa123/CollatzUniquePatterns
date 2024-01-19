using System.Diagnostics;

namespace Collatz_Searcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Collatz_SearchCS collatz_Searcher = new ();
            int max = 21;
            Stopwatch sp=Stopwatch.StartNew();
            collatz_Searcher.Report(max);
            sp.Stop();
            Console.WriteLine(sp.ElapsedMilliseconds+"");
            Console.WriteLine("Combinations found: "+collatz_Searcher.combinationsfound.Count);
            Dictionary<int, int> valcritics = new();
            valcritics.Add(1, 1);
            for(int i=0;i<collatz_Searcher.combinationsfound.Count;i++)
            {
                string sl = "";
                for(int j = 0; j < collatz_Searcher.lengthes[i]; j++)
                {
                    sl += $"{collatz_Searcher.combinationsfound[i][j]}+";
                }
                sl = sl.Trim('+');
                int vlc = collatz_Searcher.vlcritics[i];
                if (valcritics.ContainsKey(vlc))
                {
                    valcritics[vlc] += 1;// collatz_Searcher.lengthes[i]/2;
                }
                else
                {
                    valcritics.Add(vlc, 1);// collatz_Searcher.lengthes[i] / 2);
                }
               // Console.WriteLine($"{i+1} - Combination: 2^{vlc}, [{sl}]");
            }
            double totalpercentage = 0;
            for(int i = 1; i <= max; i++)
            {
                int found = 0;
                int foundeasydirect = 0;//
                if (i > 1)
                { foundeasydirect= collatz_Searcher.listdirectfordecrease[i-2]; }
                if (valcritics.ContainsKey(i))
                {
                    found = valcritics[i];
                }
                totalpercentage += Math.Pow(2, -i) * found;
                Console.Write($"2^{i}, Unique combinations found: {found}, direct: {foundeasydirect}");//direct means (Can have higher n values and still decrease)
                Console.Write(" Percentage: "+totalpercentage+", Empty rooms: "+(Math.Pow(2,i)) *(1-totalpercentage)+"\r\n");
            }
            Console.WriteLine("Total percentage: "+totalpercentage);
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}