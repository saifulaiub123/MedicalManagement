using SS.Domain.Model;

namespace SS.Domain.DBModel
{
    public class Permission : BaseModel<int>
    {
        public string Name { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }

    }
}
