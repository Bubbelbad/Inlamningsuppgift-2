using Domain.Entities.Core;
using Domain.Entities.Locations;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Transactions
{

    public class Reservation : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }

        //FK
        public Guid CopyId { get; set; }
        public string UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public BookCopy BookCopy { get; set; }

        int IEntity<int>.Id
        {
            get => Id;
            set => Id = value;
        }
    }
}
