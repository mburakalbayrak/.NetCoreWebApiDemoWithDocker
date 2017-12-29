using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using HurriyetDemo.HurriyetDb.Entities.Concrete;

namespace Hurriyet.HurriyetDb.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);

        Product GetById(Expression<Func<Product, bool>> filter);

        void Add(Product product);

        void Update(Product product);

        void Delete(int productId);
    }
}
