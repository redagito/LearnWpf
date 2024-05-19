using LearnWpf.CustomerDemo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnWpf.CustomerDemo.DataAccess.DataContexts
{
    class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData([
                new Customer { Id = 1, Address = "Hugogasse 8, 1080 Wien", FirstName = "Max", LastName = "Obiger", PhoneNumber = "+43 660 123 456 78"},
                new Customer { Id = 2, Address = "Markostrasse 9, 1090 Wien", FirstName = "Josef", LastName = "Macker", PhoneNumber = "+43 664 423 556 76"},
                new Customer { Id = 3, Address = "Ackerstrasse 12, 1110 Wien", FirstName = "Linda", LastName = "Tunsinger", PhoneNumber = "+43 676 523 456 78"},
                new Customer { Id = 4, Address = "Maxweg 7, 1210 Wien", FirstName = "Olaf", LastName = "Ongrad", PhoneNumber = "+43 660 123 256 58"},
                new Customer { Id = 5, Address = "Paulaplatz 88, 1150 Wien", FirstName = "Mira", LastName = "Malker", PhoneNumber = "+43 664 223 556 68"},
            ]);

            base.OnModelCreating(modelBuilder);
        }
    }
}
