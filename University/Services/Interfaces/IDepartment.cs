using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IDepartment
    {
        internal Department Create(UniversityContext db);
        internal Department Update(UniversityContext db);
        internal Department Get(UniversityContext db, int depId);
        internal List<Department> GetAll(UniversityContext db);
    }
}
