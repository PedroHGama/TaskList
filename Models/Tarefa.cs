using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskList.Models
{
    public class Tarefa
    {
        [Key]
        public int IdTarefa { get; set; }  // Nome ajustado para PascalCase

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }  // Descrição da tarefa

        [Required(ErrorMessage = "O status é obrigatório.")]
        public string Status { get; set; }  // Status da tarefa (A fazer, Fazendo, Pronto)

        [Required(ErrorMessage = "A prioridade é obrigatória.")]
        public string Prioridade { get; set; }  // Prioridade (Baixa, Média, Alta)

        [Required]
        public DateTime DataCadastro { get; set; }  // Data de cadastro da tarefa

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }  // Chave estrangeira para o usuário

        [Required]
        [ForeignKey("Setor")]
        public int IdSetor { get; set; }  // Chave estrangeira para o setor

        // Propriedades de navegação
        public Usuario Usuario { get; set; }
        public Setor Setor { get; set; }
    }
}
