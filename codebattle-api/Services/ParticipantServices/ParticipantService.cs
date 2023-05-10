using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.ParticipantServices{
    public class ParticipantService : MainService<Participant, ParticipantDTO, ParticipantDTO>, IParticipantService
    {
        #region Builder & Properties
        public ParticipantService(IMapper mapper, IRepository<ParticipantDTO, Participant> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}