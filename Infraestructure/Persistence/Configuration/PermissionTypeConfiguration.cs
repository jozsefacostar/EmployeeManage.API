using Domain.Employee;
using Domain.PermissionType;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infraestructure.Persistence.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionTypes");
            builder.HasKey(c => new { c.Id });
            builder.Property(c => c.Id).HasConversion(permissionTypeId => permissionTypeId.value, value => new PermissionTypeId(value));
            builder.Property(c => c.Code).HasMaxLength(50);
            builder.Property(c => c.Active).IsRequired(true);
        }
    }
}
