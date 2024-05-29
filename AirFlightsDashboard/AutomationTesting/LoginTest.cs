//Inside SeleniumTest.cs
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTesting;

public class LoginTest: Test
{ 

    [Test]
    public async Task LoginSucces()
    {

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        var username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("admin");
        var password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin1234!");
        var loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(5000);
        Assert.AreNotEqual("https://localhost:7081/login", Driver.Url);
    }

    [Test]
    public async Task LoginWrongPassword()
    {

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        var username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("admin");
        var password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin123!");
        var loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(5000);
        Assert.AreEqual("https://localhost:7081/login", Driver.Url);
    }

    [Test]
    public async Task LoginWrongUsername()
    {

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        var username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("Admin");
        var password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin1234!");
        var loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(5000);
        Assert.AreEqual("https://localhost:7081/login", Driver.Url);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Driver.Close();
        Driver.Quit();
    }
}