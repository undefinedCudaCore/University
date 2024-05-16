﻿using University.Data;
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
                    IDepartment departmenService = new DepartmentService();
                    ILecture lectureService = new LectureService();
                    IStudent studentService = new StudentService();
                    IShowContent showContent = new ShowContentService();
                    showContent.ShowMainMenu();

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            showContent.ShowAllDepartments(db);
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
                            studentService.Move(db, new Student(), 3);
                            break;
                        case "6":
                            showContent.PrintContent(DataContent.ErrorData.EnterDepartmentId);
                            showContent.ShowAllDepartments(db);
                            CheckInputHelper.CheckInput(out newInput);
                            showContent.ShowStudentsOfDepartment(db, newInput, out cycle);
                            break;
                        case "7":
                            showContent.PrintContent(DataContent.ErrorData.EnterDepartmentId);
                            showContent.ShowAllDepartments(db);
                            CheckInputHelper.CheckInput(out newInput);
                            showContent.ShowLecturesOfDepartment(db, newInput, out cycle);
                            break;
                        case "8":
                            showContent.PrintContent(DataContent.ErrorData.EnterStudentId);
                            showContent.ShowAllStudents(db);
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
