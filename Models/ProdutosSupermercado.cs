using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ZeroWaste.Models
{
    public class ProdutosSupermercado
    {
        [Key]
        public int IDProdutosSupermercado { get; set; }



        [Required(ErrorMessage = "Por favor introduza o nome")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza a Quantidade.")]
        [GreaterThanZero(ErrorMessage = "Insira quantidade positiva")]
        public int Quantidade { get; set; }

        public int IDSupermercado { get; set; }
        public Supermercado Supermercado { get; set; }

        public int IDTipo { get; set; }
        public Tipo Tipo { get; set; }

        public ICollection<PedidoSupermercado> PedidoSupermercado { get; set; }

    }
}
