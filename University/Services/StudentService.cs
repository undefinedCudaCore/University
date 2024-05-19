﻿using University.Data;
using University.Database;
using University.Helpers;
using University.Models;
using University.Redirects;
using University.Services.Interfaces;

namespace University.Services
{
    internal class StudentService : IStudent
    {
        public Student Get(UniversityContext db, int studId)
        {
            var students = db.Students
                .Where(b => b.StudentId == studId)
                .ToList();

            return students[0];
        }
        public List<Student> GetAll(UniversityContext db)
        {
            var students = db.Students
                .ToList();

            return students;
        }
        public Student Create(UniversityContext db)
        {
            IShowContent showContent = new ShowContentService();
            IDepartment departmentService = new DepartmentService();
            var student = new Student();

            showContent.PrintContent(DataContent.StudentServiceContent.EnterName);
            CheckInputHelper.CheckInput(out string name);
            student.StudentName = name;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterLastname);
            CheckInputHelper.CheckInput(out string lastname);
            student.StudentLastname = lastname;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterAge);
            CheckInputHelper.CheckInput(out int age);
            student.StudentAge = age;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterHeight);
            CheckInputHelper.CheckInput(out double height);
            student.StudentHeight = height;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterWeight);
            CheckInputHelper.CheckInput(out double weight);
            student.StudentWeight = weight;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterGender);
            CheckInputHelper.CheckInput(out string gender);
            student.StudentGender = gender;

            showContent.PrintContent(DataContent.StudentServiceContent.EnterDepartmentsIdForStudent);
            CheckInputHelper.CheckInput(out int depId);
            student.DepartmentId = depId;

            if (!departmentService.CheckIfExists(db, depId))
            {
                showContent.PrintContent(DataContent.ErrorData.DepartmentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            db.Students.Add(student);
            db.SaveChanges();

            showContent.PrintContent(DataContent.ServiceContent.RecordCreated, (int)student.DepartmentId);
            Thread.Sleep(3000);
            RedirectTo.MainMenu();

            return student;
        }

        public Student Move(UniversityContext db, Student student, int depId)
        {
            throw new NotImplementedException();
        }

        public Student Update(UniversityContext db)
        {
            throw new NotImplementedException();
        }
    }
}
