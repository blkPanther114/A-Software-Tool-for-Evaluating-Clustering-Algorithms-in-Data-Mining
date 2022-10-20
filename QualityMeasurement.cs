using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clustering
{
    class QualityMeasurement
    {
        Data data;
        int num_clusters;
        int[] clusters;
        public QualityMeasurement(Data data, int num_clusters, int[] clusters)
        {
            this.data = data;
            this.num_clusters = num_clusters;
            this.clusters = clusters;
        }

        public double getWC()
        {
            var centroids = GetCentroids();
            double[] sse = new double[num_clusters];
            for (var k = 0; k < num_clusters; k++)
                sse[k] = 0;
            for (var i = 0; i < data.Num_points; i++)
            {
                var k = clusters[i];
                if (double.IsNaN(centroids[k, 0]))
                {
                    continue;
                }
                sse[k] +=Math.Sqrt( Math.Pow(data.Points[i, 0] - centroids[k, 0], 2) +
                            Math.Pow(data.Points[i, 1] - centroids[k, 1], 2));
            }
            

            double wc = 0;
            for (var k = 0; k < num_clusters; k++)
            {
                wc += sse[k];
            }
            return wc;
        }

        public double getBC()
        {
            var centroids = GetCentroids();
            double bc = 0;
            if (num_clusters > 1)
                for (var i = 0; i < num_clusters - 1; i++)
                    for (var j = i + 1; j < num_clusters; j++)
                    {
                        if (double.IsNaN(centroids[i, 0]) | double.IsNaN(centroids[j, 0]))
                        {
                            continue;
                        }
                        bc += Math.Sqrt(Math.Pow(centroids[i, 0] - centroids[j, 0], 2)) +
                            (Math.Pow(centroids[i, 1] - centroids[j, 1], 2));                     
                    }
            return bc;
        }


        public double GetQ()
        {
            //var centroids = GetCentroids();
            //double[] sse = new double[num_clusters];
            //for (var k = 0; k < num_clusters; k++)
            //    sse[k] = 0;
            //for (var i = 0; i < data.Num_points; i++)
            //{
            //    var k = clusters[i];
            //    if (double.IsNaN(centroids[k, 0]))
            //    {
            //        continue;
            //    }
            //    sse[k] += (Math.Pow(data.Points[i, 0] - centroids[k, 0], 2) +
            //                Math.Pow(data.Points[i, 1] - centroids[k, 1], 2));
            //}
            //double wc = 0;          
            //for (var k = 0; k < num_clusters; k++)
            //{
            //    wc += sse[k];
            //}
            //return wc;


            //double bc = 0;
            //if (num_clusters > 1)
            //    for (var i = 0; i < num_clusters-1; i++)
            //        for (var j = i+1; j < num_clusters; j++)
            //        {
            //            if (double.IsNaN(centroids[i, 0]) | double.IsNaN(centroids[j, 0]))
            //            {
            //                continue;
            //            }
            //            bc += (Math.Pow(centroids[i, 0] - centroids[j, 0], 2) +
            //                Math.Pow(centroids[i, 1] - centroids[j, 1], 2));                     
            //        }
            //return bc;

            var bc=getBC();
            var wc=getWC();
            //TODO: if one cluster, shoud raise error 
            double q = bc / wc;
            return q;
        }
        private double[,] GetCentroids()
        {
            double[,] centroids = new double[num_clusters, 2];
            int[] cluster_size = new int[num_clusters];
            for (var k = 0; k < num_clusters; k++)
            {
                centroids[k, 0] = 0;
                centroids[k, 1] = 0;
                cluster_size[k] = 0;
            }
            for (var i = 0; i < data.Num_points; i++)
            {
                int k = clusters[i];
                centroids[k, 0] += data.Points[i, 0];
                centroids[k, 1] += data.Points[i, 1];
                cluster_size[k]++;
            }
            for (var k = 0; k < num_clusters; k++)
            {
                centroids[k, 0] /= cluster_size[k];
                centroids[k, 1] /= cluster_size[k];
                //if (double.IsNaN(centroids[k, 0]))
                //{
                //    Console.WriteLine("wrong !!!");
                //}
            }
            return centroids;
        }
    }
}
