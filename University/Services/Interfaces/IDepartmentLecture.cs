using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IDepartmentLecture
    {
        internal DepartmentLecture Create(UniversityContext db);
        internal DepartmentLecture Update(UniversityContext db);
    }
}
