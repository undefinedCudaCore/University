using University.Database;
using University.Models;
using University.Services.Interfaces;

namespace University.Services
{
    internal class StudentService : IStudent
    {
        public Student Get(UniversityContext db, int studId)
        {
            var students = db.Students
                .Where(b => b.StudentId == studId)
                .ToList();

            return students[0];
        }
        public List<Student> GetAll(UniversityContext db)
        {
            var students = db.Students
                .ToList();

            return students;
        }
        public Student Create(UniversityContext db)
        {
            throw new NotImplementedException();
        }

        public Student Move(UniversityContext db, Student student, int depId)
        {
            throw new NotImplementedException();
        }

        public Student Update(UniversityContext db)
        {
            throw new NotImplementedException();
        }
    }
}
