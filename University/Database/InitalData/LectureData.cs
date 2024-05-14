using University.Models;

namespace University.Database.InitalData
{
    internal static class LectureData
    {
        public static Lecture[] DataSeed => new Lecture[] {
            new Lecture
            {
                LectureId = 1,
                LectureName = "Math",
            },
            new Lecture
            {
                LectureId = 2,
                LectureName = "Informatics",
            },
            new Lecture
            {
                LectureId = 3,
                LectureName = "Biology",
            },
            new Lecture
            {
                LectureId = 4,
                LectureName = "Geography",
            }
        };
    }
}
