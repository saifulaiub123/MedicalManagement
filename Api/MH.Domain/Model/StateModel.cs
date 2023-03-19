using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;

namespace MH.Domain.Model
{
    public class StateModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

    }
}
