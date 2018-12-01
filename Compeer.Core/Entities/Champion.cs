using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class Champion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Champion Name é Obrigatório")]
        [MaxLength(45)]
        public string Name { get; set; }

        public virtual Role Role { get; set; }

        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}