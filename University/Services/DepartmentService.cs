using University.Data;
using University.Database;
using University.Helpers;
using University.Models;
using University.Redirects;
using University.Services.Interfaces;

namespace University.Services
{
    internal class DepartmentService : IDepartment

    {
        public Department Get(UniversityContext db, int depId)
        {
            var departments = db.Departments
                .Where(b => b.DepartmentId == depId)
                .ToList();

            return departments[0];
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
            string depName = Console.ReadLine();

            //Add check for department ID;
            if (CheckIfExists(db, depId))
            {
                showContent.PrintContent(DataContent.ErrorData.DepartmentAlredyExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
                return new Department();
            }

            //Add lectures to department

            //Add students to department


            var department = new Department() { /*DepartmentId = depId, */DepartmentName = depName };
            db.Departments.Add(department);
            db.SaveChanges();

            showContent.PrintContent(DataContent.ServiceContent.RecordCreated, department.DepartmentId);
            Thread.Sleep(3000);
            RedirectTo.MainMenu();

            return department;
        }

        private bool CheckIfExists(UniversityContext db, int depId)
        {
            var department = db.Departments.Find(depId);

            if (department != null)
            {
                return true;
            }

            return false;
        }

        public Department Update(UniversityContext db)
        {
            //IShowContent showContent = new ShowContentService();

            //showContent.PrintContent(DataContent.ServiceContent.EnterDepId);
            //CheckInputHelper.CheckInput(out int depId);

            //showContent.PrintContent(DataContent.ServiceContent.EnterDepName);
            //string depName = Console.ReadLine();

            return new Department();
        }
    }
}
