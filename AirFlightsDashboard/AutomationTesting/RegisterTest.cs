using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutomationTesting.BaseClass;
using OpenQA.Selenium;

namespace AutomationTesting
{
   public class RegisterTest:Test
    {
        [Test]
        public async Task RegisterSuccesTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7081/register");

            //FirstName
            var firstname = Driver.FindElement(By.Id("firstname_register"));
            firstname.Clear();
            firstname.SendKeys("Alina");

            //LastName
            var lastname = Driver.FindElement(By.Id("lastname_register"));
            lastname.Clear();
            lastname.SendKeys("Marin");

            //CNP
            var cnp = Driver.FindElement(By.Id("cnp_register"));
            cnp.Clear();
            cnp.SendKeys("6020567834521");

            //UserName
            var username = Driver.FindElement(By.Id("register_username"));
            username.Clear();
            username.SendKeys("Alina");

            //Email
            var email = Driver.FindElement(By.Id("email_register"));
            username.Clear();
            username.SendKeys("Alina");

            //Phone
            var phone = Driver.FindElement(By.Id("phone_register"));
            username.Clear();
            username.SendKeys("0765956331");

            //Password
            var password = Driver.FindElement(By.Id("password_register"));
            password.Clear();
            password.SendKeys("Admin1234!");

            //Password Confirm
            var password_confirm = Driver.FindElement(By.Id("password_confirm_register"));
            password_confirm.Clear();
            password_confirm.SendKeys("Admin1234!");

            //Upload Document
         
            //Upload image
           

            var registerButton = Driver.FindElement(By.Id("register_button"));
            registerButton.Click();
            await Task.Delay(5000);
            Assert.AreNotEqual("https://localhost:7081/register", Driver.Url);
        }
    }
}
