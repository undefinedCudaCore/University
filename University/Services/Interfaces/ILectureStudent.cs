using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface ILectureStudent
    {
        internal LectureStudent Create(UniversityContext db);
        internal LectureStudent Update(UniversityContext db, int depId, int studId);
        internal LectureStudent GetByLectureId(UniversityContext db, int lectId);

        internal LectureStudent GetByStudentId(UniversityContext db, int studId);
        internal List<LectureStudent> GetAll(UniversityContext db);
    }
}
