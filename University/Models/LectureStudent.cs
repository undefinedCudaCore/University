namespace University.Models
{
    internal class LectureStudent
    {
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
