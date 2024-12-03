using System.Linq.Expressions;
using JobCandidate.Core.Interfaces.Repositories;
using JobCandidate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Infrastructure.Repositories;
/// <summary>
/// Provides a generic implementation of the IRepository interface.
/// </summary>
/// <typeparam name="T">The type of entity the repository works with.</typeparam>
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Retrieves all entities from the database.
    /// </summary>
    /// <returns>A collection of entities.</returns>
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Finds entities based on a predicate.
    /// </summary>
    /// <param name="predicate">The predicate to filter the entities.</param>
    /// <returns>A collection of entities that match the predicate.</returns>
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    /// <summary>
    /// Adds a new entity to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
