using FluentValidation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModels.ViewModels;

namespace Services.Validators
{
    public class RegisterViewModelValidation : AbstractValidator<RegisterViewModel>
    {
        private readonly IUserService _userService;
        public RegisterViewModelValidation(IUserService userService)
        {
            _userService = userService;



            RuleFor(rm => rm.Username).NotEmpty().WithMessage("You have to enter username");
            RuleFor(rm => rm.Username).Matches("^[a-zA-Z0-9_.-]*$").WithMessage("Username can only contain numbers, letters, underscore(_), dash(-) and point(.)");
            RuleFor(rm => rm.Username).MinimumLength(5).WithMessage("Minimum lenght required is 5");
            RuleFor(rm => rm.Username).MaximumLength(25).WithMessage("Max lenght of username is 25");
            RuleFor(rm => rm.Username).Must(username => CheckIfUserExists(username) == false).WithMessage("The username already exists");
            
           

            RuleFor(rm => rm.Email).NotEmpty().EmailAddress().WithMessage("You must enter correct email address. Example: example@lamazon.com.");
            RuleFor(rm => rm.Email).Must(email => CheckIfEmailIsUnique(email) == false).WithMessage("Email is already in use");
            

            RuleFor(rm => rm.FullName).NotEmpty().WithMessage("You must enter your full name");  
            RuleFor(rm => rm.Username).Matches("[A-Za-z]").WithMessage("Your fullname can only contain letters.");
            RuleFor(rm => rm.Username).MaximumLength(35).WithMessage("Max lenght of full name is 35.");
            

            RuleFor(rm => rm.Password).NotEmpty().MinimumLength(8).WithMessage("Minimum lenght must be 8 characters");
            RuleFor(rm => rm.Password).Equal(rm => rm.ConfirmPassword).WithMessage("Passwords do not match!");
            RuleFor(rm => rm.Password).Matches("^(?=.*[a - z])(?=.*[A - Z])(?=.*)(?=.*[#$^+=!*()@%&]).{8,20}$").WithMessage("Your password must contain minimum 8 and max 20 characters, with at least " +
                "one lower case, one upper case, one number and one special sign([#$^+=!*)");
        }

        private bool CheckIfUserExists(string username)
        {
            var user = _userService.GetByUsername(username);
            if (user != null)
                return true;
            else
                return false;
        }

        private bool CheckIfEmailIsUnique(string email) // gi povlecave site mailave od databaazta, moze da se dodade nova funkcija vo servisot i vo repositorto da vrake po mail samo
        {
            var emailExist = _userService.GetAllUsers().Select(e => e.Email).Where(e => e == email).SingleOrDefault();

            if (emailExist != null)
                return true;
                    else return false;
        }

       
    }
}
