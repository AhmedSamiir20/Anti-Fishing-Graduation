using System.Text.Json.Serialization;

namespace AntiFishing.Api.Flask
{
	public class FlaskResponse
	{
		[JsonPropertyName("count")]
		public int Count { get; set; }

		[JsonPropertyName("Status")]
		public string Status { get; set; }
	}
}
