using System.Collections.Generic;

public static class GlobalMembers
{
	static void Main(string[] args)
	{
		RandomNumbers.Seed(time(null));

		int total_points;
		int total_values;
		int K;
		//int max_iterations;
		int has_name;

		total_points = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		total_values = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		K = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		//max_iterations = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		has_name = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

		List<Point> points = new List<Point>();
		string point_name;

		for (int i = 0; i < total_points; i++)
		{
			List<double> values = new List<double>();

			for (int j = 0; j < total_values; j++)
			{
				double value;
				value = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
				values.Add(value);
			}

			if (has_name != 0)
			{
				point_name = ConsoleInput.ReadToWhiteSpace(true);
				Point p = new Point(i, values, point_name);
				points.Add(p);
			}
			else
			{
				Point p = new Point(i, values);
				points.Add(p);
			}
		}

		KMeans kmeans = new KMeans(K, total_points, total_values/*, max_iterations*/);
		kmeans.run(points);
	}






}