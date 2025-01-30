
namespace Application.Dtos.ReviewDtos
{
    public class GetBookReviewsDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public string UserName { get; set; }
    }
}