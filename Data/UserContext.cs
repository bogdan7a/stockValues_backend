using Microsoft.EntityFrameworkCore;
using stockValues_backend.Models;

namespace stockValues_backend.Data
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}