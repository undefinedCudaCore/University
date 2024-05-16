using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface ILecture
    {
        internal Lecture Create(UniversityContext db);
        internal Lecture Update(UniversityContext db);
        internal Lecture Get(UniversityContext db, int lectId);
        internal List<Lecture> GetAll(UniversityContext db);
    }
}
