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
        Task<bool> Register(RegisterViewModel registerModel);
        Task<bool> Login(LoginViewModel loginViewModel);
        Task LogOut();
        UserViewModel GetByUsername(string username);
        IEnumerable<UserViewModel> GetAllUsers();
        //bool AreEmailAndPasswordValid(string username, string password);  izbacen od upotreba, mozebi ponanaki


    }
}
