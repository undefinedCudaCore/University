using University.Database;

namespace University.Services.Interfaces
{
    public interface IManageData
    {
        internal void Create(UniversityContext db);
        internal void Update(UniversityContext db);
    }
}
