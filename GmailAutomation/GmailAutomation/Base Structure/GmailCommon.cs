using Microsoft.VisualStudio.TestTools.UnitTesting;
using GmailAutomation.Support;
using GmailAutomation.Pages;

namespace GmailAutomation
{
    public class GmailCommon
    {
        //REMEMBER TO CLOSE VS AND THEN REOPEN BEFORE YOU TEST WITH ENV VARS.
        //public string GMAIL_USERNAME = "sorpuanonymous";
        //public string GMAIL_PWD = "ontario123";
        public string GMAIL_USERNAME = _config.WA_GMAIL_USERNAME;
        public string GMAIL_PWD = _config.WA_GMAIL_PWD;
        private static Config _config = Setup.CreateConfiguration<Config>(@"Support\Config.json");

        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            ComposeEmail.Initialize();
            Driver.Instance.Manage().Window.Maximize();
        }
       
        [TestCleanup]
        public void Close()
        {
            Logout();
            Driver.Close();
        }

        public void Logout()
        {
            LogoutPage.Logout();
        }
}


}
