using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Accord.Math;
using Accord.Statistics.Distributions.Multivariate;

namespace clustering
{
    class GMM
    {
        //const int N = 8; const int K = 3; const int d = 2;
        Data data;
        int[] clusters;
        int N;
        int K;
        int d;
        double[][] X;
        public GMM(Data data, int num_clusters)
        {
            this.data = data;
            this.N = data.Num_points;
            this.K = num_clusters;
            this.d = data.Dim;
            var clusters = new int[N];
            this.X = new double[N][];
            for (int i = 0; i < N; i++)
            {
                X[i] = new double[d];
                for (int j = 0; j < d; j++)
                    X[i][j] = data.Points[i, j];
            }
        }

        public Tuple<int[], double[][]> Get_clusters()
        {
            // Creates and computes a new 
            // K-Means clustering algorithm:

            KMeans kmeans = new KMeans(K);

            KMeansClusterCollection clustering = kmeans.Learn(X);

            // Classify all instances in mixture data
            //int[] clusters = clustering.Decide(observations);
            var tuple = new Tuple<int[], double[][]>(clustering.Decide(X), X);
            return tuple;

                //// -----------------------------------------------------------------
                //Console.WriteLine("\nBegin mixture model with C# demo \n");

                //Console.WriteLine("Data (height, width) to cluster looks like: ");
                //Console.Write("[0] "); VectorShow(X[0]);
                //Console.Write("[1] "); VectorShow(X[1]);
                //Console.WriteLine(". . . ");
                ////Console.Write("[7] "); VectorShow(X[7]);

                //Console.WriteLine("\nSetting K = {0}, initializing w, a, u, V, Nk", K);
                //double[][] w = MatrixCreate(N, K);  // 8x3 membership weights
                //double[] a = new double[K];
                //for (int ii=0; ii<K; ii++) a[ii] = 1.0 / K;
                //double[][] u = MatrixCreate(K, d); // 3x2 Gaussian means
                //double[][] V = MatrixCreate(K, d, 0.01); // variances
                //double[] Nk = new double[K];  // 3 col sums of the w matrix

                ////u[0][0] = 0.2; u[0][1] = 0.7;  // typically from k-means
                ////u[1][0] = 0.5; u[1][1] = 0.5;
                ////u[2][0] = 0.8; u[2][1] = 0.2;

                //// ShowDataStructures(w, Nk, a, u, S);

                //Console.WriteLine("Performing 5 E-M update iterations ");
                //for (int iter = 0; iter < 5; ++iter)
                //{
                //    UpdateMembershipWts(w, X, u, V, a);  // E step
                //    UpdateNk(Nk, w);  // M steps
                //    UpdateMixtureWts(a, Nk);
                //    UpdateMeans(u, w, X, Nk);
                //    UpdateVariances(V, u, w, X, Nk);
                //}

                //Console.WriteLine("Clustering done. \n");
                //ShowDataStructures(w, Nk, a, u, V);

                //Console.WriteLine("End mixture model demo");
                //Console.ReadLine();

                ////var clusters = new int[8];
                //for (int i = 0; i < N; ++i)
                //{
                //    double maxValue = 0;
                //    for (int k = 0; k < K; ++k)
                //        if (w[i][k] > maxValue) maxValue = w[i][k];
                //    int maxIndex = w[i].ToList().IndexOf(maxValue);
                //    clusters[i] = maxIndex;
                //}
                //return clusters;
            } // Main

        // -----------------------------------------------------------------

        static void ShowDataStructures(double[][] w, double[] Nk,
          double[] a, double[][] u, double[][] V)
        {
            Console.WriteLine("w (membership wts):"); MatrixShow(w, true);
            Console.WriteLine("Nk (w column sums):"); VectorShow(Nk, true);
            Console.WriteLine("a (mixture wts):"); VectorShow(a, true);
            Console.WriteLine("u (cluster means):"); MatrixShow(u, true);
            Console.WriteLine("V (cluster variances):"); MatrixShow(V, true);
        }

        public void UpdateMembershipWts(double[][] w, double[][] X,
          double[][] u, double[][] V, double[] a)
        {
            for (int i = 0; i < N; ++i)
            {
                double rowSum = 0.0;
                for (int k = 0; k < K; ++k)
                {
                    double pdf = NaiveProb(X[i], u[k], V[k]);  // for wik
                    w[i][k] = a[k] * pdf;
                    rowSum += w[i][k];
                }
                for (int k = 0; k < K; ++k)
                    w[i][k] = w[i][k] / rowSum;
            }
        }

        public void UpdateNk(double[] Nk, double[][] w)
        {
            for (int k = 0; k < K; ++k)
            {
                double sum = 0.0;
                for (int i = 0; i < N; ++i)
                    sum += w[i][k];
                Nk[k] = sum;
            }
        }

        public void UpdateMixtureWts(double[] a, double[] Nk)
        {
            for (int k = 0; k < K; ++k)
                a[k] = Nk[k] / N;
        }

        // -----------------------------------------------------------------
        public void UpdateMeans(double[][] u, double[][] w, double[][] X,
          double[] Nk)
        {
            double[][] result = MatrixCreate(K, d);
            for (int k = 0; k < K; ++k)
            {
                for (int i = 0; i < N; ++i)
                    for (int j = 0; j < d; ++j)
                        result[k][j] += w[i][k] * X[i][j];

                for (int j = 0; j < d; ++j)
                    result[k][j] = result[k][j] / Nk[k];
            }

            for (int k = 0; k < K; ++k)
                for (int j = 0; j < d; ++j)
                    u[k][j] = result[k][j];
        }

        public void UpdateVariances(double[][] V, double[][] u,
          double[][] w, double[][] X, double[] Nk)
        {
            double[][] result = MatrixCreate(K, d);
            for (int k = 0; k < K; ++k)
            {
                for (int i = 0; i < N; ++i)
                    for (int j = 0; j < d; ++j)
                        result[k][j] += w[i][k] * (X[i][j] - u[k][j]) *
                          (X[i][j] - u[k][j]);

                for (int j = 0; j < d; ++j)
                    result[k][j] = result[k][j] / Nk[k];
            }

            for (int k = 0; k < K; ++k)
                for (int j = 0; j < d; ++j)
                    V[k][j] = result[k][j];
        }

        static double ProbDenFunc(double x, double u, double v)
        {
            // univariate Gaussian
            if (v == 0.0) throw new Exception("var = 0 in ProbDenFun");
            double left = 1.0 / Math.Sqrt(2.0 * Math.PI * v);
            double pwr = -1 * ((x - u) * (x - u)) / (2 * v);
            return left * Math.Exp(pwr);
        }

        // -----------------------------------------------------------------

        public double NaiveProb(double[] x, double[] u, double[] v)
        {
            // poor man's multivariate Gaussian. simple average of univariates
            double sum = 0.0;
            for (int j = 0; j < d; ++j)
                sum += ProbDenFunc(x[j], u[j], v[j]);
            return sum / d;
        }

        static double[][] MatrixCreate(int rows, int cols, double v = 0.0)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    result[i][j] = v;
            return result;
        }

        static void MatrixShow(double[][] m, bool newline = false)
        {
            for (int i = 0; i < m.Length; ++i)
            {
                for (int j = 0; j < m[0].Length; ++j)
                {
                    Console.Write(m[i][j].ToString("F4") + "  ");
                }
                Console.WriteLine("");
            }
            if (newline == true)
                Console.WriteLine("");
        }

        static void VectorShow(double[] v, bool newline = false)
        {
            for (int i = 0; i < v.Length; ++i)
                Console.Write(v[i].ToString("F4") + "  ");
            Console.WriteLine("");
            if (newline == true)
                Console.WriteLine("");
        }
    }
}
