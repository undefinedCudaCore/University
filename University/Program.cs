using University.Database;

namespace University
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UniversityContext())
            {
                db.Database.EnsureCreated();

                while (true)
                {
                    Console.WriteLine("Please select action:");
                    Console.WriteLine("1. Create department.");
                    Console.WriteLine("2. Update book.");
                    Console.WriteLine("3. Delete book.");
                    Console.WriteLine("4. Create page in book.");
                    Console.WriteLine("5. Read books and pages.");
                    Console.WriteLine("6. Read books and pages.");
                    Console.WriteLine("7. Read books and pages.");
                    Console.WriteLine("8. Read books and pages.");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            //CreateBook(db);
                            break;
                        case "2":
                            //UpdateBook(db);
                            break;
                        case "3":
                            //RemoveBook(db);
                            break;
                        case "4":
                            //CreatePageInBook(db);
                            break;
                        case "5":
                            //ReadBooksAndPages(db);
                            break;
                        case "6":
                            //ReadBooksAndPages(db);
                            break;
                        case "7":
                            //ReadBooksAndPages(db);
                            break;
                        case "8":
                            //ReadBooksAndPages(db);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
