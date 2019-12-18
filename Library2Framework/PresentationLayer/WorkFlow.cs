using Library2Framework.DataLayer;
using Library2Framework.DomainLayer;
using Library2Framework.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.Utils
{
    public class WorkFlow
    {
        private EditionServices editionServices;
        private UserServices userServices;
        private DomainServices domainServices;

        private const int exit = 13;

        public WorkFlow()
        {
            editionServices = new EditionServices();
            userServices = new UserServices();
            domainServices = new DomainServices();
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                int choice = ReadChoice();

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        userServices.AddReader();
                        ScreenPause();
                        break;
                    case 2: 
                        Console.ForegroundColor = ConsoleColor.Blue;
                        userServices.AddLibrarian();
                        ScreenPause();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        domainServices.AddDomain();
                        ScreenPause();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        editionServices.AddEdition();
                        ScreenPause();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        editionServices.AddAuthorForEdition();
                        ScreenPause();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        editionServices.BorrowBook();
                        ScreenPause();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        List<Edition> books = EditionDAL.GetBooksAlphabetical();
                        Display(books);
                        ScreenPause();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        List<Edition> borrowed = EditionDAL.GetBorrowedBooksAlphabetical();
                        Display(borrowed);
                        ScreenPause();
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        List<Author> authors = editionServices.GetAuthorsForEdition();
                        Display(authors);
                        ScreenPause();
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        List<User> librarians = UserDAL.GetLibrarians();
                        Display(librarians);
                        ScreenPause();
                        break;
                    case 11:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        List<User> readers = UserDAL.GetReaders();
                        Display(readers);
                        ScreenPause();
                        break;
                    case 12:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        List<Domain> domains = DomainDAL.GetDomains();
                        Display(domains);
                        ScreenPause();
                        break;
                    case exit:
                        Console.WriteLine("\n Bye-bye! :)");
                        return;
                        break;
                }
            }
        }

        private void ScreenPause()
        {
            Console.ResetColor();
            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("(1) Add new reader");
            Console.WriteLine("(2) Add new librarian");
            Console.WriteLine("(3) Add new domain");
            Console.WriteLine("(4) Add new edition");
            Console.WriteLine("(5) Add new author for one edition");
            Console.WriteLine("(6) Borrow edition");
            Console.WriteLine("(7) List all books alphabetically");
            Console.WriteLine("(8) List all borrowed books alphabetically");
            Console.WriteLine("(9) List all authors for one book");
            Console.WriteLine("(10) List librarians");
            Console.WriteLine("(11) List readers");
            Console.WriteLine("(12) List domains");
            Console.WriteLine("(13) Exit application");
            Console.ResetColor();
        }

        private int ReadChoice()
        {
            bool ok = false;
            int choice = 0;
            while (ok == false)
            {
                Console.Write("\nInsert option:");
                String str = Console.ReadLine();
                ok = Int32.TryParse(str, out choice);
                if (choice < 0 || choice > exit) ok = false;
            }
            return choice;
        }

        private void Display<T>(List<T> list)
        {
            foreach (T obj in list)
            {
                Console.WriteLine("\n" + (list.IndexOf(obj)+1) + ". " + obj);
            }
        }

        

    }
}
