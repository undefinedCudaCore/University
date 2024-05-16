using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IStudent
    {
        internal Student Create(UniversityContext db);
        internal Student Update(UniversityContext db);
        internal Student Move(UniversityContext db, Student student, int depId);
        internal Student Get(UniversityContext db, int studId);
        internal List<Student> GetAll(UniversityContext db);
    }
}
