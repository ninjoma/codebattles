using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.BadgeServices{
    public class BadgeService : MainService<Badge, BadgeDTO, BadgeDetailDTO>, IBadgeService
    {
        #region Builder & Properties
        public BadgeService(IMapper mapper, IRepository<BadgeDTO, Badge> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}