using System;

namespace ZeroWaste.Models
{
    public class PagingViewModel
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int NumberPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public string Nome { get; set; }
        public string Supermercado { get; set; }
    }
}