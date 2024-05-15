using University.Models;

namespace University.Database.InitalData
{
    internal static class DepartmentLectureData
    {
        public static DepartmentLecture[] DataSeed => new DepartmentLecture[] {
            new DepartmentLecture
            {
                DepartmentId = 1,
                LectureId = 1,
            },
            new DepartmentLecture
            {
                DepartmentId = 1,
                LectureId = 2,
            },
            //new DepartmentLecture
            //{
            //    DepartmentId = 1,
            //    LectureId = 3,
            //},
            //new DepartmentLecture
            //{
            //    DepartmentId = 1,
            //    LectureId = 4,
            //},
            //new DepartmentLecture
            //{
            //    DepartmentId = 2,
            //    LectureId = 1,
            //},
            //new DepartmentLecture
            //{
            //    DepartmentId = 2,
            //    LectureId = 2,
            //},
            new DepartmentLecture
            {
                DepartmentId = 2,
                LectureId = 3,
            },
            new DepartmentLecture
            {
                DepartmentId = 2,
                LectureId = 4,
            }
        };

    }
}
