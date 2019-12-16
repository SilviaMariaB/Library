using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library2Framework.DataLayer;
using Library2Framework.DomainLayer;
using Library2Framework.Utils;
using log4net;

namespace Library2Framework
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {

            GetAuthorsForBook();
        }

        public static void GetAuthorsForBook()
        {
            String BookName = ReadString("Introduce the name of the book:");

            int PublicationYear = ReadYear("Introduce the year of publishing:");

            String PublishingHouseName = ReadString("Introduce publishing house name:");


            List<Author> authors = AuthorDAL.GetAuthorsForBook(BookName, PublicationYear, PublishingHouseName);

            if (authors.Count == 0)
            {
                DisplayError("There are no items with those atributes!");

            }
            foreach (Author author in authors)
            {
                Console.WriteLine(author);
            }
        }

        public static void DisplayError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        public static String ReadString(string message)
        {
            Console.Write(message);
            String str = Console.ReadLine();
            str = str.ToLower();
            str = str.Trim();
            return str;
        }

        public static int ReadYear(string message)
        {

            String str = null;

            bool ok = false;
            int value = 0;
            while (ok == false)
            {
                Console.Write(message);
                str = Console.ReadLine();
                ok = Int32.TryParse(str, out value);
                if (value < 868 || value > DateTime.Now.Year) ok = false;
            }


            return value;
        }


        //public int Silvia(String limit)
        //{
        //    GetConfig config = new GetConfig();
        //    return config.GetConfigData()[limit];
        //}
    }
}
