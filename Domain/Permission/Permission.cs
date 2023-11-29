using Domain.Primitives;
using Domain.ValueObjects;
using Domain.Employee;
using Domain.PermissionType;
using Domain.Permission;
using System.Net;

namespace Domain.Permission
{
    public class Permission : AggregateRoot
    {
        public Permission()
        {
        }

        public Permission(PermissionId id, EmployeeId employee, PermissionTypeId permissionType, string reasonPermission, bool active)
        {
            Id = id;
            Employee = employee;
            PermissionType = permissionType;
            ReasonPermission = reasonPermission;
            Active = active;
        }
        public PermissionId Id { get; set; }
        public EmployeeId Employee { get; set; }
        public PermissionTypeId PermissionType { get; set; }
        public string ReasonPermission { get; set; } = string.Empty;
        public DateTime PermissionDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = false;

        public Employee.Employee EmployeeNavigation { get; set; }
        public PermissionType.PermissionType PermissionTypeNavigation { get; set; }
        public static Permission UpdateCustomer(Guid id, EmployeeId employee, PermissionTypeId permissionType, string reasonsPermission, bool active)
        {
            return new Permission(new PermissionId(id), employee, permissionType, reasonsPermission, active);
        }
    }
}
