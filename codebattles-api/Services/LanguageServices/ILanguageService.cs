using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.LanguageServices
{
    public interface ILanguageService : IMainService<LanguageDTO, LanguageDetailDTO, Language>
    {

    }
}