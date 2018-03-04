using System;
using System.Collections.Generic;

namespace AlgFirstLabFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] profit = new int[] {5, 6, 5, 1};
            int[] distances = new int[] {6, 7, 12, 14};

            var billboards = new Billboard(distances, profit);
            int maxProfit = billboards.CountMaxProfitSum();
            Console.WriteLine(maxProfit);
            Console.ReadLine();
        }
    }

    class Billboard
    {
        private int[] distances;
        private int[] profit;

        public Billboard(int[] distances, int[] profit)
        {
            this.distances = distances;
            this.profit = profit;
        }

        public int CountMaxProfitSum()
        {
            List<int> M = new List<int> {};
            M.Add(0);
            M.Add(profit[0]);

            for (int i = 2; i < distances.Length; i++)
            {
                M.Add(Math.Max(profit[i] + M[CountE(i)], M[i - 1]));
            }

            return M[distances.Length-1];
        }

        private int CountE(int j)
        {
            int maxDist = j-1;

            while (distances[j] - distances[maxDist] < 5)
               maxDist -= 1;

            return maxDist;
        }
    }
}
