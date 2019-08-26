using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWPF.Data.Data;
using PrismWPF.Data.Models;

namespace PrismWPF.Data.Services
{
    public class UserService : IUserService
    {
        public List<User> DeleteUser(User user)
        {
            DBContext.Users.Remove(user);
            return DBContext.Users;
        }

        public List<User> GetAllUser()
        {
            return DBContext.Users;
        }

        public List<User> SaveUsers(List<User> users)
        {
            DBContext.Users.AddRange(users);
            return DBContext.Users;
        }
        public List<User> DeleteUsers(List<User> users)
        {
            
            foreach (var item in users)
            {
                DBContext.Users.Remove(item);
            }
            return DBContext.Users;
        }
        public List<User> UpdateUsers(List<User> users)
        {
            foreach (var item in users)
            {
                var user = DBContext.Users.FirstOrDefault(x => x.UserId == item.UserId);
                user = item;

            }
            return DBContext.Users;
        }

    }
}
