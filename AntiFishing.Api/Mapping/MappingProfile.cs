using AntiFishing.Api.AuthDto;
using AntiFishing.Data.Entities;
using AntiFishing.Infrastructure.AuthDto;
using AutoMapper;

namespace AntiFishing.Infrastructure.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, GetUserResponse>();
			CreateMap<User, GetNameUserResponse>();
			CreateMap<Video, VideoDto>()
				.ForMember(dest => dest.CameraName, opt => opt.MapFrom(sorc => sorc.Camera.Name));
		}
	}
}
