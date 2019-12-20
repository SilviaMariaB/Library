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
    using static Library2Framework.DataMapper.EditionDAL;

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
            string email = Helper.ReadString("Introduce user's email: ");
            if (UserDAL.CheckUser(email))
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
                            if (ValidBorrow(email, bookName, publishingHouseName, publicationYear))
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

                                EditionDAL.BorrowEdition(email, edition, author, endDate);
                                Console.WriteLine("\n Operation completed succesfully!");
                            } 
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


        private bool ValidBorrow(string email, string bookName, string publishingHouse, int publicationYear)
        {
            Inventory inventory = EditionDAL.GetEditionInventory(bookName, publishingHouse, publicationYear);
            if(inventory.currentStock<=0.1*inventory.initialStock)
            {
                Helper.DisplayError("\n There are no books available for borrow.");
                return false;
            }

            int NMC = Helper.GetConfigData()["NMC"];
            int PER = Helper.GetConfigData()["PER"];
            List<Borrow> borrows = BorrowDAL.GetBorrowsForUser(email);

            borrows.RemoveAll(d => d.EndDate < DateTime.Today);

            if(borrows.Count>=NMC)
            {
                Borrow firstBorrow = borrows[borrows.Count - NMC];
                Borrow lastBorrow = borrows[borrows.Count - 1];



                if(DateTime.Today >= lastBorrow.StartDate && DateTime.Today < firstBorrow.StartDate.AddDays(PER*7))
                {
                    Helper.DisplayError("\n You can't borrow another book. Come again on " + firstBorrow.StartDate.AddDays(PER * 7));
                    return false;
                }
            }
            return true;
        }
    }
}
