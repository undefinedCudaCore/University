namespace University.Data
{
    internal static class DataContent
    {
        internal static class ErrorData
        {
            internal static readonly string WrongInput = "Wrong user input.";
            internal static readonly string RedirectToMainMenu = "Redirecting to the main menu.";
            internal static readonly string PressKeyToReturnToMainMenu = "Press any key to return to the main menu.";
            internal static readonly string EnterSelection = "Type your selection and press ENTER:";
            internal static readonly string EnterDepartmentId = "Type department ID and press ENTER:";
            internal static readonly string EnterStudentId = "Type student ID and press ENTER:";
            internal static readonly string DepartmentAlredyExists = "You can't create a new department, department already exists.";
            internal static readonly string LectureAlredyExists = "You can't create a new lecture, lecture already exists.";
            internal static readonly string StudentAlredyExists = "You can't create a new student, student already exists.";
            internal static readonly string DepartmentNotExists = "You can't create a new record, department does not exist.";
            internal static readonly string LectureNotExists = "You can't create a new record, lecture does not exist.";
            internal static readonly string StudentNotExists = "You can't create a new record, student does not exist.";
        }

        internal static class ServiceContent
        {
            internal static readonly string EnterDepId = "Enter Department ID:";
            internal static readonly string EnterLectId = "Enter Lecture ID:";
            internal static readonly string EnterDepName = "Enter Department name:";
            internal static readonly string EnterLectName = "Enter Lecture name:";
            internal static readonly string RecordCreated = "Record created successfuly with ID ";
            internal static readonly string EnterConsent = "Type 'YES' if you want add lectures press ENTER:";
            internal static readonly string EnterLectureId = "Type lecture ID and press ENTER:";
            internal static readonly string EnterStudentId = "Type student ID and press ENTER:";
        }

        internal static class StudentServiceContent
        {
            internal static readonly string EnterName = "Type students name and press ENTER";
            internal static readonly string EnterLastname = "Type students lastname and press ENTER";
            internal static readonly string EnterAge = "Type students age and press ENTER";
            internal static readonly string EnterHeight = "Type students height and press ENTER";
            internal static readonly string EnterWeight = "Type students Weight and press ENTER";
            internal static readonly string EnterGender = "Type students gender and press ENTER";
            internal static readonly string EnterDepartmentsIdForStudent = "Type departments ID and press ENTER";
            internal static readonly string EnterDepId = "Enter the department ID to change:";
        }
    }
}
