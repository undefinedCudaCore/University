using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Database
{
    internal class UniversityContext : DbContext
    {
        public UniversityContext()
        {
            ConnectionString = "Data Source=LENOVOY520\\SQLEXPRESS;Initial Catalog=UniversityDB;" +
                "Integrated Security=True;Encrypt=False";
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public string ConnectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
