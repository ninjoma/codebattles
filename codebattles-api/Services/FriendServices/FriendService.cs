using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.FriendServices{
    public class FriendService : MainService<Friend, FriendDTO, FriendDetailDTO>, IFriendService
    {
        #region Builder & Properties
        public FriendService(IMapper mapper, IRepository<FriendDTO, Friend> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}