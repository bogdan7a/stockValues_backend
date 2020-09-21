using System.Collections.Generic;
using stockValues_backend.Models;

namespace stockValues_backend.Data
{
    public interface IDbRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void DeleteUser(User user);
    }
}