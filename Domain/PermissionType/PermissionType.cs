using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.PermissionType
{
    public class PermissionType : AggregateRoot
    {
        public PermissionType()
        {
            Permissions = new HashSet<Permission.Permission>();
        }

        public PermissionType(PermissionTypeId id, string name, string code, bool active)
        {
            Id = id;
            Name = name;
            Code = code;
            Active = active;
        }
        public PermissionTypeId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool Active { get; set; } = true;

        public virtual ICollection<Permission.Permission> Permissions { get; set; }
    }
}
