using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Database;
using University.Redirects;
using University.Services.Interfaces;

namespace University.Services
{
    internal class ShowContentService : IShowContent
    {
        public void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine($"Please select action ({DataContent.ErrorData.EnterSelection}):");
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
                    Console.WriteLine("Students information: ");
                    Console.WriteLine($"ID: {student.StudentId}");
                    Console.WriteLine($"Name: {student.StudentName}");
                    Console.WriteLine($"Lastname: {student.StudentLastname}");
                    Console.WriteLine($"Age: {student.StudentAge}");
                    Console.WriteLine($"Weight: {student.StudentWeight}");
                    Console.WriteLine($"Height: {student.StudentHeight}");
                    Console.WriteLine($"Gender: {student.StudentGender}");
                    Console.WriteLine($"ID of the department to which the student belongs: {student.DepartmentId}");
                    Console.WriteLine("---------------------------------------------------------");
                }
            }

            Console.WriteLine(DataContent.ErrorData.PressKeyToReturnToMainMenu);
            Console.ReadKey();
            RedirectTo.MainMenu();
        }

        public void ShowLecturesOfDepartment(UniversityContext db, int depId, out bool cycle)
        {
            Console.Clear();
            cycle = false;

            //var departments = db.Departments
            //    .Include(b => b.DepartmentLectures)
            //    .ThenInclude(ab => ab.Lecture)
            //    .Where(b => b.DepartmentId == depId)
            //    .ToList();

            var departments4 = db.Departments
                .Where(b => b.DepartmentId == depId)
                .ToList();

            var departments3 = db.DepartmentLectures
                .Include(b => b.Lecture)
                .Where(b => b.DepartmentId == depId)
                .ToList();

            //var departments2 = db.DepartmentLectures
            //            .Where(dl => dl.DepartmentId == 2)
            //            .Join(db.Lectures,
            //                  dl => dl.LectureId,
            //                  l => l.LectureId,
            //                  (dl, l) => new
            //                  {
            //                      dl.DepartmentId,
            //                      l.LectureName
            //                  })
            //            .Take(1000)
            //            .ToList();

            foreach (var department in departments3)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Lecture information: ");
                Console.WriteLine($"Lecture ID: {department.Lecture.LectureId}");
                Console.WriteLine($"Lecture name: {department.Lecture.LectureName}");
                Console.WriteLine($"Department ID: {department.DepartmentId}");

                foreach (var department4 in departments4)
                {
                    Console.WriteLine($"Department name: {department4.DepartmentName}");
                }

                Console.WriteLine("---------------------------------------------------------");
            }

            Console.WriteLine(DataContent.ErrorData.PressKeyToReturnToMainMenu);
            Console.ReadKey();
            RedirectTo.MainMenu();
        }

        public void ShowStudentLectures(UniversityContext db, int studId, out bool cycle)
        {
            Console.Clear();
            cycle = false;

            var lectureStudents = db.LectureStudents
                .Include(b => b.Student)
                .Include(b => b.Lecture)
                .Where(b => b.StudentId == studId)
                .ToList();

            Console.WriteLine($"Student ID: {lectureStudents[studId - 1].Student.StudentId}");
            Console.WriteLine($"Student name: {lectureStudents[studId - 1].Student.StudentName}");
            foreach (var ls in lectureStudents)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine($"Lecture ID: {ls.Lecture.LectureId}");
                Console.WriteLine($"Lecture Name: {ls.Lecture.LectureName}");
                Console.WriteLine("---------------------------------------------------------");
            }

            Console.WriteLine(DataContent.ErrorData.PressKeyToReturnToMainMenu);
            Console.ReadKey();
            RedirectTo.MainMenu();
        }

        public void PrintContent(string content)
        {
            Console.WriteLine(content);
        }
    }
}
