using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.StepServices{
    public class StepService : MainService<Step, StepDTO, StepDTO>, IStepService
    {
        #region Builder & Properties
        public StepService(IMapper mapper, IRepository<StepDTO, Step> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}