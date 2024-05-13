namespace University.Models
{
    internal class DepartmentLecture
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
