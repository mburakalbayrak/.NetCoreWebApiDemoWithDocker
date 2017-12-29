using System;
using System.Collections.Generic;
using System.Text;
using Hurriyet.HurriyetDb.Business.Abstract;
using Hurriyet.HurriyetDb.DataAccess.Abstract;
using HurriyetDemo.HurriyetDb.Entities.Concrete;

namespace Hurriyet.HurriyetDb.Business.Concrete
{
    public class UserManager : IUSerService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(string email, string password)
        {
            return _userDal.Get(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }
    }
}
