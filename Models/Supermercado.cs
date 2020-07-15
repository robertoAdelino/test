using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class Supermercado
    {
        [Key]
        public int IDSupermercado { get; set; }



        [Required(ErrorMessage = "Por favor introduza o nome")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o telefone")]
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Contacto inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor introduza o E-mail.")]
        [EmailAddress(ErrorMessage = "Email inválido")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor introduza a morada.")]
        public string Morada { get; set; }

        public ICollection<ProdutosSupermercado> ProdutosSupermercado { get; set; }

    }
}
