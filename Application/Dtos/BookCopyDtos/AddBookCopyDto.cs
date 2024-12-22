
using Domain.Entities.Core;
using Domain.Entities.Locations;

namespace Application.Dtos.BookCopyDtos
{
    public class AddBookCopyDto
    {
        public Guid BookId { get; set; }
        public int BranchId { get; set; }
        public string? Status { get; set; }

        //// Navigation properties
        //public Book Book { get; set; }
        //public LibraryBranch Branch { get; set; }
    }
}
