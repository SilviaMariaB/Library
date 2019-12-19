using Library2Framework.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DomainLayer
{
    public class Edition
    {
        public string Name { get; set; }

        public string PublishingHouseName { get; set; }

        public int PageNr { get; set; }

        public int PublicationYear { get; set; }

        public string Domain { get; set; }

        public string BookType { get; set; }

        public int InitialStock { get; set; }

        public int CurrentStock { get; set; }

        public int BorrowedBooks { get; set; }

        public int ReadingRoomBooks { get; set; }

        public Edition()
        {

        }

        public Edition(string Name, string Domain, string PublishingHouseName, int PageNr, string BookType,
            int PublicationYear, int InitialStock, int BorrowedBooks=0, int ReadingRoomBooks=0)
        {
            this.Name = Name;
            this.PublishingHouseName = PublishingHouseName;
            this.PageNr = PageNr;
            this.PublicationYear = PublicationYear;
            this.Domain = Domain;
            this.BookType = BookType;
            this.InitialStock = InitialStock;
            this.CurrentStock = InitialStock;
            this.BorrowedBooks = BorrowedBooks;
            this.ReadingRoomBooks = ReadingRoomBooks;
        }

        public override string ToString()
        {
            return "\n Book name: " + Name +
                "\n Publishing house name: " + Helper.FirstCharToUpper(this.PublishingHouseName) +
                "\n Number of pages: " + this.PageNr +
                "\n Publication year: " + this.PublicationYear +
                "\n Domain: " + Helper.FirstCharToUpper(Domain) +
                "\n Book type: " + Helper.FirstCharToUpper(BookType) +
                "\n Initial stock: " + this.InitialStock +
                "\n Current stock: " + this.CurrentStock +
                "\n Borrowed books: " + this.BorrowedBooks +
                "\n Readingroom books: " + this.ReadingRoomBooks ;
        }
    }
}
