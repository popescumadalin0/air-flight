using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTesting
{
    public class RegisterTest:Test
    {

        [Test]
        public async Task RegisterSucces()
        {

            Driver.Navigate().GoToUrl("https://localhost:7081/register");
            var username = Driver.FindElement(By.Id("register_username"));
            username.Clear();
            username.SendKeys("ana");
            var password = Driver.FindElement(By.Id("password_register"));
            password.Clear();
            password.SendKeys("Ana1234!");
            var loginButton = Driver.FindElement(By.Id("register_button"));
            loginButton.Click();
            await Task.Delay(5000);
            Assert.AreNotEqual("https://localhost:7081/register", Driver.Url);
        }
    }
}