namespace AntiFishing.Core.Features.Sensors.Commands.Models
{
	public class DeleteSensorCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
	}
}
