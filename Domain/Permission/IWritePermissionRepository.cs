using static Domain.PermissionErrors.Errors;

namespace Domain.Permission
{
    public interface IWritePermissionRepository
    {
        Task Add(Domain.Permission.Permission Permission);
        void Update(Domain.Permission.Permission customer);
    }
}
