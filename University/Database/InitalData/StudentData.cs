using University.Enums;
using University.Models;

namespace University.Database.InitalData
{
    internal static class StudentData
    {
        public static Student[] DataSeed => new Student[] {
            new Student
            {
                StudentId = 1,
                StudentName = "Ted",
                StudentLastname = "Matrix",
                StudentAge = 18,
                StudentHeight = 1.85,
                StudentWeight = 90,
                StudentGender = MyEnums.GenderEnum.Male.ToString(),
                DepartmentId = 2
            },
            new Student
            {
                StudentId = 2,
                StudentName = "Steve",
                StudentLastname = "Collay",
                StudentAge = 19,
                StudentHeight = 1.88,
                StudentWeight = 93.51,
                StudentGender = MyEnums.GenderEnum.Male.ToString(),
                DepartmentId = 2
            },
            new Student
            {
                StudentId = 3,
                StudentName = "Mathew",
                StudentLastname = "Parry",
                StudentAge = 55,
                StudentHeight = 1.73,
                StudentWeight = 100.01,
                StudentGender = MyEnums.GenderEnum.Male.ToString(),
                DepartmentId = 1

            },
            new Student
            {
                StudentId = 4,
                StudentName = "Lisa",
                StudentLastname = "Wanvooren",
                StudentAge = 18,
                StudentHeight =  1.69,
                StudentWeight = 52,
                StudentGender = MyEnums.GenderEnum.Female.ToString(),
                DepartmentId = 1
            },
            new Student
            {
                StudentId = 5,
                StudentName = "Olivia",
                StudentLastname = "Wilde",
                StudentAge = 20,
                StudentHeight = 1.72,
                StudentWeight = 55,
                StudentGender = MyEnums.GenderEnum.Female.ToString(),
                DepartmentId = 2
            },
            new Student
            {
                StudentId = 6,
                StudentName = "Natan",
                StudentLastname = "Ogust",
                StudentAge = 25,
                StudentHeight = 2.01,
                StudentWeight = 100.5,
                StudentGender = MyEnums.GenderEnum.Male.ToString(),
                DepartmentId = 1
            },
            new Student
            {
                StudentId = 7,
                StudentName = "Jim",
                StudentLastname = "Carrey",
                StudentAge = 65,
                StudentHeight = 1.88,
                StudentWeight = 93,
                StudentGender = MyEnums.GenderEnum.Male.ToString(),
                DepartmentId = 2
            },
            new Student
            {
                StudentId = 8,
                StudentName = "Ashlun",
                StudentLastname = "Cyprus",
                StudentAge = 22,
                StudentHeight = 2,
                StudentWeight = 100,
                StudentGender = MyEnums.GenderEnum.Other.ToString(),
                DepartmentId = 1
            }
        };
    }
}
