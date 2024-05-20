using University.Data;
using University.Database;
using University.Redirects;
using University.Services;
using University.Services.Interfaces;

namespace University.Helpers
{
    internal static class CheckObjectExists
    {
        public static void CheckIfStudentAndLectureExists(UniversityContext db, int lectId, int studId)
        {
            IShowContent showContent = new ShowContentService();
            ILecture lectureService = new LectureService();
            IStudent studentService = new StudentService();

            if (!studentService.CheckIfExists(db, studId) && !lectureService.CheckIfExists(db, lectId))
            {
                showContent.PrintContent(DataContent.ErrorData.LectureNotExists);
                showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            if (!lectureService.CheckIfExists(db, lectId))
            {
                showContent.PrintContent(DataContent.ErrorData.LectureNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            if (!studentService.CheckIfExists(db, studId))
            {
                showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }

        public static void CheckIfStudentExists(UniversityContext db, int studId)
        {
            IShowContent showContent = new ShowContentService();
            IStudent studentService = new StudentService();

            if (!studentService.CheckIfExists(db, studId))
            {
                showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }

        public static void CheckIfDepartmentExists(UniversityContext db, int depId)
        {
            IShowContent showContent = new ShowContentService();
            IDepartment departmentService = new DepartmentService();

            if (!departmentService.CheckIfExists(db, depId))
            {
                showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }
    }
}
