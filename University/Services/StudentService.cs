using University.Data;
using University.Database;
using University.Helpers;
using University.Models;
using University.Redirects;
using University.Services.Interfaces;

namespace University.Services
{
    internal class StudentService : IStudent
    {
        public Student Get(UniversityContext db, int studId)
        {
            var students = db.Students
                .Where(b => b.StudentId == studId)
                .FirstOrDefault();

            return students;
        }
        public List<Student> GetAll(UniversityContext db)
        {
            var students = db.Students
                .ToList();

            return students;
        }
        public Student Create(UniversityContext db)
        {
            IShowContent showContent = new ShowContentService();
            IDepartment departmentService = new DepartmentService();
            var student = new Student();

            showContent.PrintContent(DataContent.StudentServiceContent.EnterName);
            CheckInputHelper.CheckInput(out string name);
            CheckNameExists.IfStudentNameExists(db, name);
            student.StudentName = name;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterLastname);
            CheckInputHelper.CheckInput(out string lastname);
            student.StudentLastname = lastname;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterAge);
            CheckInputHelper.CheckInput(out int age);
            student.StudentAge = age;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterHeight);
            CheckInputHelper.CheckInput(out double height);
            student.StudentHeight = height;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterWeight);
            CheckInputHelper.CheckInput(out double weight);
            student.StudentWeight = weight;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterGender);
            CheckInputHelper.CheckInput(out string gender);
            student.StudentGender = gender;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterDepartmentsIdForStudent);
            CheckInputHelper.CheckInput(out int depId);
            student.DepartmentId = depId;

            if (!departmentService.CheckIfExists(db, depId))
            {
                showContent.PrintContent(DataContent.ErrorData.DepartmentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            db.Students.Add(student);
            db.SaveChanges();

            Update(db, depId, student.StudentId);

            showContent.PrintContent(DataContent.ServiceContent.RecordCreated + "(department ID) ", (int)student.DepartmentId);
            Thread.Sleep(3000);
            RedirectTo.MainMenu();

            return student;
        }

        public Student Move(UniversityContext db)
        {
            IShowContent showContentService = new ShowContentService();
            ILectureStudent lectureStudentService = new LectureStudentService();

            showContentService.PrintContent(DataContent.ServiceContent.EnterStudentId);
            CheckInputHelper.CheckInput(out int studId);
            CheckObjectExists.CheckIfStudentExists(db, studId);

            var student = Get(db, studId);

            showContentService.PrintContent(DataContent.StudentServiceContent.EnterDepId);
            CheckInputHelper.CheckInput(out int newDepId);
            CheckObjectExists.CheckIfDepartmentExists(db, newDepId);

            if (student.DepartmentId == newDepId)
            {
                showContentService.PrintContent(DataContent.ErrorData.DepartmentIdBelongToStudent);
                showContentService.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                return student;
            }

            student.DepartmentId = newDepId;
            db.Students.Update(student);

            var lectureStudents = lectureStudentService.GetAll(db);

            foreach (var ls in lectureStudents)
            {
                if (ls.StudentId == student.StudentId)
                {
                    db.LectureStudents.Remove(ls);
                    db.SaveChanges();
                }
            }

            lectureStudentService.Update(db, newDepId, studId);
            db.SaveChanges();

            return student;
        }

        public void Update(UniversityContext db, int depId, int studId)
        {
            ILectureStudent lectureStudentService = new LectureStudentService();
            lectureStudentService.Update(db, depId, studId);
        }

        public bool CheckIfExists(UniversityContext db, int studId)
        {
            var student = db.Students.Find(studId);

            if (student != null)
            {
                return true;
            }

            return false;
        }
    }
}
