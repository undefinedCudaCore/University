using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IDepartment
    {
        internal Department Create(UniversityContext db);
        internal void Update(UniversityContext db);
        internal void Update(UniversityContext db, int depId);
        internal Department Get(UniversityContext db, int depId);
        internal List<Department> GetAll(UniversityContext db);
    }
}
