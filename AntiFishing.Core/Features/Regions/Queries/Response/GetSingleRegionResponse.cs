
namespace AntiFishing.Core.Features.Regions.Queries.Response
{
	public class GetSingleRegionResponse
	{
		public int id { get; set; }

		public string RegionName { get; set; }

		public string RegionDescription { get; set; }

		public string RegionWidth { get; set; }

		public Lake Lake { get; set; }

		public ICollection<Sensor>? Sensors { get; set; }

		public ICollection<Camera>? Cameras { get; set; }


















		//	namespace antifishing.core.features.lakes.queries.response
		//{
		//	public class getlakelistresponse
		//	{
		//		public int id { get; set; }

		//		public string name { get; set; }

		//		public string info { get; set; }

		//		public string location { get; set; }

		//		public double area { get; set; }

		//		public double depth { get; set; }

		//		public int cameraid { get; set; }

		//		public string cameraname { get; set; }

		//		public string camerainfo { get; set; }

		//		public string cameraregionname { get; set; }

		//		public int sensorid { get; set; }

		//		public string sensorname { get; set; }

		//		public string sensortype { get; set; }

		//		public string sensordescription { get; set; }

		//		public string sensorregionname { get; set; }

		//		public double countoffish { get; set; }

		//		public int regionid { get; set; }

		//		public string regionname { get; set; }

		//		public string regiondescription { get; set; }

		//		public string regionwidth { get; set; }

		//		public list<schedule> schedules { get; set; }
		//	}
		//}









	}
}
