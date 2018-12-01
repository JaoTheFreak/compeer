using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Role Name é Obrigatório")]
        [MaxLength(45)]
        public string Name { get; set; }
        [Timestamp]
        public DateTime TimeStamp { get; set; }
    }
}