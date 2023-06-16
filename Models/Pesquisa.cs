using System;
using System.ComponentModel.DataAnnotations;

namespace SiteMentoria.Models
{
    public class Pesquisa
    {
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
                
        public Pessoa Aluno { get; set; }

        public Pessoa Professor { get; set; }

        public int Status { get; set; }
    }
}
