using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.RazorPages.Models
{
    public class PessoaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome é obrigatório!")]
        public string? Nome { get; set; }
        
        [Required(ErrorMessage ="Nome é obrigatório!")]
        public string? Sobrenome { get; set; }
    }
}