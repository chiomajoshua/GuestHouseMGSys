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
    public class RoleDAO
    {
        private readonly BaseDAO<Role> _rolepost;

        public RoleDAO(BaseDAO<Role> rolepost)
        {
            _rolepost = rolepost;
        }

        public Role AddRole(Role rolepost)
        {
            try
            {
                _rolepost.CreateEntity(rolepost);
                return rolepost;
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public Role UpdateRole(Role rolepost)
        {
            try
            {
                _rolepost.UpdateEntity(rolepost);
                return rolepost;
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public Role GetRole(long rolepostid, params Expression<Func<Role, object>>[] includePredicates)
        {
            try
            {
                return _rolepost.GetEntity(a => a.RoleId.Equals(rolepostid)).FirstOrDefault();
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }

        public IEnumerable<Role> GetAllRole(params Expression<Func<Role, object>>[] includePredicates)
        {
            try
            {
                return _rolepost.GetEntities(includePredicates);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void DeleteRole(long rolepostid)
        {
            try
            {
                _rolepost.DeleteEntity(rolepostid);
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }
        }
    }
}
