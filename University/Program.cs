using University.Data;
using University.Database;
using University.Helpers;
using University.Models;
using University.Services;
using University.Services.Interfaces;

namespace University
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OutsetProgram();
        }

        internal static void OutsetProgram()
        {
            using (var db = new UniversityContext())
            {
                db.Database.EnsureCreated();
                bool cycle = true;
                int newInput;

                while (cycle)
                {
                    IManageData departmenService = new DepartmentService();
                    IManageData lectureService = new LectureService();
                    IManageData studentService = new StudentService();
                    IMoveData studentServiceToMove = new StudentService();
                    IShowContent showContent = new ShowContentService();
                    showContent.ShowMainMenu();

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            departmenService.Create(db);
                            break;
                        case "2":
                            departmenService.Update(db);
                            break;
                        case "3":
                            lectureService.Create(db);
                            break;
                        case "4":
                            studentService.Create(db);
                            break;
                        case "5":
                            studentServiceToMove.Move(db, new Student());
                            break;
                        case "6":
                            showContent.PrintContent(DataContent.ErrorData.EnterDepartmentId);
                            CheckInputHelper.CheckInput(out newInput);
                            showContent.ShowStudentsOfDepartment(db, newInput, out cycle);
                            break;
                        case "7":
                            showContent.PrintContent(DataContent.ErrorData.EnterDepartmentId);
                            CheckInputHelper.CheckInput(out newInput);
                            showContent.ShowLecturesOfDepartment(db, newInput, out cycle);
                            break;
                        case "8":
                            showContent.PrintContent(DataContent.ErrorData.EnterStudentId);
                            CheckInputHelper.CheckInput(out newInput);
                            showContent.ShowStudentLectures(db, newInput, out cycle);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
