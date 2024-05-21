using University.Data;
using University.Database;
using University.Helpers;
using University.Models;
using University.Redirects;
using University.Services.Interfaces;

namespace University.Services
{
    internal class LectureService : ILecture
    {
        public Lecture Get(UniversityContext db, int lectId)
        {
            var lectures = db.Lectures
                .Where(b => b.LectureId == lectId)
                .FirstOrDefault();

            return lectures;
        }
        public List<Lecture> GetAll(UniversityContext db)
        {
            var lectures = db.Lectures
                .ToList();

            return lectures;
        }
        public Lecture Create(UniversityContext db)
        {
            IShowContent showContent = new ShowContentService();
            IDepartment departmentService = new DepartmentService();

            showContent.PrintContent(DataContent.ServiceContent.EnterLectId);
            CheckInputHelper.CheckInput(out int lectId);

            showContent.PrintContent(DataContent.ServiceContent.EnterLectName);
            string lectName = Console.ReadLine();

            CheckNameExists.IfLectNameExists(db, lectName);

            //Add check for lecture ID;
            if (CheckIfExists(db, lectId))
            {
                showContent.PrintContent(DataContent.ErrorData.LectureAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
                return new Lecture();
            }

            var lecture = new Lecture() { /*LectureId = lectId,*/ LectureName = lectName };
            db.Lectures.Add(lecture);
            db.SaveChanges();

            //Add lectures to department
            showContent.PrintContent(DataContent.ServiceContent.EnterDepId);
            CheckInputHelper.CheckInput(out int depId);
            departmentService.Update(db, depId);

            showContent.PrintContent(DataContent.ServiceContent.RecordCreated, lecture.LectureId);
            Thread.Sleep(3000);
            RedirectTo.MainMenu();

            return lecture;
        }

        public bool CheckIfExists(UniversityContext db, int lectId)
        {
            var lecrute = db.Lectures.Find(lectId);

            if (lecrute != null)
            {
                return true;
            }

            return false;
        }
    }
}
