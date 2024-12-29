using Domain.Entities.Core;
using Domain.Entities.Locations;

namespace Domain.Entities.Transactions
{
    public class Borrowing
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }

        // FK
        public string UserId { get; set; }
        public Guid CopyId { get; set; }


        // Navigation properties
        public User User { get; set; }
        public BookCopy BookCopy { get; set; }
    }
}
