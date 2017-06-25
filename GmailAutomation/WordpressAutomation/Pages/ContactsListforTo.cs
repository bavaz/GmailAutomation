using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GmailAutomation.Pages
{
    public class ContactsListforTo
    {
        public static void NewEmail()
        {
            IWebElement ComposeButton = Driver.Instance.FindElement(By.CssSelector("div[class= 'T-I J-J5-Ji T-I-KE L3']"));
            ComposeButton.Click();

            IWebElement ExpandMessageButton = Driver.Instance.FindElement(By.Id(":5t"));
            ExpandMessageButton.Click();

            IWebElement ClickToBox = Driver.Instance.FindElement(By.CssSelector("span[class='gO aQY']"));
            WebDriverWait waitings = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 0));
            IWebElement element = waitings.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span[class='gO aQY']")));
            ClickToBox.Click();

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //IWebElement Cancel = Driver.Instance.FindElement(By.CssSelector(" div [role='button'] [aria-label='Close']"));
            //Cancel.Click();

            //Get iFrame element and switch to it.
            IWebElement selectContactFrame = Driver.Instance.FindElement(By.CssSelector("iframe.KA-JQ"));
            Driver.Instance.SwitchTo().Frame(selectContactFrame);

            //Find cancel button and click it.
            IWebElement cancelButton = Driver.Instance.FindElement(By.XPath("//div[text()='Cancel']"));
            cancelButton.Click();

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Instance.SwitchTo().DefaultContent();
            ComposeEmail.DiscardDraft();
        }
    }
}
