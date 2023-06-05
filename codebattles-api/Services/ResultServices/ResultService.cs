using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.ResultServices
{
    public class ResultService : MainService<Result, ResultDTO, ResultDetailDTO>, IResultService
    {
        #region Builder & Properties
        public ResultService(IMapper mapper, IRepository<ResultDTO, Result> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}