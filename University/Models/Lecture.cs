using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Lecture")]
    internal class Lecture
    {
        public Lecture()
        {
        }

        public Lecture(int lectureId, string lectureName)
        {
            LectureId = lectureId;
            LectureName = lectureName;
        }

        public int LectureId { get; set; }
        public string LectureName { get; set; }

        //public int? DepartmentId { get; set; }
        //public Department Department { get; set; }
        //public IList<Department> Departments { get; set; } = new List<Department>();

        //public int? StudentId { get; set; }
        //public Student Student { get; set; }
        //public IList<Student> Students { get; set; } = new List<Student>();

        public IList<DepartmentLecture> DepartmentLectures { get; set; } = new List<DepartmentLecture>();
        public IList<LectureStudent> LectureStudents { get; set; } = new List<LectureStudent>();
    }
}
