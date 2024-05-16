using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface ILectureStudent
    {
        internal LectureStudent Create(UniversityContext db);
        internal LectureStudent Update(UniversityContext db);
    }
}
