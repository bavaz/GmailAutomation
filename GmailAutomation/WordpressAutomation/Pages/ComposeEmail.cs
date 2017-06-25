using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GmailAutomation.Pages
{
    public class ComposeEmail
    {
        public static object title;
        public static object body;

        public static void CreateEmail()
        {
            WebDriverWait waits = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 10));
            waits.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class= 'T-I J-J5-Ji T-I-KE L3']")));

            IWebElement ComposeButton = Driver.Instance.FindElement(By.CssSelector("div[class= 'T-I J-J5-Ji T-I-KE L3']"));
            ComposeButton.Click();

            IWebElement ExpandMessageButton = Driver.Instance.FindElement(By.Id(":5t"));
            ExpandMessageButton.Click();

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            FillInMessage();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            DiscardDraft();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void DiscardDraft()
        {
            WebDriverWait waitings = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 0));
            IWebElement DiscardButton = waitings.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div [class= 'og T-I-J3']")));
            //IWebElement DiscardButton = Driver.Instance.FindElement(By.CssSelector("div [class= 'og T-I-J3']"));
            DiscardButton.Click();
        }

        public static void FillInMessage()
        {
            WebDriverWait waits = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 10));
            waits.Until(ExpectedConditions.ElementIsVisible(By.Name("to")));
            IWebElement ToBox = Driver.Instance.FindElement(By.Name("to"));
            ToBox.SendKeys("no-reply@accounts.google.com");

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement SubjectBox = Driver.Instance.FindElement(By.Name("subjectbox"));
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SubjectBox.SendKeys("Test Draft");

            IWebElement MsgBody = Driver.Instance.FindElement(By.CssSelector("div [class='Am Al editable LW-avf']"));
            MsgBody.SendKeys("Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eligendi non quis exercitationem culpa nesciunt nihil aut nostrum explicabo reprehenderit optio amet ab temporibus asperiores quasi cupiditate. Voluptatum ducimus voluptates voluptas?");


        }
        
        public static void Initialize()
        {
            title = null;
            body = null;
        }
    }
}
