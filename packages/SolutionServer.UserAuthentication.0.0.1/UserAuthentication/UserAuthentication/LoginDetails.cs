using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserAuthentication
{
    public class LoginDetails
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public void Encode()
        {
            FullName = Convert.ToBase64String(Encoding.UTF8.GetBytes(FullName));
            Email = Convert.ToBase64String(Encoding.UTF8.GetBytes(Email));
            Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
        }
        public void Decode()
        {
            Email = Encoding.UTF8.GetString(Convert.FromBase64String(Email));
            FullName = Encoding.UTF8.GetString(Convert.FromBase64String(FullName));
            Password = Encoding.UTF8.GetString(Convert.FromBase64String(Password));
        }
    }
}
