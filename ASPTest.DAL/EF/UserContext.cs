using ASPTest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.EF
{
    public class UserContext : DbContext
    {
        static UserContext()
        {
            Database.SetInitializer<UserContext>(new MyUserContextInitializer());
        }

        public UserContext(string connectionString)
            : base(connectionString)
        {

        }

        /// <summary>
        /// Конфигурация базы данных с использованием Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(p => p.Department);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }

    class MyUserContextInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Users.Add(new User() { Id = 1, UserName = "John", DepartmentId = 1 });
            db.Users.Add(new User() { Id = 2, UserName = "Peter", DepartmentId = 2 });
            db.Users.Add(new User() { Id = 3, UserName = "Sam", DepartmentId = 1 });

            db.SaveChanges();
        }
    }
}
