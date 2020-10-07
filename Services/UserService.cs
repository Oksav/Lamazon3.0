using AutoMapper;
using DataAccess.Interfaces;
using DomainModels.Enums;
using DomainModels.Models;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using Services.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.ViewModels;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository<User> userRepo,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper
            )
        {
            _userRepository = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

                          

        public bool Register(RegisterViewModel registerModel)  // when making the method async after the identity result continues to redirect without doing the checking in the if method,
                                                               // creating the user, login the user or assining role. and does not throw any kind of exeption
        {

            User user = _mapper.Map<User>(registerModel);
            //user.Orders = new List<Order>() { new Order() { Status = StatusType.Init } };


            IdentityResult identityRes = _userManager.CreateAsync(user, registerModel.Password).Result;

            if (identityRes.Succeeded)
            {
              
                 _userManager.AddToRoleAsync(user, "customer");                

                Login(new LoginViewModel
                {
                    Username = registerModel.Username,
                    Password = registerModel.Password
                });
                return true;
            }
            else
              throw new Exception(identityRes.Errors.ToString());
        }

        

        public void Login(LoginViewModel loginViewModel)
        {
            
                SignInResult signInResult = _signInManager.PasswordSignInAsync(
                loginViewModel.Username,
                loginViewModel.Password,
                false,
                false).Result; // returns true but doesnt sign in the user, 

                if (!signInResult.Succeeded)
                    new IdentityError();  // Ne go dave koga ke promasis user i password
            
        }



        public async Task LogOut()
        {
           await _signInManager.SignOutAsync();
        }


        public UserViewModel GetByUsername(string username)
        {
            User user = _userRepository.GetByUsername(username);
            if (user == null) throw new Exception("User does not exist");

            return _mapper.Map<UserViewModel>(user);
        }


        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll());
        }
    }
}
