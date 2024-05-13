using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Database
{
    internal class UniversityContext : DbContext
    {
        public UniversityContext()
        {
            ConnectionString = "Data Source=LENOVOY520\\SQLEXPRESS;Initial Catalog=UniversityDB;" +
                "Integrated Security=True;Encrypt=False";
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Department> Departments { get; set; }
        public string ConnectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                //entity.HasOne(s => s.Lecture)
                //    .WithMany(s => s.Students)
                //    .HasForeignKey(s => s.LectureId);

                entity.Property(s => s.StudentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnOrder(1);
                entity.Property(s => s.StudentLastname)
                    .HasMaxLength(50)
                    .HasColumnOrder(2);
                entity.Property(s => s.StudentAge)
                    .IsRequired()
                    .HasColumnOrder(3)
                    .HasColumnType("bigint");
                entity.Property(s => s.StudentHeight)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnOrder(4);
                entity.Property(s => s.StudentWeight)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnOrder(5);
                entity.Property(a => a.StudentGender)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnOrder(6);
                entity.Property(s => s.DepartmentId)
                    .IsRequired()
                    .HasColumnOrder(7);
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(s => s.LectureId);

                //entity.HasOne(b => b.Department)
                //    .WithMany(b => b.Lectures)
                //    .HasForeignKey(b => b.DepartmentId);

                //entity.HasOne(b => b.Student)
                //    .WithMany(b => b.Lectures)
                //    .HasForeignKey(b => b.StudentId);

                entity.Property(b => b.LectureName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnOrder(1);
                entity.Property(b => b.LectureGrade)
                    .HasMaxLength(2)
                    .HasColumnOrder(2);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(s => s.DepartmentId);

                //entity.HasOne(a => a.Lecture)
                //    .WithMany(a => a.Departments)
                //    .HasForeignKey(a => a.LectureId);

                //entity.HasOne(a => a.Student)
                //    .WithMany(a => a.Departments)
                //    .HasForeignKey(a => a.StudentId);

                entity.Property(a => a.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DepartmentLecture>(entity =>
            {
                // Konfiguoruojam PK
                entity.HasKey(dl => new { dl.DepartmentId, dl.LectureId });
                // Konfiguruojam FK DepartmentLecture -> Department
                entity.HasOne(dl => dl.Department)
                    .WithMany(a => a.DepartmentLectures)
                    .HasForeignKey(ab => ab.DepartmentId);
                // Konfiguruojam FK DepartmentLecture->Lecture
                entity.HasOne(ab => ab.Lecture)
                    .WithMany(a => a.DepartmentLectures)
                    .HasForeignKey(ab => ab.LectureId);
            });

            modelBuilder.Entity<LectureStudent>(entity =>
            {
                // Konfiguoruojam PK
                entity.HasKey(dl => new { dl.LectureId, dl.StudentId });
                // Konfiguruojam FK LectureStudent -> Lecture
                entity.HasOne(dl => dl.Lecture)
                    .WithMany(a => a.LectureStudents)
                    .HasForeignKey(ab => ab.LectureId);
                // Konfiguruojam FK LectureStudent->Student
                entity.HasOne(ab => ab.Student)
                    .WithMany(a => a.LectureStudents)
                    .HasForeignKey(ab => ab.StudentId);
            });
        }
    }
}
