using University.Database;
using University.Models;
using University.Services.Interfaces;

namespace University.Services
{
    internal class LectureService : ILecture
    {
        public Lecture Get(UniversityContext db, int lectId)
        {
            var lectures = db.Lectures
                .Where(b => b.LectureId == lectId)
                .ToList();

            return lectures[0];
        }
        public List<Lecture> GetAll(UniversityContext db)
        {
            var lectures = db.Lectures
                .ToList();

            return lectures;
        }
        public Lecture Create(UniversityContext db)
        {
            throw new NotImplementedException();
        }

        public Lecture Update(UniversityContext db)
        {
            throw new NotImplementedException();
        }
    }
}
