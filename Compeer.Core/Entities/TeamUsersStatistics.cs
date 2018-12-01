using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class TeamUsersStatistics
    {
        [Key]
        public int Id { get; set; } 
        [Timestamp]
        public DateTime TimeStamp { get; set; }
        public virtual TeamUsers User { get; set; }
        public virtual Match Match { get; set; }
        public virtual Queue Queue { get; set; }
        public virtual League League { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Champion Champion { get; set; }
        public int MinionsKilled { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public virtual Lane Lane { get; set; }
        public int TotalGoldFarmed { get; set; }
        public int MagicDamage { get; set; }
        public int PhysicalDamage { get; set; }
        public int TotalDamage { get; set; }
        public int TotalReceivedDamage { get; set; }
        public int DoubleKills { get; set; }
        public int TripleKills { get; set; }
        public int QuadraKills { get; set; }
        public int PentaKills { get; set; }
        public int TotalHeal { get; set; }
        public int TowersDefeated { get; set; }
        public int DragonsDefeated { get; set; }
        public int BaronDefeated { get; set; }
    }
}