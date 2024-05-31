using AutomationTesting.BaseClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace AutomationTesting;

public class UserDetailsTest : Test
{
    readonly string baseDirectory = AppContext.BaseDirectory;
    readonly string relativePath = "../../../../AirFlights/wwwroot/images/blog/contact.jpg";

    [Test]
    public async Task EditUserProfileImageTest()
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
        Actions actions = new Actions(Driver);

        Driver.Navigate().GoToUrl("https://localhost:7081/account");
        await Task.Delay(2000);
        var editButton = Driver.FindElements(By.Id("edit_user_image"))[1];
        actions.MoveToElement(editButton);
        actions.Perform();
        editButton.Click();
        //Upload image
        var image = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        var imageInput = Driver.FindElement(By.Id("upload_image"));
        imageInput.SendKeys(image);
        await Task.Delay(2000);
        var upload = Driver.FindElement(By.ClassName("b-file-picker-file-upload"));
        actions.MoveToElement(upload);
        actions.Perform();
        upload.Click();
        await Task.Delay(2000);

        var save_button = Driver.FindElement(By.Id("save"));
        actions.MoveToElement(save_button);
        actions.Perform();
        save_button.Click();
        await Task.Delay(5000);

        Assert.AreEqual("https://localhost:7081/account", Driver.Url);
    }

    [Test]
    public async Task DeleteUserProfileImageTest()
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
        Actions actions = new Actions(Driver);

        Driver.Navigate().GoToUrl("https://localhost:7081/account");
        await Task.Delay(2000);
        var editButton = Driver.FindElements(By.Id("edit_user_image"))[1];
        actions.MoveToElement(editButton);
        actions.Perform();
        editButton.Click();
        //Upload image
        var image = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        var imageInput = Driver.FindElement(By.Id("upload_image"));
        imageInput.SendKeys(image);
        await Task.Delay(2000);
        var upload = Driver.FindElement(By.ClassName("b-file-picker-file-upload"));
        actions.MoveToElement(upload);
        actions.Perform();
        upload.Click();
        await Task.Delay(2000);

        var save_button = Driver.FindElement(By.Id("save"));
        actions.MoveToElement(save_button);
        actions.Perform();
        save_button.Click();
        await Task.Delay(5000);

        Assert.AreEqual("https://localhost:7081/account", Driver.Url);
    }
}