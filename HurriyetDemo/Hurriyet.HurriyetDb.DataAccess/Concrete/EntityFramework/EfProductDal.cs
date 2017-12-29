using Hurriyet.HurriyetDb.DataAccess.Abstract;
using HurriyetDemo.Core.DataAccess.EntityFramework;
using HurriyetDemo.HurriyetDb.Entities.Concrete;

namespace Hurriyet.HurriyetDb.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, HurriyetContext>, IProductDal
    {

    }
}
