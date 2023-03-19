﻿using MH.Domain.Model;

namespace MH.Domain.DBModel
{
    public class State : BaseModel<int>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<UserProfile> UserProfile { get; set; }

    }
}
