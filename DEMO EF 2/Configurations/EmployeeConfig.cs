using DEMO_EF_2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DEMO_EF_2.Configurations
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // there is three ways to define that is Employee has Primary key in its class!
            builder.HasKey(E => E.Id); // [Recommended]
            //builder.HasKey("Id");
            //builder.HasKey(nameof(Employee.Id));


            builder.Property(E => E.Id).UseIdentityColumn(10, 10);
            builder.Property(E => E.Name).HasColumnName("EmployeeName")
                                         .HasColumnType("varchar")
                                         .HasMaxLength(50)
                                         .IsRequired();


        }
    }
}
