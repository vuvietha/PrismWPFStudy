using PrismWPF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWPF.Data.Services
{
    public interface IUserService
    {
        List<User> GetAllUser();
        List<User> SaveUsers(List<User> users);
        List<User> DeleteUser(User user);
        List<User> DeleteUsers(List<User> users);
        List<User> UpdateUsers(List<User> users);
    }
}
