
namespace Application.Dtos.ReviewDtos
{
    public class UpdateReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
