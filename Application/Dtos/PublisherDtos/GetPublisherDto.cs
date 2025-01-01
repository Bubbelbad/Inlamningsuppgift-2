
namespace Application.Dtos.PublisherDtos
{
    public class GetPublisherDto
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? ContactInfo { get; set; }
    }
}
