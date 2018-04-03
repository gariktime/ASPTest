using ASPTest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.EF
{
    public class DepartmentContext : DbContext
    {
        static DepartmentContext()
        {
            Database.SetInitializer<DepartmentContext>(new MyDepartmentContextInitializer());
        }

        public DepartmentContext(string connectionString)
            : base(connectionString)
        {

        }

        /// <summary>
        /// Конфигурация базы данных с использованием Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Ignore(p => p.Users);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
    }

    class MyDepartmentContextInitializer : DropCreateDatabaseIfModelChanges<DepartmentContext>
    {
        protected override void Seed(DepartmentContext db)
        {
            db.Departments.Add(new Department() { Id = 1, Title = "IT Department" });
            db.Departments.Add(new Department() { Id = 2, Title = "Marketing" });

            db.SaveChanges();
        }
    }
}
