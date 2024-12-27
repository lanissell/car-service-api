using CarService.Model;
using CarService.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext dbContext;

    public UnitOfWork(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IRepository<T> GetRepository<T>() where T : EntityBase
    {
        return new EntityRepository<T>(dbContext);
    }

    public void Commit()
    {
        dbContext.SaveChanges();
    }

    public void Rollback()
    {
        foreach (var entry in dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }
}