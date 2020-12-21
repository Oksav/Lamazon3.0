using FluentValidation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Validators
{
    public class LoginViewModelValidation : AbstractValidator<LoginViewModel>
    {
        private readonly IUserService _userService;

        public LoginViewModelValidation(IUserService userService)
        {
            _userService = userService;
            CascadeMode = CascadeMode.Stop;

            RuleFor(lm => lm.Username).NotEmpty().WithMessage("You have to enter username");
            RuleFor(lm => lm.Username).MinimumLength(5).WithMessage("Username minimum lenght required is 5 characters.");
            RuleFor(lm => lm.Username).Matches("^[a-zA-Z0-9_.-]*$").WithMessage("Username can only contain numbers, letters, underscore(_), dash(-) and point(.)");
            RuleFor(lm => lm.Username).MaximumLength(25).WithMessage("Max lenght of username is 25");
            RuleFor(lm => lm.Username).Must(username => _userService.GetByUsername(username) != null).WithMessage("The username does not exist"); // porazlicna od registerViewModel ako rabote moze da se smene i vo Register
            

            RuleFor(lm => lm.Password).NotEmpty().MinimumLength(6).WithMessage("Minimum lenght must be 6 characters");
           



        }
    }
}
