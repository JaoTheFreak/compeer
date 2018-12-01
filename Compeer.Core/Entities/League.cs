using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class League
    {
        [Key]
        public int Id { get; set; }

        public virtual Rank Rank { get; set; }

        public int RankLevel { get; set; }

        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}