﻿using University.Data;
using University.Database;
using University.Redirects;
using University.Services;
using University.Services.Interfaces;

namespace University.Helpers
{
    internal static class CheckLectureAndStudentExists
    {
        public static void CheckIfExists(UniversityContext db, int lectId, int studId)
        {
            IShowContent showContent = new ShowContentService();
            ILecture lectureService = new LectureService();
            IStudent studentService = new StudentService();

            if (!studentService.CheckIfExists(db, studId) && !lectureService.CheckIfExists(db, lectId))
            {
                showContent.PrintContent(DataContent.ErrorData.LectureNotExists);
                showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            if (!lectureService.CheckIfExists(db, lectId))
            {
                showContent.PrintContent(DataContent.ErrorData.LectureNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }

            if (!studentService.CheckIfExists(db, studId))
            {
                showContent.PrintContent(DataContent.ErrorData.StudentNotExists);
                showContent.PrintContent(DataContent.ErrorData.RedirectToMainMenu);
                Thread.Sleep(3000);
                RedirectTo.MainMenu();
            }
        }
    }
}
