using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class MatchTeams
    {
        [Key]
        public int Id { get; set; }
        public virtual Match Match { get; set; }
        public bool Win { get; set; }
        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}