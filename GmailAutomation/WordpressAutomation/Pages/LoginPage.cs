using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GmailAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&service=mail&sacu=1&rip=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            
            //var driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("http://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&service=mail&sacu=1&rip=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);

        }
    }

    public class LoginCommand
    {
        private readonly string userName;
        private string password;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this; 
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Id("identifierId"));
            loginInput.SendKeys(userName);

            var loginButton = Driver.Instance.FindElement(By.ClassName("CwaK9"));
            loginButton.Click();

            WebDriverWait wait = new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));

            var passwordInput = Driver.Instance.FindElement(By.Name("password"));
            passwordInput.SendKeys(password);

            //Have to redeclare the same button else get StaleException (as page refreshed)
            var Next = Driver.Instance.FindElement(By.ClassName("CwaK9"));
            Next.Click();
        }
    }
}
