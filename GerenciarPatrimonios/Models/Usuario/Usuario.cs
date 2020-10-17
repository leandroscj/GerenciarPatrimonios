using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarPatrimonios.Models.Usuario
{
    [Table(nameof(Usuario))]
    public class Patrimonio
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do Usuario é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória", AllowEmptyStrings = false)]
        public int Senha { get; set; }

        [Key]
        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O Email é obrigatório", AllowEmptyStrings = false)]
        public string Email { get; set; }
    }
}