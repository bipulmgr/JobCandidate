using System.Linq.Expressions;

namespace JobCandidate.Core.Interfaces.Repositories;
/// <summary>
/// Represents a generic repository for data access operations.
/// </summary>
/// <typeparam name="T">The type of entity the repository works with.</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A collection of all entities.</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Finds entities based on a predicate asynchronously.
    /// </summary>
    /// <param name="predicate">The condition to filter entities.</param>
    /// <returns>A collection of entities that match the condition.</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Retrieves an entity by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves the first or default entity based on a predicate asynchronously.
    /// </summary>
    /// <param name="predicate">The condition to filter entities.</param>
    /// <returns>The first or default entity that matches the condition; otherwise, null.</returns>
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes an entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    Task DeleteAsync(T entity);
}
