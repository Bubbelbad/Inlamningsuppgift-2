
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Locations
{
    public class LibraryBranch : IEntity<int>
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string? ContactInfo { get; set; }

        // Navigation property
        public ICollection<BookCopy> BookCopies { get; set; }

        int IEntity<int>.Id
        {
            get => BranchId;
            set => BranchId = value;
        }
    }

}
