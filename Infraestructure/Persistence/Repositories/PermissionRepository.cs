using Domain.Permission;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class PermissionRepository : IWritePermissionRepository, IReadPermissionRepository
    {
        private readonly ApplicationDbContext _context;
        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Domain.Permission.Permission>> GetAll() => await _context.Permissions.OrderByDescending(x=>x.PermissionDate).ToListAsync();
        public async Task<bool> ExistsAsync(Domain.Permission.PermissionId id) => await _context.Permissions.AnyAsync(x => x.Id == id);
        public async Task Add(Domain.Permission.Permission permission) => await _context.Permissions.AddAsync(permission);
        public void Update(Domain.Permission.Permission permission) => _context.Permissions.Update(permission);
    }
}
