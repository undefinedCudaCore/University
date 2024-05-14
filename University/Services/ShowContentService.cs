using Microsoft.EntityFrameworkCore;
using University.Database;
using University.Services.Interfaces;

namespace University.Services
{
    internal class ShowContentService : IShowContent
    {
        public void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Please select action:");
            Console.WriteLine("1. Create department.");
            Console.WriteLine("2. Add student/lecture to department.");
            Console.WriteLine("3. Create a lecture.");
            Console.WriteLine("4. Create student.");
            Console.WriteLine("5. Move student to other department.");
            Console.WriteLine("6. Show all students of the department.");
            Console.WriteLine("7. Show all lectures of the department.");
            Console.WriteLine("8. Show all students lectures.");
        }

        public void ShowStudentsOfDepartment(UniversityContext db, int depId, out bool cycle)
        {
            Console.Clear();
            cycle = false;

            var departments = db.Departments
                .Include(b => b.Students)
                .Where(b => b.DepartmentId == depId)
                .ToList();

            foreach (var item in departments)
            {
                foreach (var student in item.Students)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine(student.StudentId);
                    Console.WriteLine(student.StudentName);
                    Console.WriteLine(student.StudentLastname);
                    Console.WriteLine(student.StudentAge);
                    Console.WriteLine(student.StudentWeight);
                    Console.WriteLine(student.StudentHeight);
                    Console.WriteLine(student.StudentGender);
                    Console.WriteLine(student.DepartmentId);
                    Console.WriteLine("---------------------------------------------------------");
                }
            }

        }

        public void ShowLecturesOfDepartment(UniversityContext db, out bool cycle)
        {
            Console.Clear();
            cycle = false;

            Console.WriteLine("----------------------");
        }

        public void ShowStudentLectures(UniversityContext db, out bool cycle)
        {
            Console.Clear();
            cycle = false;

        }
    }
}
