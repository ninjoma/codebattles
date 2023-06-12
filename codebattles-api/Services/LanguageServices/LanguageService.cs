using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.LanguageServices
{
    public class LanguageService : MainService<Language, LanguageDTO, LanguageDetailDTO>, ILanguageService
    {
        #region Builder & Properties
        public LanguageService(IMapper mapper, IRepository<LanguageDTO, Language> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}