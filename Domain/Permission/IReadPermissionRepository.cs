using static Domain.PermissionErrors.Errors;

namespace Domain.Permission
{
    public interface IReadPermissionRepository
    {
        Task<List<Domain.Permission.Permission>> GetAll();
        Task<bool> ExistsAsync(PermissionId id);
    }
}
