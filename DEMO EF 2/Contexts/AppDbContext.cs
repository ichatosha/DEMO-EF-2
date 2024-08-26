using DEMO_EF_2.Configurations;
using DEMO_EF_2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DEMO_EF_2.Contexts
{
    internal class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = HESHAM\\HESHAMDB; database = Demo; Trusted_Connection = True; TrustServerCertificate= True");
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> departments { get; set; }

        
        // [FluentApi]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// there is three ways to define that is Employee has Primary key in its class!
            //modelBuilder.Entity<Employee>().HasKey(E => E.Id); // [Recommended]
            ////modelBuilder.Entity<Employee>().HasKey("Id");
            ////modelBuilder.Entity<Employee>().HasKey(nameof(Employee.Id));


            //modelBuilder.Entity<Employee>().Property(E => E.Id).UseIdentityColumn(10,10);
            //modelBuilder.Entity<Employee>().Property(E => E.Name)
            //                               .HasColumnName("EmployeeName")
            //                               .HasColumnType("varchar")
            //                               .HasMaxLength(50)
            //                               .IsRequired();

            // to run the configs : 
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            // to run all :
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
      



    }
}
