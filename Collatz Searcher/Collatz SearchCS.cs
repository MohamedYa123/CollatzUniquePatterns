using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz_Searcher
{
    public class Collatz_SearchCS
    {

        const double factor = 0.584;
        public int reached = 0;
        long nodes = 0;
        int directfordecrease=0;
        public List<int> listdirectfordecrease = new List<int>();
        public void Report(int maxi)
        {
            for(int i = 2; i <= maxi; i++)
            {
                int[] combination = new int[i+1];
                directfordecrease = 0;
                Generate(combination, i, 0, 0, 0);
                listdirectfordecrease.Add(directfordecrease);
                reached = i;
                Console.WriteLine("Reached: "+i+" Combinations found: "+combinationsfound.Count+" ,Nodes: "+(nodes/1000000000.0).ToString("###########.00000000000000")+" 10^9");
            }
        }
        public List<int[]> combinationsfound=new();
        public List<int> lengthes=new ();
        public List<int> vlcritics=new ();
        bool Generate(int[] combination,int valCritic,int sumn,int sumz,int pointer)
        {
            double valn =(sumn * factor);
            if (sumz + sumn == valCritic) {
                if(valn - sumz <= -0.58)
                {
                    directfordecrease++;
                }
                if (valn - sumz <= 0&&valn-sumz+1>=0)
                {
                    combinationsfound.Add((int[])combination.Clone());
                    lengthes.Add(pointer);
                    vlcritics.Add(valCritic);
                    nodes++;
                    return true;
                }
                else
                {
                    nodes++;
                    return false;
                }
            }
            else if (pointer >= valCritic|| (valn-sumz<=0&&pointer>0))
            {
                nodes++;
                return false;
            }
            if (pointer % 2 == 0)
            {
                //if(pointer >= valCritic - 1)
                //{
                //    return false;
                //}
                //test all n
                int maxn = valCritic - sumn;
                for (int n = 1; n <= maxn; n++)
                {
                    combination[pointer] = n;
                    Generate(combination, valCritic, sumn + n, sumz, pointer + 1);
                }

            }
            else
            {
                double maxz =(int)(valCritic - (valn - sumz));
                for (int z=1;z<= maxz; z++)
                {
                    combination[pointer] = z;
                    Generate(combination, valCritic, sumn, sumz + z, pointer + 1);
                    //if(!a&&pointer>=valCritic-1)
                    //{
                    //    break;
                    //}
                }
            }
            return false;
        }
    }
    struct ReportCL
    {
        public int[] combination;
        public int frequency;
    }
}
