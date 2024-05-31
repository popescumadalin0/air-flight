using AutomationTesting.BaseClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace AutomationTesting;

public class UserDetailsTest : Test
{

    [Test]
    public async Task LoginSuccesTest()
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

        await Task.Delay(2000);

        Driver.Navigate().GoToUrl("https://localhost:7081/account");
        await Task.Delay(2000);
        var editButton = Driver.FindElement(By.Id("edit_user_image"));
        actions.MoveToElement(registerButton);
        actions.Perform();
        edit_user_image
        //Upload image
        var image = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        IWebElement imageInput = Driver.FindElement(By.Id("upload_image"));
        imageInput.SendKeys(image);
        upload = Driver.FindElements(By.ClassName("b-file-picker-file-upload"))[1];
        actions.MoveToElement(upload);
        actions.Perform();
        upload.Click();
        await Task.Delay(2000);

        var registerButton = Driver.FindElement(By.Id("register_button"));
        actions.MoveToElement(registerButton);
        actions.Perform();
        registerButton.Click();
        await Task.Delay(5000);
        Assert.AreNotEqual("https://localhost:7081/register", Driver.Url);

        await Task.Delay(5000);
        Assert.AreNotEqual("https://localhost:7081/login", Driver.Url);
    }
}