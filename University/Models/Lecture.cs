namespace University.Models
{
    internal class Lecture
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public string LectureGrade { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public IList<Department> Departments { get; private set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public IList<Student> Students { get; private set; }
    }
}
