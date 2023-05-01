using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Infrastructure.DBContext;

namespace SS.Infrastructure.UnitOfWork
{
    public class BaseUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseUnitOfWork(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void ClearChangeTracker()
        {
            _dbContext.ChangeTracker.Clear();
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
