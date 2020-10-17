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

        [Column("Id")]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O numero da marca é obrigatório", AllowEmptyStrings = false)]
        public int MarcaId { get; set; }
    }
}