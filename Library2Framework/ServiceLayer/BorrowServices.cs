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

            List<Borrow> borrows = null;

            if (UserDAL.CheckUser(email))
            {
                borrows = BorrowDAL.GetBorrowsForUser(email);
            }
            else
            {
                Helper.DisplayError("\n Wrong email!");
            }
            return borrows;
        }
    }
}
