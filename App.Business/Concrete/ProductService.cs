﻿using App.Business.Abstract;
using App.Business.Enum;
using App.DataAccess.Abstract;
using App.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            var item = _productDal.Get(p => p.ProductId == id);
            _productDal.Delete(item);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _productDal.GetList(p=>p.CategoryId==categoryId || categoryId==0);    
        }

       

        public List<Product> GetAllByFilterAZ(List<Product> list, CheckFilter az = CheckFilter.One)
        {
            if (az==CheckFilter.One||az==CheckFilter.Zero)
                return list.OrderBy(x => x.ProductName).ToList();
            return list.OrderByDescending(x => x.ProductName).ToList();
        }

        public List<Product> GetAllByFilterPrice(List<Product> list, CheckFilter price = CheckFilter.One)
        {
            if (price == CheckFilter.One || price == CheckFilter.Zero)
                return list.OrderBy(x => x.UnitPrice).ToList();
            return list.OrderByDescending(x => x.UnitPrice).ToList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
