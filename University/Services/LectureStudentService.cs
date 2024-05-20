using University.Data;
using University.Database;
using University.Helpers;
using University.Models;
using University.Redirects;
using University.Services.Interfaces;

namespace University.Services
{
    internal class LectureStudentService : ILectureStudent
    {

        public LectureStudent GetByLectureId(UniversityContext db, int lectId)
        {
            var lectureStudent = db.LectureStudents
                .Where(b => b.LectureId == lectId)
                .FirstOrDefault();

            return lectureStudent;
        }

        public LectureStudent GetByStudentId(UniversityContext db, int studId)
        {
            var lectureStudent = db.LectureStudents
                .Where(b => b.StudentId == studId)
                .FirstOrDefault();

            return lectureStudent;
        }
        public List<LectureStudent> GetAll(UniversityContext db)
        {
            var lectureStudents = db.LectureStudents
                .ToList();

            return lectureStudents;
        }

        public LectureStudent Create(UniversityContext db)
        {
            Console.Clear();

            IShowContent showContent = new ShowContentService();

            showContent.PrintContent(DataContent.ServiceContent.EnterLectId);
            CheckInputHelper.CheckInput(out int lectId);

            showContent.PrintContent(DataContent.ServiceContent.EnterStudentId);
            CheckInputHelper.CheckInput(out int studId);

            var lectureStudent = new LectureStudent() { LectureId = lectId, StudentId = studId };

            CheckObjectExists.CheckIfStudentAndLectureExists(db, lectId, studId);

            db.LectureStudents.Add(lectureStudent);
            db.SaveChanges();

            showContent.PrintContent(DataContent.ServiceContent.RecordCreated + "(lecture ID) ", lectureStudent.LectureId);
            showContent.PrintContent(DataContent.ServiceContent.RecordCreated + "(student ID) ", lectureStudent.StudentId);
            Thread.Sleep(3000);
            RedirectTo.MainMenu();

            return lectureStudent;
        }

        public LectureStudent Update(UniversityContext db, int depId, int studId)
        {
            IShowContent showContent = new ShowContentService();
            IDepartmentLecture departmentLectureService = new DepartmentLectureService();
            var departmentLectures = departmentLectureService.GetAll(db, depId);
            var lectureStudent = new LectureStudent();

            foreach (var dl in departmentLectures)
            {
                if (dl.DepartmentId == depId)
                {
                    CheckObjectExists.CheckIfStudentAndLectureExists(db, dl.LectureId, studId);

                    lectureStudent.LectureId = dl.LectureId;
                    lectureStudent.StudentId = studId;
                    db.LectureStudents.Add(lectureStudent);
                    db.SaveChanges();
                }
            }


            showContent.PrintContent(DataContent.ServiceContent.RecordCreated + "(lecture ID) ", lectureStudent.LectureId);
            showContent.PrintContent(DataContent.ServiceContent.RecordCreated + "(student ID) ", lectureStudent.StudentId);
            Thread.Sleep(3000);
            RedirectTo.MainMenu();

            return lectureStudent;
        }
    }
}
