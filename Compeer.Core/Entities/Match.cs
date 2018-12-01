using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        public virtual Queue Queue { get; set; }
        public virtual League League { get; set; }
        public virtual Rank Rank { get; set; }
        public int GameNumber { get; set; }
        [MaxLength(45)]
        public string GameMode { get; set; }
        [MaxLength(45)]
        public string GameType { get; set; }
    }
}