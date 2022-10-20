using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clustering
{
    public class Result
    {
        public readonly int[] Clusters;
        public readonly double[,] Means;
        public readonly double SSE;

       
        public Result(int[] clusters, double[,] means, double sse)
        {
            Clusters = clusters;
            Means = means;
            SSE = sse;
        }

        


    }
}