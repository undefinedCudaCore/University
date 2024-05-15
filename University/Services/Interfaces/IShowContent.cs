using University.Database;

namespace University.Services.Interfaces
{
    public interface IShowContent
    {
        public void ShowMainMenu();
        internal void ShowStudentsOfDepartment(UniversityContext db, int depId, out bool cycle);
        internal void ShowLecturesOfDepartment(UniversityContext db, int depId, out bool cycle);
        internal void ShowStudentLectures(UniversityContext db, int studId, out bool cycle);
        public void PrintContent(string content);
    }
}
