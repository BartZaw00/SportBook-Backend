using FluentValidation;
using SportFacilitiesReservationApp.Entities;

namespace SportFacilitiesReservationApp.Models.Validators
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator(SportFacilitiesDbContext dbContext)
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Nazwa użytkownika jest wymagana.")
                .MinimumLength(4).WithMessage("Nazwa użytkownika musi mieć co najmniej 4 znaki.")
                .MaximumLength(30).WithMessage("Nazwa użytkownika nie może przekraczać 30 znaków.")
                .Matches("^[a-zA-Z][a-zA-Z0-9_-]*$").WithMessage("Nazwa użytkownika musi zaczynać się od litery i może zawierać tylko litery, cyfry, podkreślenia i myślniki.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Adres email jest wymagany.")
                .EmailAddress().WithMessage("Błędny format adresu email.")
                .MaximumLength(50).WithMessage("Adres email nie może przekraczać 50 znaków.");

            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("Hasło musi mieć co najmniej 8 znaków.")
                .MaximumLength(30).WithMessage("Nazwa użytkownika nie może przekraczać 30 znaków.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%])[A-Za-z\d!@#$%]{8,30}$")
                .WithMessage("Hasło musi mieć od 8 do 30 znaków i zawierać co najmniej jedną dużą literę, jedną małą literę, jedną cyfrę oraz jeden z następujących znaków specjalnych: ! @ # $ %.");



            RuleFor(x => x.Username)
                .Custom((value, context) =>
                {
                    var userNameInUse = dbContext.Users.Any(u => u.Username == value);
                    if (userNameInUse)
                    {
                        context.AddFailure("Username ", "Ta nazwa użytkownika jest zajęta");
                    }
                });

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var userEmailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (userEmailInUse)
                    {
                        context.AddFailure("Email", "Ten email jest zajęty");
                    }
                });
        }
    }
}
