
namespace Application.Dtos.LibraryBranchDtos
{
    public class GetLibraryBranchDto
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string? ContactInfo { get; set; }
    }
}
