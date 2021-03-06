﻿using DomainModels.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } 
    };
}

