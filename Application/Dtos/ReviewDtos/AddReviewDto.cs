
namespace Application.Dtos.ReviewDtos
{
    public class AddReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid BookId { get; set; }
    }
}
