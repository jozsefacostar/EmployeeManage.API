using Domain.PermissionType;

namespace Domain.Employee
{
    public interface IReadEmployeeRepository
    {
        Task<bool> ExistsAsync(EmployeeId id);
    }
}
