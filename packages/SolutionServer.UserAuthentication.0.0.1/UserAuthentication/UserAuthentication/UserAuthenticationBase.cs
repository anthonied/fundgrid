using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserAuthentication
{
    public class UserAuthenticationBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public LoginDetails LoginDetails { get; set; }
        public bool isEmailOrUsernameAndPasswordValid
        {
            get
            {
                if (isEmailAndPasswordValid || isUsernameAndPasswordValid)
                    return true;
                else
                    return false;
            }
        }
        public bool isEmailAndPasswordValid
        {
            get
            {
                if (UserEmail == LoginDetails.Email && UserPassword == LoginDetails.Password)
                {
                    log.Debug("Login success: EMAIL AND PASSWORD CORRECT");
                    return true;
                }
                else
                    return false;
            }
        }
        public bool isUsernameAndPasswordValid
        {
            get
            {
                if (UserFullName == LoginDetails.FullName && UserPassword == LoginDetails.Password)
                {
                    log.Debug("Login success: USERNAME AND PASSWORD CORRECT");
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
