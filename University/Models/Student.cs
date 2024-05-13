namespace University.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastname { get; set; }
        public int StudentAge { get; set; }
        public double StudentHeight { get; set; }
        public double StudentWeight { get; set; }
        public string StudentGender { get; set; }

        public int? DepartmentId { get; set; }
        //public IList<Department> Departments { get; set; } = new List<Department>();

        public int? LectureId { get; set; }
        //public Lecture Lecture { get; set; }
        //public IList<Lecture> Lectures { get; set; } = new List<Lecture>();

        public IList<LectureStudent> LectureStudents { get; set; } = new List<LectureStudent>();
    }
}
