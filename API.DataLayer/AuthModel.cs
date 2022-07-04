using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataLayer
{
    public class AuthModel
    {
        public string IdToken { get; set; }
        public int Expiresin { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }

    public class ConfirmUser
    {
        public string Username { get; set; }
        public string code { get; set; }
    }
    public class ResendCode
    {
        public string Username { get; set; }

    }
    public class ConfirmForgotPassword
    {
        public string username { get; set; }
        public string newpassword { get; set; }
        public string confirmationcode { get; set; }

    }
}
