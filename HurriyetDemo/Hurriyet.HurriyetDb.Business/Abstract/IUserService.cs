using System;
using System.Collections.Generic;
using System.Text;
using HurriyetDemo.HurriyetDb.Entities.Concrete;

namespace Hurriyet.HurriyetDb.Business.Abstract
{
    public interface IUSerService
    {
        User GetUser(string email, string password);

        List<User> GetAll();
    }
}
