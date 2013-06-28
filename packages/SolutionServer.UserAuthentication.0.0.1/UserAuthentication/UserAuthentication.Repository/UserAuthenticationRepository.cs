using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Configuration;

namespace UserAuthentication.Repository
{
    public class UserAuthenticationRepository : UserAuthenticationRepositoryBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override bool CheckLogin(string fullName, string email, string password)
        {
            log.Debug(String.Format("Trying to log in user: {0}", fullName));
            foreach (LoginDetails ld in GetJsonLoginDataFromFile())
            {
                ld.Decode();
                UserAuthenticationBase accDom = new UserAuthenticationBase
                {
                    UserEmail = email,
                    UserFullName = fullName,
                    UserPassword = password,
                    LoginDetails = ld
                };
                if (accDom.isEmailOrUsernameAndPasswordValid)
                    return true;
            }
            return false;
        }
        private List<LoginDetails> GetJsonLoginDataFromFile()
        {
            string loginDataFile = "[" + System.IO.File.ReadAllText(ConfigurationManager.AppSettings["FlatFileDatabaseLocation"]) + "]";
            var loginData = JsonConvert.DeserializeObject<List<LoginDetails>>(loginDataFile);
            return loginData;
        }
        
        public override bool RegisterNewAccount(string fullName, string email, string password)
        {
            log.Debug(String.Format("Registering user: {0}", fullName));
            LoginDetails loginDetails = new LoginDetails
            {
                FullName = fullName,
                Email = email,
                Password = password
            };
            loginDetails.Encode();
            string json = JsonConvert.SerializeObject(loginDetails) + ",";
            System.IO.File.AppendAllText(ConfigurationManager.AppSettings["FlatFileDatabaseLocation"], json);
            return true;
        }
    }
}
