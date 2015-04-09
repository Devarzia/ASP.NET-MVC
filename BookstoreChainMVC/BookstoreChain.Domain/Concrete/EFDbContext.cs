using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreChain.Domain.Entities;
using System.Data.Entity;

namespace BookstoreChain.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        // Grabbing each Table from the Database
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Store> Stores { get; set; }

        // 
        public EFDbContext() : base()
        {
            Database.SetInitializer<EFDbContext>(null);
        }
    }
}
