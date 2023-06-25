using AutoMapper;
using ApiComment.Models;
using ApiComment.Dtos;

namespace ApiComment
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CommentDto, Comment>();
                config.CreateMap<Comment, CommentDto>();
            });
            return mappingConfig;
        }
    }
}
