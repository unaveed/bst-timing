using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstExperiment
{
    class BstTimer
    {
        private static int MAX = 1024;

        public static double Timer(int num)
        {
            int size = (int)Math.Pow(2, num);
            BST bst = new BST();
            SortedSet<int> testCase = bst.getBST(size);
            HashSet<int> checker = new HashSet<int>();
            int[] pool = new int[MAX];
            Random rand = new Random();

            int i = 0;
            while(checker.Count < MAX)
            {
                int rNum = rand.Next(0, size);
                if (!checker.Contains(rNum))
                {
                    checker.Add(rNum);
                    pool[i] = rNum;
                    i++;
                }
            }
            Console.WriteLine("Version " + num + ", test for " + size + " inputs");
            return TimeMethod(pool, testCase, 1000, size);
        }

        public static double TimeMethod(int[] pool, SortedSet<int> set, int minMsecs, int size)
        {
            Stopwatch sw = new Stopwatch();

            double elapsed = 0;
            long repetitions = 1;

            do
            {
                repetitions *= 2;
                sw.Restart();
                for (int i = 0; i < repetitions; i++)
                {
                    for (int j = 0; j < MAX; j++)
                    {
                        set.Contains(pool[j]);
                    }
                }
                sw.Stop();
                elapsed = msecs(sw);
            } while (elapsed < minMsecs);
            double totalAverage = elapsed / repetitions;

            sw = new Stopwatch();
            elapsed = 0;
            repetitions = 1;

            do
            {
                repetitions *= 2;
                sw.Restart();
                for (int i = 0; i < repetitions; i++)
                {
                    for (int j = 0; j < MAX; j++)
                    {
                    }
                }
                sw.Stop();
                elapsed = msecs(sw);
            } while (elapsed < minMsecs);
            double overheadAverage = elapsed / repetitions;

            Console.WriteLine("Total avg: " + totalAverage.ToString("G2"));
            Console.WriteLine("Overhead avg: " + overheadAverage.ToString("G2"));
            double realAverage = (totalAverage - overheadAverage) / MAX;
            return realAverage;
        }

        public static double msecs(Stopwatch sw)
        {
            return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
        }
    }
}
