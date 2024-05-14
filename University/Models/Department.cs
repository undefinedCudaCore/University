using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("Department")]

    internal class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        //public int? LectureId { get; set; }
        //public Lecture Lecture { get; set; }
        //public IList<Lecture> Lectures { get; set; } = new List<Lecture>();

        //public int? StudentId { get; set; }
        //public Student Student { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();

        public IList<DepartmentLecture> DepartmentLectures { get; set; } = new List<DepartmentLecture>();
    }
}
