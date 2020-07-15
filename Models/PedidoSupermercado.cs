using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class PedidoSupermercado
    {
        [Key]
        public int IDPedidoSupermercado { get; set; }

        [Required(ErrorMessage = "Por favor introduza a Quantidade.")]
        [GreaterThanZero(ErrorMessage = "Insira quantidade positiva")]
        public int Quantidade { get; set; }
        [Required]
        public bool? EstadoEntrega { get; set; }

        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataPedido { get; }

 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataEntrega { get; set; }
        

        public int IDFamilias { get; set; }
        public Familias Familias { get; set; }

        public int IDInstituicoes { get; set; }
        public Instituicoes Instituicoes { get; set; }

        public int IDProdutosSupermercado { get; set; }
        public ProdutosSupermercado ProdutosSupermercado { get; set; }

        public int IDVoluntarios { get; set; }
        public Voluntarios Voluntarios { get; set; }
    }
}
