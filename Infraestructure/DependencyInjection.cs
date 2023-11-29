using Application.Data;
using Domain.Employee;
using Domain.Permission;
using Domain.PermissionType;
using Domain.Primitives;
using Infraestructure.Persistence;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));
            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            //Employee
            services.AddScoped<IWriteEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IReadEmployeeRepository, EmployeeRepository>();
            //PermissionType
            services.AddScoped<IWritePermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IReadPermissionTypeRepository, PermissionTypeRepository>();
            //Permissions
            services.AddScoped<IWritePermissionRepository, PermissionRepository>();
            services.AddScoped<IReadPermissionRepository, PermissionRepository>();
            return services;
        }
    }
}
