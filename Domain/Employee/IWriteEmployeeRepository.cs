namespace Domain.Employee
{
    public interface IWriteEmployeeRepository
    {
        Task Add(Employee employee);
    }
}
