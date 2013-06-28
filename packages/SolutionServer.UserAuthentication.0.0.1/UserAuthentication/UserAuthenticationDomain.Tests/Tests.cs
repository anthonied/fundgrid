using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserAuthenticationDomain;
using NUnit.Framework;
using UserAuthentication;

namespace UserAuthenticationDomain.Tests
{
    [TestFixture]
    class Tests
    {
        private LoginDetails _validLoginDetails;
        [SetUp]
        public void Given()
        {
            _validLoginDetails = new LoginDetails
            {
                Email = "email",
                FullName = "username",
                Password = "password!:"
            };
        }
        [Test]
        public void LoginFailsNoCorrectDetail()
        {
            var auth = new UserAuthenticationBase()
            {
                LoginDetails = _validLoginDetails,
                UserEmail = "Wrong_Email",
                UserFullName = "Wrong_Username",
                UserPassword = "password!:"
            };
            Assert.That(auth.isEmailOrUsernameAndPasswordValid, Is.False);
        }
        [Test]
        public void LoginSucceedsCorrectEmail()
        {
            var auth = new UserAuthenticationBase()
            {
                LoginDetails = _validLoginDetails,
                UserEmail = "email",
                UserFullName = "Wrong_Username",
                UserPassword = "password!:"
            };
            Assert.That(auth.isEmailOrUsernameAndPasswordValid, Is.True);
        }
        [Test]
        public void LoginSucceedsCorrectUsername()
        {
            var auth = new UserAuthenticationBase()
            {
                LoginDetails = _validLoginDetails,
                UserEmail = "Wrong_Email",
                UserFullName = "username",
                UserPassword = "password!:"
            };
            Assert.That(auth.isEmailOrUsernameAndPasswordValid, Is.True);
        }
    }
}
