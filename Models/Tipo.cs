using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class Tipo
    {
        [Key]
        public int IDTipo { get; set; }

        [Required(ErrorMessage = "Por favor insira o nome")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Nome invalido!!")]
        public string Nome { get; set; }

        public ICollection<ProdutosSupermercado> ProdutosSupermercado { get; set; }

    }
}
