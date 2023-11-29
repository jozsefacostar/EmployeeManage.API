using Domain.Permission;

namespace Domain.PermissionType
{
    public interface IWritePermissionTypeRepository
    {
        Task Add(PermissionType permissionType);
    }
}
