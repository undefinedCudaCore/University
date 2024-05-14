using University.Database;
using University.Services;
using University.Services.Interfaces;

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
                    IShowContent showContent = new ShowContentService();
                    showContent.ShowMainMenu();

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
