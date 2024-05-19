using University.Database;
using University.Models;
using University.Services.Interfaces;

namespace University.Services
{
    internal class DepartmentLectureService : IDepartmentLecture
    {

        public List<DepartmentLecture> GetAll(UniversityContext db, int depId)
        {
            var departmentLectures = db.DepartmentLectures
                .Where(dl => dl.DepartmentId == depId)
                .ToList();

            return departmentLectures;
        }

        public DepartmentLecture Create(UniversityContext db, int depId, int lektId)
        {
            var departmentLecture = new DepartmentLecture() { DepartmentId = depId, LectureId = lektId };

            db.DepartmentLectures.Add(departmentLecture);
            db.SaveChanges();

            return departmentLecture;
        }

        public DepartmentLecture Update(UniversityContext db)
        {
            throw new NotImplementedException();
        }
    }
}
