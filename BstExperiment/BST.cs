using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstExperiment
{
    class BST
    {
        public SortedSet<int> getBST(int max)
        {
            SortedSet<int> set = new SortedSet<int>();

            Random r = new Random();
            while (set.Count < max)
            {
                set.Add(r.Next(0, max));
            }

            return set;
        }
    }
}
