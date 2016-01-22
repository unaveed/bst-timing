using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstExperiment
{
    class Program
    {

        static void Main(string[] args)
        {
            List<double> results = new List<double>();
            for (int i = 10; i < 12; i++)
            {
                double result = BstTimer.Timer(i);
                //results.Add(result);
            }

            for (int i = 10; i <= 20; i++)
            {
                double result = BstTimer.Timer(i);
                results.Add(result);
            }

            using (StreamWriter outputFile = new StreamWriter("results.txt"))
            {
                double version = 10;
                foreach (double result in results)
                {
                    outputFile.WriteLine(result);
                    version += 1;
                }
            }
        }
    }
}
