using System.Net;
using codebattle_api.DTO;
using codebattle_api.Exceptions;
using codebattle_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    /// <summary>
    /// Main Controller for all the entities
    /// </summary>
    /// <typeparam name="IService"></typeparam>
    /// <typeparam name="PostDTO"></typeparam>
    /// <typeparam name="DetailDTO"></typeparam>
    /// <typeparam name="Entity"></typeparam>
    public abstract class MainController<IService, PostDTO, DetailDTO, Entity> : ControllerBase where PostDTO : BaseDTO where DetailDTO : BaseDTO where IService : IMainService<PostDTO, DetailDTO, Entity>
    {
        #region Builder & Properties
        protected readonly IService _service;
        public MainController(IService service)
        {
            _service = service;
        }
        #endregion Builder & Properties

        /// <summary>
        /// (Autogenerated) Returns a desired entity based on its Database Id
        /// </summary>
        /// <param name="id">Database Id of the desired Entity</param>
        /// <returns>Detail DTO of the desired Entity</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetById(id);
            return result != null ? Ok(result) : NotFound(new ErrorResponse(new CodeBattleException(ErrorCode.NotFound)));
        }

        /// <summary>
        /// (Autogenerated) Edits a desired Entity based on its Database Id
        /// </summary>
        /// <param name="id">Database Id of the desired Entity</param>
        /// <param name="postDto">New Content of the Entity</param>
        /// <returns>DTO of the edited entity</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] PostDTO postDto)
        {
            try
            {
                postDto.Id = id;
                var result = await _service.EditById(postDto);
                return Ok(result);
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }

        /// <summary>
        /// (Autogenerated) Creates a new Entity
        /// </summary>
        /// <param name="postDTO">New Entity content</param>
        /// <returns>DTO of the new Entity</returns>
        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<IActionResult> Create([FromBody] PostDTO postDTO)
        {
            try
            {
                var result = await _service.Add(postDTO);
                return Ok(result);
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }

        /// <summary>
        /// (Autogenerated) Deletes a desired Entity by its Database Id
        /// </summary>
        /// <param name="id">Database Id of the desired Entity</param>
        /// <param name="isDbDelete">Defines if the delete is going to be logical or physical</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<IActionResult> Delete(int id, [FromBody] bool isDbDelete = false)
        {
            try
            {
                var result = await _service.DeleteById(id, isDbDelete);
                return Ok(result);
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }

        /// <summary>
        /// Method that maps errors automatically
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected IActionResult ReturnError(CodeBattleException ex)
        {
            switch (ex.ErrorCode)
            {
                case ErrorCode.WrongLoginData:
                case ErrorCode.MissingData:
                    return BadRequest(new ErrorResponse(ex));
                case ErrorCode.Unauthorized:
                    return Unauthorized(new ErrorResponse(ex));
                default:
                    return BadRequest(new ErrorResponse(ex));
            }
        }

    }
}