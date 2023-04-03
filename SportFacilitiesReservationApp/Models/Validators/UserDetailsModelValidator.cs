using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SportFacilitiesReservationApp.Entities;

namespace SportFacilitiesReservationApp.Models.Validators
{
    public class UserDetailsModelValidator : AbstractValidator<UserDetailsModel>
    {
        public class UserContext
        {
            public int CurrentUserId { get; set; }
            public string CurrentUsername { get; set; }
            public string CurrentEmail { get; set; }
        }
        public UserDetailsModelValidator(SportFacilitiesDbContext dbContext, UserContext userContext)
        {
            RuleFor(x => x.Username)
     .NotEmpty().WithMessage("Nazwa użytkownika jest wymagana.")
     .MinimumLength(4).WithMessage("Nazwa użytkownika musi mieć co najmniej 4 znaki.")
     .MaximumLength(30).WithMessage("Nazwa użytkownika nie może przekraczać 30 znaków.")
     .Matches("^[a-zA-Z][a-zA-Z0-9_-]*$").WithMessage("Nazwa użytkownika musi zaczynać się od litery i może zawierać tylko litery, cyfry, podkreślenia i myślniki.")
            .Custom((value, context) =>
            {
         var currentUser = dbContext.Users.FirstOrDefault(u => u.UserId == userContext.CurrentUserId);
         if (currentUser != null && currentUser.Username == value)
                {
                    return;
                }

         var nickInUse = dbContext.Users.Any(u => u.Username == value);
         if (nickInUse)
         {
             context.AddFailure("Username", "Ta nazwa użytkownika jest zajęta");
         }
     });

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Adres email jest wymagany.")
                .EmailAddress().WithMessage("Błędny format adresu email.")
                .MaximumLength(50).WithMessage("Adres email nie może przekraczać 50 znaków.")
            .Custom((value, context) =>
            {
                    var currentUser = dbContext.Users.FirstOrDefault(u => u.UserId == userContext.CurrentUserId);
                    if (currentUser != null && currentUser.Email == value)
                {
                    return;
                }

                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", $"Ten email jest zajęty. Aktualny email to {currentUser.Email}");
                    }
                });

            }
    }
}
