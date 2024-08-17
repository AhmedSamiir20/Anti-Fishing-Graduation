namespace AntiFishing.Core.Features.Regions.Commands.Models
{
	public class EditRegionCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		public string RegionName { get; set; }

		public string RegionDescription { get; set; }

		public string RegionWidth { get; set; }

		public int? LakeId { get; set; }
	}
}
