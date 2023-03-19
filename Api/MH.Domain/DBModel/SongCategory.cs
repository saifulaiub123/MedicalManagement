using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class SongCategory : BaseModel<int>
    {
        public bool IsDeleted { get; set; }
    }
}
