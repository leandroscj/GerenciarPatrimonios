﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarPatrimonios.Models.Patrimonio
{
    [Table(nameof(Patrimonio))]
    public class Patrimonio
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do Patrimonio é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Key]
        [Column("Id")]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O numero da marca é obrigatório", AllowEmptyStrings = false)]
        public string MarcaId { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição do Patrimonio")]
        public string Descricao { get; set; }

        [Column("NumeroTombo")]
        [Display(Name = "Numero do tombo")]
        public Guid NumeroTombo { get; private set; }

        public Patrimonio()
        {
            NumeroTombo = Guid.NewGuid();
        }
    }
}