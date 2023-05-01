using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Domain.UnitOfWork;
using SS.Infrastructure.DBContext;
using SS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #region Repositories
        private IUserProfileRepository _userProfileRepository;
        public IUserProfileRepository UserProfileRepository => _userProfileRepository ?? new UserProfileRepository(_dbContext);
        #endregion
    }
}
