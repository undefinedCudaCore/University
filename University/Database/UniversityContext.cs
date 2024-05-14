using Microsoft.EntityFrameworkCore;
using University.Database.InitalData;
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

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.DepartmentId);

                //entity.HasOne(a => a.Lecture)
                //    .WithMany(a => a.Departments)
                //    .HasForeignKey(a => a.LectureId);

                //entity.HasOne(a => a.Student)
                //    .WithMany(a => a.Departments)
                //    .HasForeignKey(a => a.StudentId);

                entity.Property(d => d.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(l => l.LectureId);

                //entity.HasOne(b => b.Department)
                //    .WithMany(b => b.Lectures)
                //    .HasForeignKey(b => b.DepartmentId);

                //entity.HasOne(b => b.Student)
                //    .WithMany(b => b.Lectures)
                //    .HasForeignKey(b => b.StudentId);

                entity.Property(l => l.LectureName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.HasOne(s => s.Department)
                    .WithMany(s => s.Students)
                    .HasForeignKey(s => s.DepartmentId);

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
                entity.Property(s => s.StudentGender)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnOrder(6);
            });

            modelBuilder.Entity<DepartmentLecture>(entity =>
            {
                // Konfiguoruojam PK
                entity.HasKey(dl => new { dl.DepartmentId, dl.LectureId });
                // Konfiguruojam FK DepartmentLecture -> Department
                entity.HasOne(dl => dl.Department)
                    .WithMany(dl => dl.DepartmentLectures)
                    .HasForeignKey(dl => dl.DepartmentId);
                // Konfiguruojam FK DepartmentLecture->Lecture
                entity.HasOne(dl => dl.Lecture)
                    .WithMany(dl => dl.DepartmentLectures)
                    .HasForeignKey(dl => dl.LectureId);
            });

            modelBuilder.Entity<LectureStudent>(entity =>
            {
                // Konfiguoruojam PK
                entity.HasKey(ls => new { ls.LectureId, ls.StudentId });
                // Konfiguruojam FK LectureStudent -> Lecture
                entity.HasOne(ls => ls.Lecture)
                    .WithMany(ls => ls.LectureStudents)
                    .HasForeignKey(ls => ls.LectureId);
                // Konfiguruojam FK LectureStudent->Student
                entity.HasOne(ls => ls.Student)
                    .WithMany(ls => ls.LectureStudents)
                    .HasForeignKey(ls => ls.StudentId);
            });

            modelBuilder.Entity<Department>().HasData(DepartmentData.DataSeed);
            modelBuilder.Entity<Lecture>().HasData(LectureData.DataSeed);
            modelBuilder.Entity<Student>().HasData(StudentData.DataSeed);
            modelBuilder.Entity<DepartmentLecture>().HasData(DepartmentLectureData.DataSeed);
            modelBuilder.Entity<LectureStudent>().HasData(LectureStudentData.DataSeed);
        }
    }
}
