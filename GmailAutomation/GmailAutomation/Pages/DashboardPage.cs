using OpenQA.Selenium;

namespace GmailAutomation
{
    /// <summary>
    /// Only checks if we have been signed in or not.
    /// </summary>
    public class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                //this is weak as this is present in all subsequent pages
                //But it checks if we are signed in or not.
                var appheading = Driver.Instance.FindElement(By.Id(":i"));
                return (appheading.Text == "Gmail");

            }
        }
    }
}
