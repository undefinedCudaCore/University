using University.Models;

namespace University.Database.InitalData
{
    internal static class DepartmentData
    {
        public static Department[] DataSeed => new Department[] {
            new Department
            {
                DepartmentId = 1,
                DepartmentName = "Exact science",
            },
            new Department
            {
                DepartmentId = 2,
                DepartmentName = "Social science"
            }
        };
    }
}
