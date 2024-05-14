using University.Database;
using University.Models;
using University.Services.Interfaces;

namespace University.Services
{
    internal class StudentService : IManageData, IMoveData
    {
        public void Create(UniversityContext db)
        {
            throw new NotImplementedException();
        }

        public void Move(UniversityContext db, Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(UniversityContext db)
        {
            throw new NotImplementedException();
        }
    }
}
