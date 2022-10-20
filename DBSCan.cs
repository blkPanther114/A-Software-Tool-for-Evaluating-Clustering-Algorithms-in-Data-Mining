using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace clustering
{

    public class Point

    {

        public const int NOISE = -1;

        public const int UNCLASSIFIED = 0;

        public double X, Y;
        public int ClusterId;

        public Point(double x, double y)

        {

            this.X = x;

            this.Y = y;

        }

        public override string ToString()

        {

            return String.Format("({0}, {1})", X, Y);

        }

        public static double DistanceSquared(Point p1, Point p2)

        {

            double diffX = p2.X - p1.X;

            double diffY = p2.Y - p1.Y;

            return diffX * diffX + diffY * diffY;

        }

    }

    public class DBSCAN

    {
        Data m_data;
        double m_eps;
        int m_minPts;

        public DBSCAN(Data data, double eps, int minPts)

        {
            this.m_data = data;
            this.m_eps = eps;
            this.m_minPts = minPts;
        }

        public List<List<Point>>  Get_clusters()
        { 
            List<Point> points = new List<Point>();

            // sample m_data

            for (int i=0; i<m_data.Num_points; i++ )
            {
                points.Add(new Point(m_data.Points[i, 0], m_data.Points[i, 1]));
            }
            
            //double m_eps = 100.0;

            //int m_minPts = 3;

            List<List<Point>> clusters = GetClusters(points, m_eps, m_minPts);

            int total = 0;

            for (int i = 0; i < clusters.Count; i++)

            {

                int count = clusters[i].Count;

                total += count;
            }

            // print any points which are NOISE

            total = points.Count - total;
            //最后一组为噪音
            clusters.Add(new List<Point>());
            if (total > 0)
            {
                foreach (Point p in points)

                {
                    if (p.ClusterId == Point.NOISE)
                        clusters[clusters.Count-1].Add(p);
                }

            }
            else

            {

                Console.WriteLine("\nNo points are NOISE");

            }
            return clusters;

        }

        private List<List<Point>> GetClusters(List<Point> points, double m_eps, int m_minPts)

        {

            if (points == null) return null;

            List<List<Point>> clusters = new List<List<Point>>();

            m_eps *= m_eps; // square m_eps

            int clusterId = 1;

            m_data.t0();
            for (int i = 0; i < points.Count; i++)

            {
                Point p = points[i];

                if (p.ClusterId == Point.UNCLASSIFIED)

                {

                    if (ExpandCluster(points, p, clusterId, m_eps, m_minPts)) clusterId++;

                }
                m_data.t1();
            }

            // sort out points into their clusters, if any

            double maxClusterId = points.OrderBy(p => p.ClusterId).Last().ClusterId;

            if (maxClusterId < 1) return clusters; // no clusters, so list is empty

            for (int i = 0; i < maxClusterId; i++) clusters.Add(new List<Point>());

            foreach (Point p in points)

            {

                if (p.ClusterId > 0) clusters[p.ClusterId - 1].Add(p);

            }

            return clusters;

        }

        private List<Point> GetRegion(List<Point> points, Point p, double m_eps)

        {

            List<Point> region = new List<Point>();

            for (int i = 0; i < points.Count; i++)

            {

                double distSquared = Point.DistanceSquared(p, points[i]);

                if (distSquared <= m_eps) region.Add(points[i]);

            }

            return region;

        }

        private bool ExpandCluster(List<Point> points, Point p, int clusterId, double m_eps, int m_minPts)

        {

            List<Point> seeds = GetRegion(points, p, m_eps);

            if (seeds.Count < m_minPts) // no core point

            {

                p.ClusterId = Point.NOISE;

                return false;

            }

            else // all points in seeds are density reachable from point 'p'

            {

                for (int i = 0; i < seeds.Count; i++) seeds[i].ClusterId = clusterId;

                seeds.Remove(p);

                while (seeds.Count > 0)

                {

                    Point currentP = seeds[0];

                    List<Point> result = GetRegion(points, currentP, m_eps);

                    if (result.Count >= m_minPts)

                    {

                        for (int i = 0; i < result.Count; i++)

                        {

                            Point resultP = result[i];

                            if (resultP.ClusterId == Point.UNCLASSIFIED || resultP.ClusterId == Point.NOISE)

                            {

                                if (resultP.ClusterId == Point.UNCLASSIFIED) seeds.Add(resultP);

                                resultP.ClusterId = clusterId;

                            }

                        }

                    }

                    seeds.Remove(currentP);

                }

                return true;

            }

        }

    }
}
