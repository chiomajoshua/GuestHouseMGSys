using DataAccessObjects.EntityFramework;
using DataAccessObjects.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Implementation
{
    public class UserDAO
    {
        private readonly BaseDAO<User> _userpost;

        public UserDAO(BaseDAO<User> userpost)
        {
            _userpost = userpost;
        }

        public User AddUser(User userpost)
        {
            try
            {
                _userpost.CreateEntity(userpost);
                return userpost;
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public User UpdateUser(User userpost)
        {
            try
            {
                _userpost.UpdateEntity(userpost);
                return userpost;
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public User GetUser(long userpostid, params Expression<Func<User, object>>[] includePredicates)
        {
            try
            {
                return _userpost.GetEntity(a => a.UserId.Equals(userpostid)).FirstOrDefault();
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public IEnumerable<User> GetAllUser(params Expression<Func<User, object>>[] includePredicates)
        {
            try
            {
                return _userpost.GetEntities(includePredicates);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void DeleteUser(long userpostid)
        {
            try
            {
                _userpost.DeleteEntity(userpostid);
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }
    }
}
