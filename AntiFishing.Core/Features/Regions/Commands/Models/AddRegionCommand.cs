namespace AntiFishing.Core.Features.Regions.Commands.Models
{
	public class AddRegionCommand : IRequest<Response<string>>
	{
		public string RegionName { get; set; }

		public string RegionDescription { get; set; }

		public string RegionWidth { get; set; }

		public int LakeId { get; set; }
	}
}
