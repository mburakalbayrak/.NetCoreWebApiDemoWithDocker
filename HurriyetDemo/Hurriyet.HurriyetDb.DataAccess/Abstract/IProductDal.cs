﻿using HurriyetDemo.Core.DataAccess;
using HurriyetDemo.HurriyetDb.Entities.Concrete;

namespace Hurriyet.HurriyetDb.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        // Burada product ile ilgili özel operasyonlar yapabileceğimiz için (view'lı sorgular, joinli sorgular) ve burada product'ı ilgilendiren sorgular olacağı için IEntityRepository<T> generic vermedim.
    }
}
