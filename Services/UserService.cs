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

                          

        public async Task<bool> Register(RegisterViewModel registerModel)  
        {

            User user = _mapper.Map<User>(registerModel);
            user.Orders = new List<Order>() { new Order() { Status = StatusType.Init, DateCreated = DateTime.UtcNow } };


            IdentityResult identityRes = await _userManager.CreateAsync(user, registerModel.Password);

            if (identityRes.Succeeded)
            {
              
                await _userManager.AddToRoleAsync(user, "customer");
               
               await Login(new LoginViewModel
                {
                    Username = registerModel.Username,
                    Password = registerModel.Password
                });
                
                return true;
            }
            else
              throw new Exception(identityRes.Errors.ToString());
        }

        

        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            
                SignInResult signInResult = await _signInManager.PasswordSignInAsync(
                loginViewModel.Username,
                loginViewModel.Password,
                false,
                false);

            if (signInResult.Succeeded)
                return true;
            else
                return false;
            
        }



        public async Task LogOut()
        {
           await _signInManager.SignOutAsync();
        }


        public UserViewModel GetByUsername(string username)
        {
            User user = _userRepository.GetByUsername(username);

            return _mapper.Map<UserViewModel>(user);
        }


        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll());
        }

        //public bool AreEmailAndPasswordValid(string username, string password)   // za proverka na password ama hashave razlicni vage.
        //{
        //    UserViewModel searchedUser = GetByUsername(username);
        //    if (searchedUser != null)
        //    {
        //        User user = _userRepository.GetById(searchedUser.Id);
        //        var passwordHush = new PasswordHasher<User>();
        //        string enteredPassword = passwordHush.HashPassword(user, password);

        //        if (user.UserName == username && user.PasswordHash == enteredPassword)
        //        {
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
            
        //}
    }
}
