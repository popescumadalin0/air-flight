using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace AutomationTesting.BaseClass
{
    public class Test
    {

        protected IWebDriver Driver;
        public IWebElement WaitFindElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        //Implicit Wait 
        public void Pause(IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(seconds);
        }


        [OneTimeSetUp]
        public void Setup()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };

            chromeOptions.AddArguments("--incognito");


            chromeOptions.AddArgument("--start-maximized");


            chromeOptions.AddUserProfilePreference("download.default_directory", path);

            chromeOptions.AddArguments("--no-sandbox");
            Driver = new ChromeDriver(path + @"\drivers\", chromeOptions);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://localhost:7081/");

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }

    }
}
