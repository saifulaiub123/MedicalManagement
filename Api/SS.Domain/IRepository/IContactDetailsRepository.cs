using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Domain.DBModel;

namespace SS.Domain.IRepository
{
    public interface IContactDetailsRepository : IRepository<ContactDetails, int>
    {
        
    }
}
