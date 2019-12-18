using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2Framework.DomainLayer
{
    public class Borrow
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public int EditionId { get; set; }

        DateTime startDate { get; set; }

        DateTime endDate { get; set; }

        public Borrow(int ID, int UserId, int EditionId)
        {
            this.ID = ID;
            this.UserId = UserId;
            this.EditionId = EditionId;

        }

        public override string ToString()
        {
            return "( ID: " + this.ID + " user id: " + this.UserId + " edition id: " + this.EditionId + ")";
        }
    }
}
