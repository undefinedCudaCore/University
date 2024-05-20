using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IDepartment
    {
        public Department Create(UniversityContext db);
        public void Update(UniversityContext db);
        public void Update(UniversityContext db, int depId);
        public Department Get(UniversityContext db, int depId);
        public bool CheckIfExists(UniversityContext db, int depId);
        public List<Department> GetAll(UniversityContext db);
    }
}
