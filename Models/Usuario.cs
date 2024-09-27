using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do usuário deve ter no máximo 100 caracteres.")]
        public string NomeUsuario { get; set; }  // Nome do usuário

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
        public string EmailUsuario { get; set; }  // E-mail do usuário

        // Relação de navegação (1:N) - Um usuário pode ter várias tarefas
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
