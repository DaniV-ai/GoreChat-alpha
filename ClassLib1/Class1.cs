using System;
using System.Text;
using System.Security.Cryptography;

namespace ClassLib1
{
    public class User
    {
        string Username { get; set; }
        string EMail { get; set; }
        string Password { get; set; }

        public string EncodeSHA256()
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                mySHA256.
            }
        }
    }
}
