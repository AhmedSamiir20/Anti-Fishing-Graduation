namespace AntiFishing.Core.Features.Cameras.Commands.Models
{
	public class AddCameraCommand : IRequest<Response<string>>
	{
		[Required, MaxLength(100)]
		public string Name { get; set; }

		[Required, MaxLength(500)]
		public string Info { get; set; }

		public int LakeId { get; set; }

		public int RegionId { get; set; }
	}
}
