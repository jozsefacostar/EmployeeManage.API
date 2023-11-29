using Domain.Employee;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infraestructure.Persistence.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(c => new { c.Id });
            builder.Property(c => c.Id).HasConversion(customerId => customerId.value, value => new EmployeeId(value));
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.LastName).HasMaxLength(50);
            builder.Ignore(c => c.FullName);
            builder.Property(c => c.Email).HasMaxLength(255);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.PhoneNumber).HasConversion(phoneNumber => phoneNumber.Value, Value => PhoneNumber.Create(Value)!).HasMaxLength(9);
            builder.Property(c => c.Active).IsRequired(true);
        }
    }
}
