using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public User GetUser(string userName, string password)
        {
            return _userDal.Get(x => x.UserName.Equals(userName) && x.Password.Equals(password));
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            if (filter == null)
            {
                return _userDal.GetList();
            }
            return _userDal.GetList(filter);
        }

        public void Add(User product)
        {
            _userDal.Add(product);
        }

        public void Update(User product)
        {
            _userDal.Update(product);
        }
        
    }
}
