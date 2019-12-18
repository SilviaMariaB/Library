using Library2Framework.DataLayer;
using Library2Framework.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.Utils
{
    public class WorkFlow
    {
        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                int choice = ReadChoice();

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        ScreenPause();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        ScreenPause();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        ScreenPause();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        ScreenPause();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        ScreenPause();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        List<Edition> books = EditionDAL.GetBooksAlphabetical();
                        Display(books);
                        ScreenPause();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        List<Edition> borrowed = EditionDAL.GetBorrowedBooksAlphabetical();
                        Display(borrowed);
                        ScreenPause();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        GetAuthorsForBook();
                        ScreenPause();
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        List<User> librarians = UserDAL.GetLibrarians();
                        Display(librarians);
                        ScreenPause();
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        List<User> readers = UserDAL.GetReaders();
                        Display(readers);
                        ScreenPause();
                        break;
                    case 11:
                        Console.WriteLine("Bye-bye! :)");
                        return;
                        break;
                }
            }
        }

        public void ScreenPause()
        {
            Console.ResetColor();
            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("(1) Add new reader");
            Console.WriteLine("(2) Add new librarian");
            Console.WriteLine("(3) Add new domain");
            Console.WriteLine("(4) Add new book");
            Console.WriteLine("(5) Borrow book");
            Console.WriteLine("(6) List all books alphabetically");
            Console.WriteLine("(7) List all borrowed books alphabetically");
            Console.WriteLine("(8) List all authors for one book");
            Console.WriteLine("(9) List librarians");
            Console.WriteLine("(10) List readers");
            Console.WriteLine("(11) Exit application");
            Console.ResetColor();
        }

        public int ReadChoice()
        {
            bool ok = false;
            int choice = 0;
            while (ok == false)
            {
                Console.Write("\nInsert option:");
                String str = Console.ReadLine();
                ok = Int32.TryParse(str, out choice);
                if (choice < 0 || choice > 11) ok = false;
            }
            return choice;
        }

        public void Display<T>(List<T> list)
        {
            foreach (T obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        public void GetAuthorsForBook()
        {
            String BookName = Helper.ReadString("Introduce the name of the book:");

            int PublicationYear = Helper.ReadYear("Introduce the year of publishing:");

            String PublishingHouseName = Helper.ReadString("Introduce publishing house name:");

            List<Author> authors = AuthorDAL.GetAuthorsForBook(BookName, PublicationYear, PublishingHouseName);

            if (authors.Count == 0)
            {
                Helper.DisplayError("There are no items with those atributes!");

            }
            Display(authors);
        }

    }
}
