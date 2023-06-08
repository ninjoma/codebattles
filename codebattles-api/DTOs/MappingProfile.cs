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

            #region USER
            CreateMap<User, UserDTO>()
                .ReverseMap();

            CreateMap<User, UserDetailDTO>()
                .ReverseMap();

            CreateMap<User, UserDTONoPassword>()
                .ReverseMap();
            #endregion USER

            #region FRIEND
            CreateMap<Friend, FriendDTO>()
                .ReverseMap();
            #endregion FRIEND

            #region GAME
            CreateMap<Game, GameDTO>()
                .ReverseMap();

            CreateMap<Game, GameDetailDTO>()
                .ReverseMap();
            #endregion GAME

            #region GAMEMODE
            CreateMap<GameMode, GameModeDTO>()
                .ReverseMap();

            CreateMap<GameMode, GameModeDetailDTO>()
                .ReverseMap();
            #endregion GAMEMODE

            #region PARTICIPANT
            CreateMap<Participant, ParticipantDTO>()
                .ReverseMap();

            CreateMap<Participant, ParticipantDetailDTO>()
                .ReverseMap();
            #endregion PARTICIPANT

            #region STEP
            CreateMap<Step, StepDTO>()
                .ReverseMap();
            CreateMap<Step, StepDetailDTO>()
            .ReverseMap();
            #endregion STEP

            #region TAG
            CreateMap<Tag, TagDTO>()
                .ReverseMap();

            CreateMap<Tag, TagDetailDTO>()
                .ReverseMap();
            #endregion TAG

            #region BADGE
            CreateMap<Badge, BadgeDTO>()
                .ReverseMap();

            CreateMap<Badge, BadgeDetailDTO>()
                .ReverseMap();
            #endregion BADGE

            #region LANGUAGE
            CreateMap<Language, LanguageDTO>()
                            .ReverseMap();

            CreateMap<Language, LanguageDetailDTO>()
                .ReverseMap();
            #endregion LANGUAGE

            #region VALIDATION
            CreateMap<Validation, ValidationDTO>()
                            .ReverseMap();

            CreateMap<Validation, ValidationDetailDTO>()
                .ReverseMap();
            #endregion VALIDATION
        }
    }
}