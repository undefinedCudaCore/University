using University.Data;
using University.Database;
using University.Redirects;
using University.Services;
using University.Services.Interfaces;

namespace University.Helpers
{
    internal static class CheckNameExistsHelper
    {

        public static void IfStudentNameExists(UniversityContext db, string studName)
        {
            IShowContent showContent = new ShowContentService();
            var students = db.Students
                .Where(s => s.StudentName.ToLower() == studName.ToLower())
            .FirstOrDefault();

            if (students != null)
            {
                showContent.PrintContent(DataContent.ErrorData.StudentAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }

        public static void IfDepartmentNameExists(UniversityContext db, string depName)
        {
            IShowContent showContent = new ShowContentService();
            var students = db.Departments
                .Where(s => s.DepartmentName.ToLower() == depName.ToLower())
            .FirstOrDefault();

            if (students != null)
            {
                showContent.PrintContent(DataContent.ErrorData.DepartmentAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }

        public static void IfLectNameExists(UniversityContext db, string lectName)
        {
            IShowContent showContent = new ShowContentService();
            var students = db.Lectures
                .Where(s => s.LectureName.ToLower() == lectName.ToLower())
            .FirstOrDefault();

            if (students != null)
            {
                showContent.PrintContent(DataContent.ErrorData.LectureAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }
    }
}
