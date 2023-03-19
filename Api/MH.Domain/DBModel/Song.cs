using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class Song : BaseModel<int>
    {
        public bool IsDeleted { get; set; }
    }
}
