using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class Rank
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Rank Name é Obrigatório")]
        [MaxLength(45)]
        public string Name { get; set; }
        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}