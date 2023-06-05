using System.Linq.Expressions;

namespace codebattle_api.Repositories
{
    public interface IRepository<PostDTO, Entity> : IDisposable where PostDTO : class
    {
        /// <summary>
        /// Gets a list of Mapped Objects
        /// </summary>
        /// <typeparam name="returnDTO">Type of Mapped Object returned</typeparam>
        /// <param name="includes">Expression that defines which relations to include</param>
        /// <param name="isActive">Bool that defines Wether to get the not deleted or deleted Entities</param>
        /// <returns>IEnumerable of Mapped Objects</returns>
        Task<IEnumerable<returnDTO>> List<returnDTO>(List<Expression<Func<Entity, object>>>? includes = null, bool isActive = true);

        /// <summary>
        /// Gets a mapped object based on a id
        /// </summary>
        /// <typeparam name="returnDTO">Type of Mapped Object returned</typeparam>
        /// <param name="id">id of the desired entity</param>
        /// <param name="includes">Expression that defines which relations to include</param>
        /// <param name="isActive">Bool that defines Wether to get the not deleted or deleted Entities</param>
        /// <returns>Mapped Object</returns>
        Task<returnDTO> GetById<returnDTO>(int id, List<Expression<Func<Entity, object>>>? includes = null, bool isActive = true);

        /// <summary>
        /// Gets a mapped object based on a lambda expression
        /// </summary>
        /// <typeparam name="returnDTO">Type of Mapped Object returned</typeparam>
        /// <param name="specification">Expression that defines the specficiations to match</param>
        /// <param name="includes">Expression that defines which relations to include</param>
        /// <returns>Mapped Object</returns>
        Task<returnDTO> GetBySpec<returnDTO>(Expression<Func<Entity, bool>> specification, List<Expression<Func<Entity, object>>>? includes = null);

        /// <summary>
        /// Gets a list of mapped objects based on a lambda expression
        /// </summary>
        /// <typeparam name="returnDTO">Type of Mapped Object returned</typeparam>
        /// <param name="specification">Expression that defines the specficiations to match</param>
        /// <param name="selectExpression">Expression that defines which fields to exclude from getting</param>
        /// <param name="includes">Expression that defines which relations to include</param>
        /// <returns>IEnumerable of Mapped Object</returns>
        Task<IEnumerable<returnDTO>> ListBySpec<returnDTO>(Expression<Func<Entity, bool>> specification, List<Expression<Func<Entity, object>>>? includes = null, Expression<Func<Entity, Entity>>? selectExpression = null);

        /// <summary>
        /// Creates a new entity in de DB
        /// </summary>
        /// <param name="newDto">New entity DTO</param>
        /// <returns>Created Mapped Object</returns>
        Task<PostDTO> Add(PostDTO newDto);

        /// <summary>
        /// Deletes by logic a DB Entity
        /// </summary>
        /// <param name="id">id of the desired entity</param>
        /// <returns>Confirmation of deletion</returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Deletes Completely a DB Entity
        /// </summary>
        /// <param name="id">id of the desired entity</param>
        /// <returns>Confirmation of deletion</returns>
        Task<bool> DbDelete(int id);

        /// <summary>
        /// Edits a DB Entity
        /// </summary>
        /// <param name="newDto">desired entity with changes</param>
        /// <returns>Edited Mapped Entity</returns>
        Task<PostDTO> Edit(PostDTO newDto);

        /// <summary>
        /// Forces the save of the current context state 
        /// </summary>
        /// <returns>Confirmation of saving</returns>
        Task<bool> Save();
    }
}