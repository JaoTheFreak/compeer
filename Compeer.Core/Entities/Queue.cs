using System;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities
{
    public class Queue
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Nome da Fila é obrigatório")]
        [MaxLength(50)]
        public string QueueName { get; set; }
        [Required(ErrorMessage="Denominador da Fila é Obrigatório")]
        [MaxLength(50)]
        public int QueuePvpDenominator { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        [Timestamp]
        public DateTime UpdatedAt { get; set; }
    }
}