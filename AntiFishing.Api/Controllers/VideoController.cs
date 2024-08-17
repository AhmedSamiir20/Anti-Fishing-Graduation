

namespace AntiFishing.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideoController : ControllerBase
	{
		private readonly string _uploadPath = Path.Combine("wwwroot", "videos");
		private readonly IWebHostEnvironment _environment;
		private readonly IVideoRepository _videoRepository;
		private readonly HttpClient _httpClient;
		private readonly ICameraService _cameraService;
		private readonly IMapper _mapper;

		public VideoController(IWebHostEnvironment environment, IVideoRepository videoRepository, HttpClient httpClient, ICameraService cameraService, IMapper mapper)
		{
			_environment = environment;
			_videoRepository = videoRepository;
			_httpClient = httpClient;
			_cameraService = cameraService;
			_mapper = mapper;
		}

		[HttpPost("upload")]
		public async Task<IActionResult> UploadVideo(IFormFile videoFile, string name, int cameraId)
		{
			if (videoFile == null || videoFile.Length == 0)
			{
				return BadRequest("Invalid file.");
			}

			try
			{
				Directory.CreateDirectory(_uploadPath);

				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(videoFile.FileName);
				string filePath = Path.Combine(_uploadPath, fileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await videoFile.CopyToAsync(stream);
				}


				string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
				string videoUrl = $"{baseUrl}/videos/{fileName}";

				var camera = await _cameraService.GetCameraByIdAsync(cameraId);
				var video = new Video
				{
					Name = name,
					VideoUrl = videoUrl,
					UploadedAt = DateTime.Now,
					CameraId = camera.CameraId,
				};

				await _videoRepository.AddVideoAsync(video);
				var videoMapper = _mapper.Map<VideoDto>(video);
				return Ok(video);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
			}
		}




		[HttpGet("byname")]
		public async Task<IActionResult> GetVideoUrl(string name)
		{
			var video = await _videoRepository.GetVideoByNameAsync(name);
			return Ok(video?.VideoUrl);
		}

		[HttpGet()]
		public async Task<IActionResult> GetVideos()
		{
			var videos = await _videoRepository.GetAllVideosAsync();
			return Ok(videos);
		}

		[HttpGet("LastVideo")]
		public async Task<IActionResult> GetLastVideo()
		{
			var video = _mapper.Map<VideoDto>(await _videoRepository.GetLastVideoAsync());
			return Ok(video);
		}


		[HttpPost("Count-last-video")]
		public async Task<IActionResult> AnalyzeLastVideo()
		{
			//BackgroundJob.Schedule(() => StatusLastVideo(), TimeSpan.FromHours(12));
			var lastVideo = await _videoRepository.GetLastVideoAsync();
			if (lastVideo == null)
			{
				return NotFound("No video found.");
			}
			try
			{
				var fileName = Path.GetFileName(lastVideo.VideoUrl);
				var filePath = Path.Combine(_environment.WebRootPath, "videos", fileName);

				using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
				using var form = new MultipartFormDataContent();
				using var streamContent = new StreamContent(fileStream);
				streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");
				form.Add(streamContent, "video", Path.GetFileName(filePath));

				_httpClient.Timeout = TimeSpan.FromMinutes(5);

				Console.WriteLine("Sending request to Flask server...");

				var response = await _httpClient.PostAsync("https://e235-41-69-226-175.ngrok-free.app/upload", form);

				Console.WriteLine($"Response status code: {(int)response.StatusCode}");

				if (!response.IsSuccessStatusCode)
				{
					var errorResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine($"Error response from Flask service: {errorResponse}");
					return StatusCode((int)response.StatusCode, "Error from Flask service");
				}

				var responseData = await response.Content.ReadAsStringAsync();

				var flaskResponse = JsonSerializer.Deserialize<FlaskResponse>(responseData);
				lastVideo.FishCount = flaskResponse.Count;

				await _videoRepository.UpdateVideoAsync(lastVideo);

				var updatedVideo = await _videoRepository.GetLastVideoAsync();
				var videoMapper = _mapper.Map<VideoDto>(updatedVideo);
				return Ok(videoMapper);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception occurred: {ex.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}



		[HttpPost("status-last-video")]
		public async Task<IActionResult> StatusLastVideo()
		{
			//BackgroundJob.Schedule(() => StatusLastVideo(), TimeSpan.FromHours(12));

			var lastVideo = await _videoRepository.GetLastVideoAsync();
			if (lastVideo == null)
			{
				return NotFound("No video found.");
			}
			try
			{
				var fileName = Path.GetFileName(lastVideo.VideoUrl);
				var filePath = Path.Combine(_environment.WebRootPath, "videos", fileName);

				using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
				using var form = new MultipartFormDataContent();
				using var streamContent = new StreamContent(fileStream);
				streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");
				form.Add(streamContent, "video", Path.GetFileName(filePath));

				_httpClient.Timeout = TimeSpan.FromMinutes(5);

				Console.WriteLine("Sending request to Flask server...");

				var response = await _httpClient.PostAsync("https://d1d7-102-186-19-199.ngrok-free.app/detection", form);

				Console.WriteLine($"Response status code: {(int)response.StatusCode}");

				if (!response.IsSuccessStatusCode)
				{
					var errorResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine($"Error response from Flask service: {errorResponse}");
					return StatusCode((int)response.StatusCode, "Error from Flask service");
				}
				var responseData = await response.Content.ReadAsStringAsync();

				var flaskResponse = JsonSerializer.Deserialize<FlaskResponse>(responseData);
				lastVideo.FishStatus = flaskResponse.Status;

				await _videoRepository.UpdateVideoAsync(lastVideo);

				var updatedVideo = await _videoRepository.GetLastVideoAsync();

				return Ok(lastVideo);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception occurred: {ex.Message}");
				return StatusCode(500, "Internal server error.");
			}
		}

		[HttpGet("All-Videos")]
		public async Task<IActionResult> GetAllVideos()
		{
			return Ok(_mapper.Map<VideoDto>(await _videoRepository.GetAllVideosAsync()));
		}

		[HttpDelete("id")]
		public async Task<IActionResult> DeleteVideo(int videoId)
		{
			var delete = await _videoRepository.DeleteVideoAsync(videoId);
			if (delete != "Successfully Deleted")
				return NotFound("There is no video by this id");
			return Ok(delete);
		}

	}
}
