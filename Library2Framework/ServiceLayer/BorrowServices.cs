using Library2Framework.DataMapper;
using Library2Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.ServiceLayer
{
    public class BorrowServices
    {
        public List<Borrow> GetBorrowsForUser()
        {
            string email = Helper.ReadString("Introduce the email of the user:");

            while (!UserDAL.CheckUser(email))
            {
                Helper.DisplayError("\n Wrong email!");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                email = Helper.ReadString("Reintroduce the email of the user:");
            }

            List<Borrow> borrows = null;
            borrows = BorrowDAL.GetBorrowsForUser(email);
            return borrows;
        }
    }
}
