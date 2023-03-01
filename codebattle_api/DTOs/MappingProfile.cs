using AutoMapper;
using codebattle_api.Entities;

namespace codebattle_api.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Server, ServerDetailDTO>()
            // .ReverseMap(); //TEMPLATE

            CreateMap<User, UserDTO>()
                .ReverseMap();

            CreateMap<User, UserDetailDTO>()
                .ReverseMap();

            CreateMap<Friend, FriendDTO>()
                .ReverseMap();

            CreateMap<Game, GameDTO>()
                .ReverseMap();

            CreateMap<Game, GameDetailDTO>()
                .ReverseMap();

            CreateMap<GameMode, GameModeDTO>()
                .ReverseMap();

            CreateMap<GameMode, GameModeDetailDTO>()
                .ReverseMap();

            CreateMap<Participant, ParticipantDTO>()
                .ReverseMap();

            CreateMap<Step, StepDTO>()
                .ReverseMap();

            CreateMap<Tag, TagDTO>()
                .ReverseMap();

            CreateMap<Tag, TagDetailDTO>()
                .ReverseMap();


        }
    }
}