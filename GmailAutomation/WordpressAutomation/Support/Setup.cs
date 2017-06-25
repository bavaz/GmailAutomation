using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using Newtonsoft.Json;

namespace GmailAutomation.Support
{
    /// <summary>
    /// Provides helpful methods for seting up tests
    /// </summary>
    public class Setup
    {
        /// <summary>
        /// Creates a driver to use for testing
        /// </summary>
        /// <param name="driverType">The type of driver to return</param>
        /// <param name="timeout">The implicit timeout the driver should have</param>
        /// <returns>
        /// A IWebDriver of the desired type with the desired timeout
        /// </returns>
        //public static IWebDriver CreateDriver(DriveType driverType = DriveType.Firefox, double timeout = -1)
        //{
        //    IWebDriver driver;
        //    switch (driverType)
        //    {
        //        case DriveType.Firefox:
        //            driver = new FirefoxDriver();
        //            break;
        //    }
        //}

        /// <summary>
        /// Creates a configuration from the file located at the given <paramref name="pathToConfigurationFile"/>
        /// </summary>
        /// <param name="pathToConfigurationFile">The path to the configuration file</param>
        /// <returns>
        /// A configuration object created from the given file
        /// </returns>
        public static T CreateConfiguration<T>(string pathToConfigurationFile)
        {
            T config;
            var path = Path.Combine(pathToConfigurationFile);

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                config = JsonConvert.DeserializeObject<T>(json);
            }

            return config;
        }
    }
}
