using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class RefeicoesRestaurante
    {
        [Key]
        public int IDRefeicoesRestaurante { get; set; }


        [Required(ErrorMessage = "Por favor introduza o nome")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza a Quantidade.")]
        [GreaterThanZero(ErrorMessage = "Insira quantidade positiva")]
        public int Quantidade { get; set; }



        public int IDRestaurante { get; set; }
        public Restaurante Restaurante { get; set; }


        public ICollection<PedidoRestaurante> PedidoRestaurante { get; set; }


    }
}
