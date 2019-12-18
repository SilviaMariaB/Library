using Library2Framework.DataLayer;
using Library2Framework.DomainLayer;
using Library2Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.ServiceLayer
{
    public class EditionServices
    {
        public List<Author> GetAuthorsForEdition()
        {
            String BookName = Helper.ReadString("Introduce the name of the book:");

            int PublicationYear = Helper.ReadYear("Introduce the year of publishing:");

            String PublishingHouseName = Helper.ReadString("Introduce publishing house name:");

            List<Author> authors = AuthorDAL.GetAuthorsForBook(BookName, PublicationYear, PublishingHouseName);

            if (authors.Count == 0)
            {
                Helper.DisplayError("There are no items with those atributes!");

            }

            return authors;
        }

        public void AddEdition()
        {
            String name = Helper.ReadString("\nInsert name: ");
            String domain = Helper.ReadString("\nInsert domain: ");

            if (DomainDAL.CheckDomain(domain))
            {
                String authorName = Helper.ReadString("\nInsert author Name: ");
                String publishingHouse = Helper.ReadString("\nInsert publishing house: ");
                int pageNr = Helper.ReadInteger("\nInsert page number:");
                String bookType = Helper.ReadString("\nInsert book type: ");
                int publicationYear = Helper.ReadYear("\nInsert publication year: ");
                int initialStock = Helper.ReadInteger("\nInsert initial stock:");

                Edition edition = new Edition(name, domain, publishingHouse, pageNr, bookType, publicationYear, initialStock);
                Author author = new Author(authorName);

                EditionDAL.AddEdition(edition, author);

                Console.WriteLine("\n Operation completed succesfully!");
            }
            else
            {
                Helper.DisplayError("\n Inserted domain doesn't exist!");
            }

               

        }

        public void AddAuthorForEdition()
        {
            String bookName = Helper.ReadString("Introduce the name of the book: ");

            if (EditionDAL.CheckBook(bookName))
            {
                int publicationYear = Helper.ReadYear("Introduce the year of publishing: ");

                String publishingHouseName = Helper.ReadString("Introduce publishing house name: ");

                String authorName = Helper.ReadString("Introduce the name of the author: ");

                Author author = new Author(authorName);
                Edition edition = new Edition()
                {
                    PublicationYear = publicationYear,
                    PublishingHouseName = publishingHouseName,
                    Name = bookName
                };

                EditionDAL.AddAuthorForEdition(author, edition);
                Console.WriteLine("\n Operation completed succesfully!");

            }
            else
            {
                Helper.DisplayError("\n Wrong book name!");
            }

            
        }

        public void BorrowBook()
        {
            String firstName = Helper.ReadString("Introduce first name: ");
            String lastName = Helper.ReadString("Introduce last name: ");
            User user = new User(firstName, lastName);
            if (UserDAL.CheckUser(user))
            {

                String bookName = Helper.ReadString("Introduce the name of the book: ");

                if (EditionDAL.CheckBook(bookName))
                {
                    int publicationYear = Helper.ReadYear("Introduce the year of publishing: ");

                    String publishingHouseName = Helper.ReadString("Introduce publishing house name: ");

                    if (EditionDAL.CheckEdition(bookName, publishingHouseName, publicationYear))
                    {
                        String authorName = Helper.ReadString("Introduce the name of the author: ");

                        Author author = new Author(authorName);

                        if (AuthorDAL.CheckAuthor(author))
                        {
                            Edition edition = new Edition()
                            {
                                PublicationYear = publicationYear,
                                PublishingHouseName = publishingHouseName,
                                Name = bookName
                            };

                            int daysLeft = Helper.ReadInteger("Introduce the number of days of the borrow: ");

                            DateTime endDate = DateTime.Now.AddDays(daysLeft);
                            

                            EditionDAL.BorrowBook(user, edition, author, endDate);
                            Console.WriteLine("\n Operation completed succesfully!");
                        }
                        else
                        {
                            Helper.DisplayError("\n Wrong author!");
                        }
                    }
                    else
                    {
                        Helper.DisplayError("\n Edition not found!");
                    }

                }
                else
                {
                    Helper.DisplayError("\n Book not found!");
                }
            }
            else
            {
                Helper.DisplayError("\n User not found!");
            }

        }
    }
}
