using System.Data.Entity;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
    public class MainContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLease> BookLeases { get; set; }

        static MainContext()
        {
            Database.SetInitializer<MainContext>(new workDbInitializer());
        }
        public MainContext() : base("DefaultConnection")
        {
        }
        public MainContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class workDbInitializer : DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext db)
        {
        }
    }
}