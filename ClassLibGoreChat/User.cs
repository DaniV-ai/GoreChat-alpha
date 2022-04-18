using System;
using System.Security.Cryptography;

namespace ClassLibGoreChat
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string GetSHA256FromPass()
        {
            byte[] hash;

            if (Password != "")
            {
                SHA256 mySHA256 = SHA256.Create();
                hash = mySHA256.ComputeHash(Password);

                return hash.ToString();
            }
        }
    }
}
