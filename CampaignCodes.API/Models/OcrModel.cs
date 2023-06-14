namespace CampaignCodes.API.Models
{
	public class OcrModel
	{
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }
    }
	public class BoundingPoly
	{
        public List<Coordinate> Vertices { get; set; }
    }
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
