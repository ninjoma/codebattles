using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.ResultServices
{
    public interface IResultService : IMainService<ResultDTO, ResultDetailDTO, Result>
    {

    }
}