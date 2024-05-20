using University.Data;
using University.Database;
using University.Helpers;
using University.Models;
using University.Redirects;
using University.Services.Interfaces;

namespace University.Services
{
    public class DepartmentService : IDepartment

    {
        public Department Get(UniversityContext db, int depId)
        {
            var departments = db.Departments
                .Where(b => b.DepartmentId == depId)
                .FirstOrDefault();

            return departments;
        }

        public List<Department> GetAll(UniversityContext db)
        {
            var departments = db.Departments
                .ToList();

            return departments;
        }

        public Department Create(UniversityContext db)
        {
            IShowContent showContent = new ShowContentService();

            showContent.PrintContent(DataContent.ServiceContent.EnterDepId);
            CheckInputHelper.CheckInput(out int depId);

            showContent.PrintContent(DataContent.ServiceContent.EnterDepName);
            CheckInputHelper.CheckInput(out string depName);

            //Add check for department ID;
            if (CheckIfExists(db, depId))
            {
                showContent.PrintContent(DataContent.ErrorData.DepartmentAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
                return new Department();
            }

            var department = new Department() { /*DepartmentId = depId, */DepartmentName = depName };
            db.Departments.Add(department);
            db.SaveChanges();

            //Add lectures to department
            Update(db, depId);

            showContent.PrintContent(DataContent.ServiceContent.RecordCreated, department.DepartmentId);
            Thread.Sleep(3000);
            RedirectTo.MainMenu();

            return department;
        }

        public bool CheckIfExists(UniversityContext db, int depId)
        {
            var department = db.Departments.Find(depId);

            if (department != null)
            {
                return true;
            }

            return false;
        }

        public void Update(UniversityContext db)
        {
            IShowContent showContent = new ShowContentService();
            IDepartmentLecture departmentLecture = new DepartmentLectureService();

            showContent.PrintContent(DataContent.ServiceContent.EnterDepId);
            CheckInputHelper.CheckInput(out int depId);

            //Add check for department ID;
            if (!CheckIfExists(db, depId))
            {
                showContent.PrintContent(DataContent.ErrorData.DepartmentAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            while (true)
            {
                showContent.PrintContent(DataContent.ServiceContent.EnterConsent);
                string addLectures = Console.ReadLine();

                if (addLectures.ToLower() == "yes")
                {
                    showContent.ShowAllLectures(db);
                    showContent.PrintContent(DataContent.ServiceContent.EnterLectureId);

                    var input = Console.ReadLine();
                    CheckInputHelper.ConvertInputToInt(input, out bool isNumeric);

                    if (!isNumeric)
                    {
                        showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                        Thread.Sleep(3000);
                        RedirectTo.MainMenu();
                        break;
                    }

                    CheckInputHelper.CheckInput(input, out int lectId);

                    departmentLecture.Create(db, depId, lectId);
                }

                if (addLectures.ToLower() != "yes")
                {
                    showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                    Thread.Sleep(3000);
                    RedirectTo.MainMenu();
                }
            }
        }

        public void Update(UniversityContext db, int depId)
        {
            IShowContent showContent = new ShowContentService();
            IDepartmentLecture departmentLecture = new DepartmentLectureService();

            //Add check for department ID;
            if (!CheckIfExists(db, depId))
            {
                showContent.PrintContent(DataContent.ErrorData.DepartmentAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            while (true)
            {
                showContent.PrintContent(DataContent.ServiceContent.EnterConsent);
                string addLectures = Console.ReadLine();

                if (addLectures.ToLower() == "yes")
                {
                    showContent.ShowAllLectures(db);
                    showContent.PrintContent(DataContent.ServiceContent.EnterLectureId);

                    var input = Console.ReadLine();
                    CheckInputHelper.ConvertInputToInt(input, out bool isNumeric);

                    if (!isNumeric)
                    {
                        showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                        Thread.Sleep(3000);
                        RedirectTo.MainMenu();
                        break;
                    }

                    CheckInputHelper.CheckInput(input, out int lectId);

                    departmentLecture.Create(db, depId, lectId);
                }

                if (addLectures.ToLower() != "yes")
                {
                    showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                    Thread.Sleep(3000);
                    RedirectTo.MainMenu();
                }
            }
        }
    }
}
