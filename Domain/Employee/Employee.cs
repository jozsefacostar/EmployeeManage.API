using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Employee
{
    public class Employee : AggregateRoot
    {
        public Employee()
        {
            Permissions = new HashSet<Permission.Permission>();
        }

        public Employee(EmployeeId id, string name, string lastName, string email, PhoneNumber phoneNumber, bool active)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Active = active;
        }
        public EmployeeId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{Name} {LastName} ";
        public string Email { get; set; } = string.Empty;
        public PhoneNumber PhoneNumber { get; private set; }
        public bool Active { get; set; }
        public virtual ICollection<Permission.Permission> Permissions { get; set; }

    }
}
