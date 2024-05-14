using University.Database;
using University.Models;

namespace University.Services.Interfaces
{
    public interface IMoveData
    {
        internal void Move(UniversityContext db, Student student);
    }
}
