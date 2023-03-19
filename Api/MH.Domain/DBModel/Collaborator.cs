using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class Collaborator : BaseModel<int>
    {
        public bool IsDeleted { get; set; }
    }
}
