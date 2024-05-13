namespace University.Models
{
    internal class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public int? LectureId { get; set; }
        public Lecture Lecture { get; set; }
        public IList<Lecture> Lectures { get; set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
