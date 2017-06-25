//Test code

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GmailAutomation;
using GmailAutomation.Pages;
using GmailAutomation.Pages;

namespace GmailTests
{
    [TestClass]
    public class LoginTests : GmailCommon
    {

        /// <summary>
        /// This test does a login and logout.
        /// </summary>
        [TestMethod][Priority(1)]
        public void UserCanLogin()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(GMAIL_USERNAME).WithPassword(GMAIL_PWD).Login();
            Assert.IsTrue(DashboardPage.IsAt,"Failed to login.");
         }

        /// <summary>
        /// This test does a login, opens up the compose e-mail,
        /// expands the message box, clicks the 'To' button for 
        /// the contact list closes the contact list (doesn't select a contact),
        /// discards the draft and does a logout.
        /// </summary>
        [TestMethod][Priority(2)]
        public void AccessContactsListforTo()
        {
            UserCanLogin();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ContactsListforTo.NewEmail();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// This test does a login, opens up the compose-email,
        /// expands the message box, enters a to, subject and 
        /// message body, discards the draft and does a logout.
        /// </summary>
        [TestMethod][Priority(3)]
        public void CreateEmail()
        {
            UserCanLogin();
            ComposeEmail.CreateEmail();
        }

        /// <summary>
        /// This test does a login, opens up the compose-email,
        /// expands the message box, enters a to, subject and 
        /// message body, sends the email and does a logout.
        /// </summary>
        [TestMethod]
        public void SendsEmail()
        {
            UserCanLogin();
            SendEmail.CreateEmail();

        }
    }
}
