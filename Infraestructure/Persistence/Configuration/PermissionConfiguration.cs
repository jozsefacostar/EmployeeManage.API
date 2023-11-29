using Domain.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infraestructure.Persistence.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Domain.Permission.Permission>
    {
        public void Configure(EntityTypeBuilder<Domain.Permission.Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(c => new { c.Id });
            builder.Property(c => c.Id).HasConversion(permissionTypeId => permissionTypeId.value, value => new PermissionId(value));
            builder.Property(c => c.ReasonPermission).HasMaxLength(250);
            builder.Property(c => c.Active).IsRequired(true);

            builder.HasOne(x => x.EmployeeNavigation)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.Employee)
                .HasConstraintName("FK_Employee_Permissions")
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.PermissionTypeNavigation)
               .WithMany(x => x.Permissions)
               .HasForeignKey(x => x.PermissionType)
               .HasConstraintName("FK_PermissionType_Permissions")
               .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
