using System;
using System.Collections.Generic;
using System.Linq;
using stockValues_backend.Models;

namespace stockValues_backend.Data
{
    public class SQLiteRepo : IDbRepo
    {
        private readonly UserContext _context;

        public SQLiteRepo(UserContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }
    }
}