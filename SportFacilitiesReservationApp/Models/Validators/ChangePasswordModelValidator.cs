using FluentValidation;
using SportFacilitiesReservationApp.Entities;

namespace SportFacilitiesReservationApp.Models.Validators
{
    public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordModelValidator()
        {
            RuleFor(x => x.Password)
                    .MinimumLength(8).WithMessage("Hasło musi mieć co najmniej 8 znaków.")
                    .MaximumLength(30).WithMessage("Nazwa użytkownika nie może przekraczać 30 znaków.")
                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%])[A-Za-z\d!@#$%]{8,30}$")
                    .WithMessage("Hasło musi mieć od 8 do 30 znaków i zawierać co najmniej jedną dużą literę, jedną małą literę, jedną cyfrę oraz jeden z następujących znaków specjalnych: ! @ # $ %.");

        }
    }
}
