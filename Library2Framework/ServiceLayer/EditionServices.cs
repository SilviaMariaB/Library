namespace Library2Framework.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Library2Framework.DataMapper;
    using Library2Framework.DomainModel;
    using Library2Framework.Utils;

    public class EditionServices
    {
        public List<Author> GetAuthorsForEdition() 
        {
            string bookName = Helper.ReadString("Introduce the name of the book:");

            List<Author> authors = null;

            if (BookDAL.CheckBook(bookName))
            {
                int PublicationYear = Helper.ReadYear("Introduce the year of publishing:");

                string PublishingHouseName = Helper.ReadString("Introduce publishing house name:");

                if(EditionDAL.CheckEdition(bookName, PublishingHouseName, PublicationYear))
                {
                    authors = AuthorDAL.GetAuthorsForBook(bookName, PublicationYear, PublishingHouseName);
                }
                else
                {
                    Helper.DisplayError("\n Edition doesn't exist!");
                }
            }
            else
            {
                Helper.DisplayError("\n Wrong book name!");

            }
           
            return authors;
        }

        public void AddEdition()
        {
            string bookName = Helper.ReadString("\nInsert book name: ");

            string domain;
            

            if (BookDAL.CheckBook(bookName))
            {
                domain = "";
                ContinueAddEdition(bookName, domain);
            }
            else
            {
                domain = Helper.ReadString("\nInsert domain name: ");
                if (DomainDAL.CheckDomain(domain))
                {
                    ContinueAddEdition(bookName, domain);
                }
                else
                {
                    Helper.DisplayError("\n Inserted domain doesn't exist!");
                }
            }
        }

        private void ContinueAddEdition(string bookName, string domain)
        {
            string authorName = Helper.ReadString("\nInsert author name: ");
            string publishingHouse = Helper.ReadString("\nInsert publishing house: ");
            int pageNr = Helper.ReadInteger("\nInsert page number:");
            string bookType = Helper.ReadString("\nInsert book type: ");
            int publicationYear = Helper.ReadYear("\nInsert publication year: ");
            int initialStock = Helper.ReadInteger("\nInsert initial stock:");

            Edition edition = new Edition(bookName, publishingHouse, pageNr, bookType, publicationYear, initialStock);

            if (!EditionDAL.CheckEdition(bookName, publishingHouse, publicationYear))
            {
                Author author = new Author(authorName);

                EditionDAL.AddEdition(edition, author, domain);

                Console.WriteLine("\n Operation completed succesfully!");
            }
            else
            {
                Helper.DisplayError("\n Edition already exist!");
            }
        }

        public void AddAuthorForEdition()
        {
            string bookName = Helper.ReadString("Introduce the name of the book: ");

            if (BookDAL.CheckBook(bookName))
            {
                int publicationYear = Helper.ReadYear("Introduce the year of publishing: ");

                string publishingHouseName = Helper.ReadString("Introduce publishing house name: ");

                if(EditionDAL.CheckEdition(bookName,publishingHouseName,publicationYear))
                {
                    string authorName = Helper.ReadString("Introduce the name of the author: ");

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
                    Helper.DisplayError("\n Edition doesn't exist!");
                }


            }
            else
            {
                Helper.DisplayError("\n Wrong book name!");
            }            
        }

        public void BorrowEdition()
        {
            string firstName = Helper.ReadString("Introduce first name: ");
            string lastName = Helper.ReadString("Introduce last name: ");
            User user = new User(firstName, lastName);
            if (UserDAL.CheckUser(user))
            {

                string bookName = Helper.ReadString("Introduce the name of the book: ");

                if (BookDAL.CheckBook(bookName))
                {
                    int publicationYear = Helper.ReadYear("Introduce the year of publishing: ");

                    string publishingHouseName = Helper.ReadString("Introduce publishing house name: ");

                    if (EditionDAL.CheckEdition(bookName, publishingHouseName, publicationYear))
                    {
                        string authorName = Helper.ReadString("Introduce the name of the author: ");

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
                            

                            ///////////////////////////////////////////verificari constante BLABLABLA

                            EditionDAL.BorrowEdition(user, edition, author, endDate);
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
