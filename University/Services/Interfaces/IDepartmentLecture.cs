using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IDepartmentLecture
    {
        internal DepartmentLecture Create(UniversityContext db, int depId, int lektId);
        internal DepartmentLecture Update(UniversityContext db);
        internal List<DepartmentLecture> GetAll(UniversityContext db, int depId);
    }
}
