using GmailAutomation;
using GmailAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GmailAutomation.Pages
{
    public class SendEmail
    {
        public static void CreateEmail()
        {
            WebDriverWait waits = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 10));
            waits.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class= 'T-I J-J5-Ji T-I-KE L3']")));

            IWebElement ComposeButton = Driver.Instance.FindElement(By.CssSelector("div[class= 'T-I J-J5-Ji T-I-KE L3']"));
            ComposeButton.Click();

            IWebElement ExpandMessageButton = Driver.Instance.FindElement(By.Id(":5t"));
            ExpandMessageButton.Click();

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ComposeEmail.FillInMessage();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SendTheEmail();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private static void SendTheEmail()
        {
            IWebElement SendButton = Driver.Instance.FindElement(By.Id(":8e"));
            SendButton.Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

    }
}
