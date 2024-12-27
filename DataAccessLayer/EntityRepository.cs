using System.Linq.Expressions;
using CarService.Model;
using Microsoft.EntityFrameworkCore;

namespace CarService.Repository;

public class EntityRepository<T>(DbContext dbContext) : IRepository<T> where T : EntityBase
{
    private readonly DbSet<T> dbSet = dbContext.Set<T>();

    public T? GetById(int id)
    {
        return dbSet.SingleOrDefault(entity => entity.Id == id);
    }

    public List<T> GetAll(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
    )
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }

        return query.ToList();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }
}