using FluentValidation;

namespace Application.Queries.PublisherQueries.GetPublisherById
{
    public class GetPublisherByIdQueryValidator : AbstractValidator<GetPublisherByIdQuery>
    {
        public GetPublisherByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).NotNull().WithMessage("Id must be greater than 0");
        }
    }
}
