using Microsoft.EntityFrameworkCore;

namespace _01_Feactures.Infrastructure;

public class UnitOfWorkEf : IUnitOfWork
{
    private readonly DbContext _context;
    public void BeginTran()
    {
        _context.Database.BeginTransaction();
    }

    public void CommitTran()
    {
        _context.SaveChanges();
        _context.Database.CommitTransaction();
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }
}