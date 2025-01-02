using FluentValidation;

namespace Application.Queries.ReservationQueries.GetReservationById
{
    public class GetReservationByIdQueryValidator : AbstractValidator<GetReservationByIdQuery>
    {
        public GetReservationByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
