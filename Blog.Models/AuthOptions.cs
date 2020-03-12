using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Models
{
    public class AuthOptions
    {
        public const string issuer = "RohoProd";
        public const string audience = "Users";
        const string key = "deadinsideashiheteo!";
        public const int lifetime = 5;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }

    }
}
