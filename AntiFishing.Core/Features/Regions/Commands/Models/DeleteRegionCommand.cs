namespace AntiFishing.Core.Features.Regions.Commands.Models
{
	public class DeleteRegionCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
	}
}
