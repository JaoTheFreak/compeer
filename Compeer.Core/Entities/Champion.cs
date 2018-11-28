using System;

namespace Compeer.Core.Entities
{
    public class Champion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}