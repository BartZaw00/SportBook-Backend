using FluentValidation;
using SportFacilitiesReservationApp.Entities;

namespace SportFacilitiesReservationApp.Models.Validators
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator(SportFacilitiesDbContext dbContext)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(30);

            RuleFor(x => x.Password).MinimumLength(8);



            RuleFor(x => x.Username)
                .Custom((value, context) =>
                {
                    var userNameInUse = dbContext.Users.Any(u => u.Username == value);
                    if (userNameInUse)
                    {
                        context.AddFailure("UserName ", "That user name is taken");
                    }
                });

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var userEmailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (userEmailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
