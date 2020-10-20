using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarPatrimonios.Models.Marca
{
    [Table(nameof(Marca))]
    public class Marca
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome da marca é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Key]
        [Column("MarcaId")]
        [Display(Name = "MarcaId")]
        [Required(ErrorMessage = "O numero da marca é obrigatório", AllowEmptyStrings = false)]
        public string MarcaId { get; set; }
    }
}