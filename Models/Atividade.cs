using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMentoria.Models
{
    public class Atividade
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
                
        public int AlunoId { get; set; }
                
        public int ProfessorId { get; set; }

        [Required]        
        public Pessoa Aluno { get; set; }

        [Required]
        public Pessoa Professor { get; set; }

        public string Tema { get; set;}

        [DisplayName("Atividade Código")]
        public int AtividadeCodigo { get; set; }

        [DisplayName("Oportunidade de Aprendizado")]
        public string OpAprendizado { get; set; }

        [DisplayName("Ação de Aprendizado")]
        public string AcAprendizado { get; set; }

        [DisplayName("Data de Mensuração")]
        [DataType(DataType.Date)]
        public DateTime DataMensuracao { get; set; }

        [DisplayName("Forma de Mensuração")]
        public string FormMensuracao { get; set; }

        public string Resultado { get; set; }

        [DisplayName("Comentários")]
        public string Comentario { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
