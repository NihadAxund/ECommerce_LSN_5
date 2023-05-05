using App.Business.Enum;
using App.Entities.Models;

namespace App.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategory(int categoryId);
        List<Product> GetAllByFilterAZ(List<Product> list, CheckFilter az = CheckFilter.One);
        List<Product> GetAllByFilterPrice(List<Product> list, CheckFilter price = CheckFilter.One);
        void Add(Product product);  
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);

    }
}
