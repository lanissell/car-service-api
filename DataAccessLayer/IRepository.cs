using System.Linq.Expressions;
using CarService.Model;

namespace CarService.Repository;

public interface IRepository<T> where T: EntityBase
{
    T? GetById(int id);

    List<T> GetAll(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        );

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}