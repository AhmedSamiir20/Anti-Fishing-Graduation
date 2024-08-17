namespace AntiFishing.Data.AppMetaData
{
	public static class Router
	{
		public const string root = "Api";
		public const string version = "V1";
		public const string Rule = root + "/" + version + "/";

		public static class LakeRouting
		{
			public const string Prefix = Rule + "Lake";
			public const string NamesList = Prefix + "/NameList";
			public const string List = Prefix + "/List";
			public const string Paginated = Prefix + "/PaginatedList";
			public const string Single = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
			public const string Update = Prefix + "/Update";
			public const string Delete = Prefix + "/Delete";
		}
		public static class RegionRouting
		{
			public const string Prefix = Rule + "Region";
			public const string ListName = Prefix + "/NameList";
			public const string List = Prefix + "/List";
			public const string Paginated = Prefix + "/PaginatedList";
			public const string Single = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
			public const string Update = Prefix + "/Update";
			public const string Delete = Prefix + "/Delete";
		}
		public static class SensorRouting
		{
			public const string Prefix = Rule + "Sensor";
			public const string NameList = Prefix + "/NameList";
			public const string ListByRegion = Prefix + "/List/ByRegionId";
			public const string List = Prefix + "/List";
			public const string Single = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
			public const string Update = Prefix + "/Update";
			public const string Delete = Prefix + "/Delete";
		}
		public static class CameraRouting
		{
			public const string Prefix = Rule + "Camera";
			public const string NamesList = Prefix + "/NameList";
			public const string List = Prefix + "/List";
			public const string Single = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
			public const string Update = Prefix + "/Update";
			public const string Delete = Prefix + "/Delete";
		}

		public static class FishRouting
		{
			public const string Prefix = Rule + "Fish";
			public const string List = Prefix + "/List";
			public const string Single = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
			public const string Update = Prefix + "/Update";
			public const string Delete = Prefix + "/Delete";
		}
		public static class ScheduleRouting
		{
			public const string Prefix = Rule + "Schedule";
			public const string List = Prefix + "/List";
			public const string Single = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
			public const string Update = Prefix + "/Update";
			public const string Delete = Prefix + "/Delete";
		}
		public static class InstructionRouting
		{
			public const string Prefix = Rule + "Instruction";
			public const string List = Prefix + "/List";
			public const string Single = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
			public const string Update = Prefix + "/Update";
			public const string Delete = Prefix + "/Delete";
		}
	}
}
