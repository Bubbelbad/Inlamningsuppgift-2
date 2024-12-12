
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Locations
{
    public class LibraryBranch
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string? ContactInfo { get; set; }

        // Navigation property
        public ICollection<BookCopy> BookCopies { get; set; }
    }

}
