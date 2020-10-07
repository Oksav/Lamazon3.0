using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        bool Register(RegisterViewModel registerModel);
        void Login(LoginViewModel loginViewModel);
        Task LogOut();
        UserViewModel GetByUsername(string username);
        IEnumerable<UserViewModel> GetAllUsers();


    }
}
