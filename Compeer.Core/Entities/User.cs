using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Compeer.Core.Entities 
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Summoner Name é Obrigatório")]
        [MaxLength(45)]
        public string SummonerName { get; set; }
        // [Required(ErrorMessage="Summoner Id é Obrigatório")]
        [MaxLength(45)] 
        public Nullable<long> SummonerId { get; set; }
        [Required(ErrorMessage="Password é Obrigatório")]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required(ErrorMessage="Email é Obrigatório")]
        [MaxLength(255)]
        public string Email { get; set; }
        [Timestamp]
        public DateTime TimeStamp { get; set; }

    }

}
