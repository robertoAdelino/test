using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class ListaProdutosSupViewModel
    {
        public IEnumerable<ProdutosSupermercado> ProdutosSupermercados { get; set; }
        public PagingViewModel Pagination { get; set; }

        public string CurrentNome { get; set; }
        public string CurrentSupermercado { get; set; }

    }
}
