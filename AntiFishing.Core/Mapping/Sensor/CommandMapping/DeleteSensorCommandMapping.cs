
namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile
	{
		public void DeleteSensorCommandMapping()
		{
			CreateMap<DeleteSensorCommand, Data.Entities.Sensor>();

		}
	}
}
