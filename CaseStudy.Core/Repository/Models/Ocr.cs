using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Repository.Models
{

	public class Ocr
	{
		public string Description { get; set; }
		public BoundingPoly BoundingPoly { get; set; }
		public static double standardDeviation { get; set; } = 10;
	}
	public class BoundingPoly
	{
        public string Description2 { get; set; }
        public double AvgX { get; set; }
        public double AvgY { get; set; }
        
        public List<Coordinate> Vertices { get; set; }
	}
	public class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }
	}

}
