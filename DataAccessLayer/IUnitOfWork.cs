using CarService.Model;
using CarService.Repository;

namespace DataAccessLayer;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : EntityBase;

    void Commit();

    void Rollback();
}