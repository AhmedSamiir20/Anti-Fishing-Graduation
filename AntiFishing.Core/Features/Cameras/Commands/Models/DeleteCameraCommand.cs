namespace AntiFishing.Core.Features.Cameras.Commands.Models
{
	public class DeleteCameraCommand : IRequest<Response<string>>
	{
		public int CameraId { get; set; }
	}
}
