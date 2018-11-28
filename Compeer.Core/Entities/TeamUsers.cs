using System;

namespace Compeer.Core.Entities
{
    public class TeamUsers
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}