using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.UnitOfWork;
using MH.Infrastructure.DBContext;
using MH.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Infrastructure.UnitOfWork
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #region Repositories

        private IContactDetailsRepository _contactDetailsRepository;
        public IContactDetailsRepository ContactDetailsRepository => _contactDetailsRepository ?? new ContactDetailsRepository(_dbContext);

        private IPositionRepository _positionRepository;
        public IPositionRepository PositionRepository => _positionRepository ?? new PositionRepository(_dbContext);
        private IUserProfileRepository _userProfileRepository;
        public IUserProfileRepository UserProfileRepository => _userProfileRepository ?? new UserProfileRepository(_dbContext);
        #endregion
    }
}
