using System.ComponentModel.DataAnnotations;

namespace SiteEmprestimos.Models
{
    public class EmprestimosModel : Entity
    {
        [Required(ErrorMessage = "Nome do Recebedor é obrigatório")]
        public string? Recebedor { get; set; }

        [Required(ErrorMessage = "Nome do Fornecedor é obrigatório")]
        public string? Fornecedor { get; set; }

        [Required(ErrorMessage = "Nome do Livro é obrigatório")]
        public string? LivroEmprestado { get; set; }

        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
    }
}
