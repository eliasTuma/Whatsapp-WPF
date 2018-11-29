using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDatabase
{
    public class CSharpDB : DbContext
    {
        /// <summary>
        /// Context Variables
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<LoggedIn> LoggedInUsers { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CSharpDB()
        {

        }
    }
}
