using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class TeamUsers
    {
        public int Id { get; set; }

        public virtual MatchTeams Team { get; set; }

        public virtual User User { get; set; }

        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}