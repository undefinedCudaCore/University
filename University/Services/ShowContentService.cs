using University.Services.Interfaces;

namespace University.Services
{
    internal class ShowContentService : IShowContent
    {
        public void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Please select action:");
            Console.WriteLine("1. Create department.");
            Console.WriteLine("2. Add student or lecture to department.");
            Console.WriteLine("3. Create a lecture.");
            Console.WriteLine("4. Create student.");
            Console.WriteLine("5. Move student to other department.");
            Console.WriteLine("6. Show all students of the department.");
            Console.WriteLine("7. Show all lectures of the department.");
            Console.WriteLine("8. Show all students lectures.");
        }
    }
}
