using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteMentoria.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("É Professor?")]
        public bool IsProfessor { get; set; }  
    }
}
