using App.Business.Enum;
using App.Entities.Models;

namespace ECommerce.WebUI
{
  
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public CheckFilter AZSort { get; set; } = CheckFilter.Zero;
        public CheckFilter PriceSort { get; set; } = CheckFilter.Zero;
        public int CurrentCategory { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        
    }
}