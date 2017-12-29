using System;
using System.Collections.Generic;
using System.Text;
using Hurriyet.HurriyetDb.DataAccess.Abstract;
using HurriyetDemo.Core.DataAccess.EntityFramework;
using HurriyetDemo.HurriyetDb.Entities.Concrete;

namespace Hurriyet.HurriyetDb.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HurriyetContext>, IUserDal
    {

    }
}
