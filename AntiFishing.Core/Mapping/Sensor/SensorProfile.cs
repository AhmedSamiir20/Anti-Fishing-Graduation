namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile : Profile
	{
		public SensorProfile()
		{
			GetSensorListMapping();
			GetSensorByIdMapping();
			AddSensorCommandMapping();
			EditSensorCommandMapping();
			DeleteSensorCommandMapping();
			GetNameSensorListMapping();
			GetSensorListByRegionIdMapping();
		}
	}
}
