namespace University.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentAge { get; set; }
        public double StudentHeight { get; set; }
        public double Studenteight { get; set; }
        public string StudentGender { get; set; }

        public int? DepartmentId { get; set; }
        public IList<Department> Departments { get; set; }
        public IList<Lecture> Lectures { get; set; }
    }
}
