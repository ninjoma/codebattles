using codebattle_api.DTO;
using codebattle_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    public abstract class MainController<IService, PostDTO, DetailDTO> : ControllerBase where PostDTO : BaseDTO where DetailDTO : BaseDTO where IService : IMainService<PostDTO, DetailDTO>
    {
        protected readonly IService _service;
        public MainController(IService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}")]
        public async Task<DetailDTO> Get(int id)
        {
            return await _service.GetById(id);
        }

        [HttpGet("")]
        public async Task<IEnumerable<DetailDTO>> List()
        {
            return await _service.GetList();
        }

        [HttpPut("{id}")]
        public async Task<PostDTO> Update(int id, [FromBody] PostDTO postDto){
            postDto.Id = id;
            return await _service.EditById(postDto);
        }

        [HttpPost("")]
        public async Task<PostDTO> Create([FromBody] PostDTO postDTO){
            return await _service.Add(postDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id, [FromBody] bool isDbDelete = false){
            return await _service.DeleteById(id, isDbDelete);
        }

    }
}