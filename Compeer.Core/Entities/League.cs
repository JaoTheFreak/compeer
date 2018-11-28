using System;

namespace Compeer.Core.Entities
{
    public class League
    {
        public int Id { get; set; }

        public int RankId { get; set; }

        public int RankLevel { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}