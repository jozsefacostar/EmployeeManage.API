using Domain.Employee;
using Domain.PermissionType;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class PermissionTypeRepository : IWritePermissionTypeRepository, IReadPermissionTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public PermissionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(PermissionType PermissionType) => await _context.PermissionTypes.AddAsync(PermissionType);
        public async Task<bool> ExistsAsync(PermissionTypeId id) => await _context.PermissionTypes.AnyAsync(x => x.Id == id && x.Active);
    }
}
