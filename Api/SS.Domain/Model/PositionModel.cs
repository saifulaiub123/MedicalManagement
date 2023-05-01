using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Domain.Model;

namespace SS.Domain.Model
{
    public class PositionModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
