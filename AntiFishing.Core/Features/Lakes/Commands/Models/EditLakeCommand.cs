namespace AntiFishing.Core.Features.Lakes.Commands.Models
{
	public class EditLakeCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }


		public string Name { get; set; }


		public string Info { get; set; }


		public string Location { get; set; }

		[Required]
		public string Area { get; set; }

		[Required]
		public string Depth { get; set; }
	}
}
