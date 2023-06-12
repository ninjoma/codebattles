using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.ValidationServices
{
    public class ValidationService : MainService<Validation, ValidationDTO, ValidationDetailDTO>, IValidationService
    {
        #region Builder & Properties
        public ValidationService(IMapper mapper, IRepository<ValidationDTO, Validation> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}