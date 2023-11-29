using Domain.Permission;

namespace Domain.PermissionType
{
    public interface IReadPermissionTypeRepository
    {
        Task<bool> ExistsAsync(PermissionTypeId id);
    }
}
