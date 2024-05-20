using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IStudent
    {
        internal Student Create(UniversityContext db);
        internal void Update(UniversityContext db, int depId, int studId);
        internal Student Move(UniversityContext db);
        internal Student Get(UniversityContext db, int studId);
        internal List<Student> GetAll(UniversityContext db);
        internal bool CheckIfExists(UniversityContext db, int studId);
    }
}
