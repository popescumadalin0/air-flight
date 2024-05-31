using AutomationTesting.BaseClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTesting;

public class LoginTest : Test
{

    [Test]
    public async Task LoginSuccesTest()
    {
        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(2000);
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
    public async Task LoginWrongPasswordTest()
    {

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(2000);
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
    public async Task LoginWrongUsernameTest()
    {

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(2000);
        var username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("Ana");
        var password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin1234!");
        var loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(5000);
        Assert.AreEqual("https://localhost:7081/login", Driver.Url);
    }

    [Test]
    public async Task RequiredFieldsTest()
    {
        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(5000);
        var loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(5000);
        var username = Driver.FindElement(By.Id("required_username"));
        Assert.AreNotEqual(username.Text, string.Empty);
        var password = Driver.FindElement(By.Id("required_password"));
        Assert.AreNotEqual(password.Text, string.Empty);

    }

    [Test]
    public async Task TestLogout()
    {
        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(2000);
        var username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("admin");
        var password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin1234!");
        var loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(2000);
        Driver.Navigate().GoToUrl("https://localhost:7081/account");
        await Task.Delay(5000);
        Assert.IsTrue(Driver.Url.Contains("/account"), "User not redirected to home page after login");
        var logoutButton = Driver.FindElement(By.Id("logout"));
        Actions actions = new Actions(Driver);
        actions.MoveToElement(logoutButton);
        actions.Perform();
        logoutButton.Click();
        await Task.Delay(2000);
        Assert.IsTrue(Driver.Url.Contains("/login"), "User not redirected to login page after logout");
    }
}