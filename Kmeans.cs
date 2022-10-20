using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clustering
{
    class Kmeans
    {
        Data data;
        int num_clusters;//no of clusters
        double[,] means;
        int[] clusters;
        //double sse;

        public Kmeans(Data data, int num_clusters)
        {
            this.data = data;
            this.num_clusters = num_clusters;
            clusters = new int[data.Num_points];//new is used every time you initialise someting
            means = new double[num_clusters, data.Dim];

        }
        public Result Get_clusters()
        {
            initialise();
            bool success = true;
            //The Boolean variable indicates whether the means of the clusters were able to be computed.
            bool changed = true;
            /*The Boolean variable tracks whether any of the data tuples has changed cluster group*/
            int iter = 0;

            //Variables iter and iter_max are used to limit the number of times the clustering loop executes,iter_max is set to 
            //10 in this case
            while (changed == true && success == true && iter </*data.Iter_max*/10)
            {
                iter += 1;//iter=iter+1
                success = update_means();
                changed = update_clusters();
            }
            var Q = new QualityMeasurement(data, num_clusters, clusters);
            double q = Q.GetQ();
            //Console.WriteLine("q={0}", q);
            // Result Result = Get_clusters();     
            return new Result(clusters, means, q);
            //The clustering loop exits when there's no change to the clustering, or one or more means cannot be computed 
            // because doing so would create a situation with no data tuples assigned to some cluster, or when maxCount
            //iterations is reached.
        }

        private void initialise()
        { //initializes the clustering array by assigning each data tuple to a randomly selected cluster ID. The method
          // arbitrarily assigns tuples 0, 1 and 2 to clusters 0, 1 and 2, respectively, so that each cluster is guaranteed to
          //  have at least one data tuple assigned to it: 

            Random random = new Random();
            for (var i = 0; i < num_clusters; i++)
                clusters[i] = i;

            for (var i = num_clusters; i < data.Num_points; i++)
                clusters[i] = random.Next(0, num_clusters);
        }

        private bool update_means()
        {
            int[] clusterCounts = new int[num_clusters];
            for (var i = 0; i < data.Num_points; i++)
            {
                //int cluster = clusters[i];//
                clusterCounts[clusters[i]]++;
            }
            for (var k = 0; k < num_clusters; k++)
                if (clusterCounts[k] == 0)
                    return false;
            //scan the clustering input array parameter and count the number of tuples assigned to each cluster.
            //If any cluster has no tuples assigned, the method exits and returns false.

            for (var i = 0; i < data.Num_points; i++)
            {
                for (var j = 0; j < data.Dim; j++)
                    means[clusters[i], j] += data.Points[i, j];// accumulate sum
            }

            for (var k = 0; k < num_clusters; k++)
            {
                for (var j = 0; j < data.Dim; j++)
                    means[k, j] /= clusterCounts[k];
            }
            /*Suppose a cluster has three height-weight tuples: d0 = {64, 110}, d1 = {65, 160}, d2 = {72, 180}.
               * The mean of the cluster is computed as {(64+65+72)/3, (110+160+180)/3} = {67.0, 150.0}. 
               * In other words, you just compute the average of each data component. */
            return true;
        }

        //In each iteration of the Cluster method, after new cluster means have been computed, the cluster membership of each data tuple is updated:
        private bool update_clusters()
        {
            bool changed = false;  /*The Boolean variable tracks whether any of the data tuples has changed their cluster group*/
            for (var i = 0; i < data.Num_points; i++)//check from each data point
            {
                double dist_min = Double.MaxValue;
                int index_min = 0;
                double dist;
                for (var j = 0; j < num_clusters; j++)//check through each cluster
                {
                    dist = 0.0;
                    for (var k = 0; k < data.Dim; k++)
                        //scan through each data tuple, computes the distances from the current tuple to each of the cluster means

                        dist += Math.Sqrt(Math.Pow((data.Points[i, k] - means[j, k]), 2));

                  

                    /*dist = Math.Sqrt(dist);*///sqrt[(Xi-Xc)^2+(Yi-Yc)^2]
                                               //calculate euclidean distance between a data tuple and a cluster mean. 
                    if (dist < dist_min)
                    {
                        dist_min = dist;
                        index_min = j; //assigns the tuple to the closest mean
                    }
                }

                if (clusters[i] != index_min)//cluster[i]= MinIndex(distances),if cluster[i] != newClusterID            
                {
                    clusters[i] = index_min;
                    changed = true;
                }
            }
            return changed;
        }
    }
}

