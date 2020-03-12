using System;
using AutoMapper;
using Blog.Models.Posts;

namespace Blog.Services.Posts
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostRequest, Post>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.CreatedUser, opt => opt.MapFrom(p => p.UserId));
        }
    }
}
