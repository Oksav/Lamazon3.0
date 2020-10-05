using FluentValidation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Validators
{
    class LoginViewModelValidation : AbstractValidator<LoginViewModel>
    {
        private readonly IUserService _userService;

        public LoginViewModelValidation(IUserService userService)
        {
            _userService = userService;


            RuleFor(rm => rm.Username).NotEmpty().WithMessage("You have to enter username");
            RuleFor(rm => rm.Username).Matches("^[a-zA-Z0-9_.-]*$").WithMessage("Username can only contain numbers, letters, underscore(_), dash(-) and point(.)");
            RuleFor(rm => rm.Username).MaximumLength(25).WithMessage("Max lenght of username is 25");
            RuleFor(rm => rm.Username).Must(username => _userService.GetByUsername(username) == null).WithMessage("The username does not exist"); // porazlicna od registerViewModel ako rabote moze da se smene i vo Register

            RuleFor(rm => rm.Password).NotEmpty().MinimumLength(8).WithMessage("Minimum lenght must be 8 characters");
            // dali trebe validacija za passwordot ako go promasis ?

        }
    }
}
