using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Infrastructure.DBContext;

namespace SS.Infrastructure.Repository
{
    public class ContactDetailsRepository : Repository<ContactDetails, int>, IContactDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactDetailsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
