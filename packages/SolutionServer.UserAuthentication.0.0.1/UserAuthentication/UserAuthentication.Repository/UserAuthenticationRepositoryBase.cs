using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserAuthentication.Repository
{
    public abstract class UserAuthenticationRepositoryBase
    {
        public abstract bool CheckLogin(string fullName, string email, string password);
        public abstract bool RegisterNewAccount(string fullName, string email, string password);
    }
}
