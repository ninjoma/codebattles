using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.ParticipantServices
{
    public class ParticipantService : MainService<Participant, ParticipantDTO, ParticipantDetailDTO>, IParticipantService
    {
        #region Builder & Properties
        public ParticipantService(IMapper mapper, IRepository<ParticipantDTO, Participant> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties

        public override async Task<ParticipantDetailDTO> GetById(int id, bool isActive = true)
        {
            #pragma warning disable CS8603 //OmniSharp Reconoce la expresion como un tipo simple y siempre da warning de posible referencia nula
            var includes = new List<Expression<Func<Participant, object>>>
            {
                e => e.User,
                e => e.Game
            };
            #pragma warning restore CS8603

            return await _repository.GetById<ParticipantDetailDTO>(id, includes, isActive);
        }

    }
}