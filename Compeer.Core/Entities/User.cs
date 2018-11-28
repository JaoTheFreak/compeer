using System;
using System.Collections.Generic;

namespace Compeer.Core.Entities 
{
    public class User 
    {
        public int Id { get; set; }

        public string SummonerName { get; set; }

        public long SummonerId { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public ICollection<TeamUsers> Teams { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

}
