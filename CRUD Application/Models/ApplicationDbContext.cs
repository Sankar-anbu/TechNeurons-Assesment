using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Emplyees { get; set; }
    }
}
