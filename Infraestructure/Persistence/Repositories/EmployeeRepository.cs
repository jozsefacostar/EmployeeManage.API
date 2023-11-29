using Domain.Employee;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class EmployeeRepository : IWriteEmployeeRepository, IReadEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Employee emplooye) => await _context.Employees.AddAsync(emplooye);
        public async Task<bool> ExistsAsync(EmployeeId id) => await _context.Employees.AnyAsync(x => x.Id == id && x.Active);
    }
}
