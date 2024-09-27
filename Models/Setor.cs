using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class Setor
    {

        [Key]
        public int IdSetor { get; set; }

        [Required(ErrorMessage = "O nome do setor é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do setor deve ter no máximo 50 caracteres.")]
        public string NomeSetor { get; set; }  // Nome do setor

        // Relação de navegação (1:N) - Um setor pode ter várias tarefas
        public virtual ICollection<Setor> Setores { get; set; }
    }
}
