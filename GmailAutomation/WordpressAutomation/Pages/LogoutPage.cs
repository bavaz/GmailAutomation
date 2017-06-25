using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAutomation
{
    public class LogoutPage
    {
        public static void Logout()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span[class='gb_8a gbii']")));

            var logoutButton = Driver.Instance.FindElement(By.CssSelector("span[class='gb_8a gbii']"));
            logoutButton.Click();

            WebDriverWait waiting = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 10));
            waiting.Until(ExpectedConditions.ElementIsVisible(By.Id("gb_71")));

            var signoutButton = Driver.Instance.FindElement(By.Id("gb_71"));
            signoutButton.Click();

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }
    }
}
