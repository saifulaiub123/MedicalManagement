using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Domain.Model
{
    public class CountryModel
    {
        public int? Id { get; set; }
        public int ShortName { get; set; }
        public int Name { get; set; }
        public int PhoneCode { get; set; }

    }
}
