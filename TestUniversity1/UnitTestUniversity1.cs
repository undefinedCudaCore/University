using University.Database;
using University.Models;
using University.Services;
using University.Services.Interfaces;

namespace TestUniversity1
{
    [TestClass]
    public class UnitTestUniversity1
    {
        [TestMethod]
        public void TestDepartmentObjectExistsInDataBase()
        {
            using (var db = new UniversityContext())
            {

                //Arrange
                Department department = new Department() { DepartmentId = 1, DepartmentName = "Exact science" };


                //Act
                IDepartment departmentService = new DepartmentService();
                Department depToTest = departmentService.Get(db, 1);

                //Assert
                Assert.AreEqual(department.DepartmentId, depToTest.DepartmentId);
                Assert.AreEqual(department.DepartmentName, depToTest.DepartmentName);
            }
        }

        [TestMethod]
        public void TestDepartmentObjectCreateInDataBase()
        {
            using (var db = new UniversityContext())
            {

                //Arrange
                Department department = new Department() { DepartmentId = 12, DepartmentName = "Exact science2" };


                //Act
                IDepartment departmentService = new DepartmentService();
                Department depToTest = departmentService.Get(db, 2);

                //Assert
                Assert.AreNotEqual(department.DepartmentId, depToTest.DepartmentId);
                Assert.AreNotEqual(department.DepartmentName, depToTest.DepartmentName);
            }
        }
    }
}