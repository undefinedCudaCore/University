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
        public LectureStudent Create(UniversityContext db)
        {
            Console.Clear();

            IShowContent showContent = new ShowContentService();
            ILecture lectureService = new LectureService();
            IStudent studentService = new StudentService();

            showContent.PrintContent(DataContent.ServiceContent.EnterLectId);
            CheckInputHelper.CheckInput(out int lectId);

            showContent.PrintContent(DataContent.ServiceContent.EnterStudentId);
            CheckInputHelper.CheckInput(out int studId);

            var lectureStudent = new LectureStudent() { LectureId = lectId, StudentId = studId };

            //if (!studentService.CheckIfExists(db, studId) && !lectureService.CheckIfExists(db, lectId))
            //{
            //    showContent.PrintContent(DataContent.ErrorData.LectureNotExists);
            //    showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
            //    showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
            //    Thread.Sleep(3000);
            //    RedirectTo.MainMenu();
            //}

            //if (!lectureService.CheckIfExists(db, lectId))
            //{
            //    showContent.PrintContent(DataContent.ErrorData.LectureNotExists);
            //    showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
            //    Thread.Sleep(3000);
            //    RedirectTo.MainMenu();
            //}

            //if (!studentService.CheckIfExists(db, studId))
            //{
            //    showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
            //    showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
            //    Thread.Sleep(3000);
            //    RedirectTo.MainMenu();
            //}

            CheckLectureAndStudentExists.CheckIfExists(db, lectId, studId);

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
                    CheckLectureAndStudentExists.CheckIfExists(db, dl.LectureId, studId);

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
