using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UnityAPIarcanoid.Model;

namespace UnityAPIarcanoid.DB
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base (options) { 
        }

        public DbSet<User> User { get; set; }
        public DbSet<BallSkin> BallSkin { get; set; }
        public DbSet<BuySkins> BuySkins { get; set; }
        public DbSet<CurrentSkin> CurrentSkin { get; set; }
    }
    
}
