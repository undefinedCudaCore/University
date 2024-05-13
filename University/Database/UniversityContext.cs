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

        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public string ConnectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(ab => new { ab.LectureId, ab.StudentId });

                entity.HasOne(a => a.Lecture)
                    .WithMany(a => a.Departments)
                    .HasForeignKey(a => a.LectureId);

                entity.HasOne(a => a.Student)
                    .WithMany(a => a.Departments)
                    .HasForeignKey(a => a.StudentId);

                entity.Property(a => a.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(bc => new { bc.DepartmentId, bc.StudentId });

                entity.HasOne(b => b.Department)
                    .WithMany(b => b.Lectures)
                    .HasForeignKey(b => b.DepartmentId);

                entity.HasOne(b => b.Student)
                    .WithMany(b => b.Lectures)
                    .HasForeignKey(b => b.StudentId);

                entity.Property(b => b.LectureName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(b => b.LectureGrade)
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.HasOne(s => s.Lecture)
                    .WithMany(s => s.Students)
                    .HasForeignKey(s => s.LectureId);

                entity.Property(s => s.StudentName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(s => s.StudentLastname)
                    .HasMaxLength(50);
                entity.Property(s => s.StudentAge)
                    .IsRequired()
                    .HasColumnType("bigint");
                entity.Property(s => s.StudentHeight)
                    .HasColumnType("decimal(5, 2)");
                entity.Property(s => s.StudentWeight)
                    .HasColumnType("decimal(5, 2)");
                entity.Property(a => a.StudentGender)
                    .IsRequired()
                    .HasColumnType("enum");
                entity.Property(s => s.DepartmentId)
                    .IsRequired();
            });

        }
    }
}
