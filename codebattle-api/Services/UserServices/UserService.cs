using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.UserServices{
    public class UserService : IUserService
    {
        #region Builder & Properties
        private readonly IMapper _mapper;
        private readonly IRepository<UserDTO, User> _userRepository;

        public UserService(IMapper mapper, IRepository<UserDTO, User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        #endregion Builder & Properties

        public async Task<UserDTO> Add(UserDTO entryDTO)
        {
            return await _userRepository.Add(entryDTO);
        }

        public async Task<bool> DeleteById(int id, bool isDbDelete = false)
        {
            if (isDbDelete){
                return await _userRepository.DbDelete(id);
            } else {
                return await _userRepository.Delete(id);
            }
        }

        public async Task<UserDTO> EditById(UserDTO entryDTO)
        {
            return await _userRepository.Edit(entryDTO);
        }

        public async Task<IEnumerable<UserDetailDTO>> GetList(bool isActive){
            return await _userRepository.List<UserDetailDTO>(x => x.Friends , isActive);
        }

        public async Task<UserDetailDTO> GetById(int id, bool isActive = true)
        {
            return await _userRepository.GetById<UserDetailDTO>(id, x => x.Friends , isActive);
        }
    }
}