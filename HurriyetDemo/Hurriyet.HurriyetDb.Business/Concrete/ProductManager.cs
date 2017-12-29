using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Hurriyet.HurriyetDb.Business.Abstract;
using Hurriyet.HurriyetDb.DataAccess.Abstract;
using HurriyetDemo.HurriyetDb.Entities.Concrete;

namespace Hurriyet.HurriyetDb.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            // SOLID D harfi açısından sıkıntılı bir kullanımdır. 
            //Business'ı EntityFramework'e bağımlı hale getirmiş olurum. Minumum bağımlılık olmalı. Bunun için DependencyInjection kullanılır.
            //EfProductDal product = new EfProductDal();
            //return product.GetList();
            if (filter == null)
            {
                return _productDal.GetList();
            }
            return _productDal.GetList(filter);
        }

        public Product GetById(Expression<Func<Product, bool>> filter)
        {
            if (filter == null)
            {
                return null;
            }
            return _productDal.Get(filter);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { Id = productId });
        }
    }
}
