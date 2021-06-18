using CarParkAvailability.Context;
using CarParkAvailability.Models;
using CarParkAvailability.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAvailability.DataMangers
{
    public class UserManager : IDataRepository<User>
    {
        readonly UserContext _userContext;

        public UserManager(UserContext context)
        {
            _userContext = context;
        }

        public void Add(User entity)
        {
            _userContext.Users.Add(entity);
            _userContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _userContext.Users.FirstOrDefault(user => user.UserId == id);
        }

        public User GetByEmail(string email)
        {
            return _userContext.Users.FirstOrDefault(user => user.Email == email);
        }
    }
}
