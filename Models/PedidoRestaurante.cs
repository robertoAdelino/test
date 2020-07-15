using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroWaste.Models
{
    public class PedidoRestaurante
    {
        public int IDPedidoRestaurante { get; set; }

        [Required(ErrorMessage = "Por favor introduza a Quantidade.")]
        [GreaterThanZero(ErrorMessage = "Insira uma quantidade positiva")]
        public int Quantidade { get; set; }

        [Required]
        public bool? EstadoEntrega { get; set; }

        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataPedido { get;  }// ter em atenção aqui

 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataEntrega { get; set; }
        


        public int IDFamilias { get; set; }
        public Familias Familias { get; set; }

        public int IDInstituicoes { get; set; }
        public Instituicoes Instituicoes { get; set; }

        public int IDRefeicoesRestaurante { get; set; }
        public RefeicoesRestaurante RefeicoesRestaurante { get; set; }
 
        public int IDVoluntarios { get; set; }
        public Voluntarios Voluntarios { get; set; }


    }
}
