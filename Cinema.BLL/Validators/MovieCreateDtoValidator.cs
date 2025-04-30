using Cinema.BLL.DTOs.Movies;
using FluentValidation;

namespace Cinema.BLL.Validators;

public sealed class MovieCreateDtoValidator : AbstractValidator<MovieCreateDto>
{
    public MovieCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(600);
        RuleFor(x => x.RatingScore).InclusiveBetween(0f, 10f);
        RuleFor(x => x.Duration).GreaterThan(TimeSpan.Zero);
        RuleFor(x => x.PosterUrl).NotEmpty().MaximumLength(300);
        RuleFor(x => x.TrailerUrl).MaximumLength(300);
    }
}