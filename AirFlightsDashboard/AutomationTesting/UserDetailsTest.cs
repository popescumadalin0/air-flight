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
        await CreateUser();

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(2000);
        var username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("Alina");
        var password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin1234!");
        var loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();

        await Task.Delay(2000);
        var actions = new Actions(Driver);

        Driver.Navigate().GoToUrl("https://localhost:7081/account");
        await Task.Delay(2000);
        var deleteButton = Driver.FindElement(By.Id("delete"));
        actions.MoveToElement(deleteButton);
        actions.Perform();
        deleteButton.Click();
        await Task.Delay(2000);

        Assert.AreNotEqual("https://localhost:7081/account", Driver.Url);
    }

    private async Task CreateUser()
    {
        Driver.Navigate().GoToUrl("https://localhost:7081/register");
        await Task.Delay(2000);

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
        email.Clear();
        email.SendKeys("Alina@yahoo.com");

        //Phone
        var phone = Driver.FindElement(By.Id("phone_register"));
        phone.Clear();
        phone.SendKeys("0765956331");

        //Password
        var password = Driver.FindElement(By.Id("password_register"));
        password.Clear();
        password.SendKeys("Admin1234!");

        //Password Confirm
        var password_confirm = Driver.FindElement(By.Id("password_confirm_register"));
        password_confirm.Clear();
        password_confirm.SendKeys("Admin1234!");

        //Upload Document
        var document = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
        IWebElement fileInput = Driver.FindElement(By.Id("upload_document"));
        fileInput.SendKeys(document);
        var upload = Driver.FindElement(By.ClassName("b-file-picker-file-upload"));
        Actions actions = new Actions(Driver);
        actions.MoveToElement(upload);
        actions.Perform();
        upload.Click();
        await Task.Delay(2000);

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
    }

    [Test]
    public async Task EditPasswordSuccessfullyTest()
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
        var editButton = Driver.FindElements(By.Id("edit_password"))[1];
        actions.MoveToElement(editButton);
        actions.Perform();
        editButton.Click();
        await Task.Delay(2000);
        //Upload image
        var oldPassword = Driver.FindElement(By.Id("old_password"));
        actions.MoveToElement(oldPassword);
        actions.Perform();
        await Task.Delay(2000);
        oldPassword.SendKeys("Admin1234!");

        var newPassword = Driver.FindElement(By.Id("new_password"));
        newPassword.SendKeys("Admin1234!test");

        var confirmNewPassword = Driver.FindElement(By.Id("confirm_new_password"));
        confirmNewPassword.SendKeys("Admin1234!test");

        await Task.Delay(2000);

        var save_button = Driver.FindElement(By.Id("save"));
        actions.MoveToElement(save_button);
        actions.Perform();
        save_button.Click();
        await Task.Delay(5000);

        Assert.AreEqual("https://localhost:7081/account", Driver.Url);

        var logoutButton = Driver.FindElement(By.Id("logout"));
        actions.MoveToElement(logoutButton);
        actions.Perform();
        logoutButton.Click();
        await Task.Delay(2000);

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(2000);
        username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("admin");
        password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin1234!test");
        loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(2000);
        Assert.AreNotEqual("https://localhost:7081/login", Driver.Url);
    }

    [Test]
    public async Task EditPasswordIncorrectOldPasswordTest()
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
        var editButton = Driver.FindElements(By.Id("edit_password"))[1];
        actions.MoveToElement(editButton);
        actions.Perform();
        editButton.Click();
        await Task.Delay(2000);
        //Upload image
        var oldPassword = Driver.FindElement(By.Id("old_password"));
        actions.MoveToElement(oldPassword);
        actions.Perform();
        await Task.Delay(2000);
        oldPassword.SendKeys("Janina1234!");

        var newPassword = Driver.FindElement(By.Id("new_password"));
        newPassword.SendKeys("Admin1234!test1");

        var confirmNewPassword = Driver.FindElement(By.Id("confirm_new_password"));
        confirmNewPassword.SendKeys("Admin1234!test1");

        await Task.Delay(2000);

        var save_button = Driver.FindElement(By.Id("save"));
        actions.MoveToElement(save_button);
        actions.Perform();
        save_button.Click();
        await Task.Delay(5000);

        Assert.AreEqual("https://localhost:7081/account", Driver.Url);

        var logoutButton = Driver.FindElement(By.Id("logout"));
        actions.MoveToElement(logoutButton);
        actions.Perform();
        logoutButton.Click();
        await Task.Delay(2000);

        Driver.Navigate().GoToUrl("https://localhost:7081/login");
        await Task.Delay(2000);
        username = Driver.FindElement(By.Id("login_username"));
        username.Clear();
        username.SendKeys("admin");
        password = Driver.FindElement(By.Id("password_login"));
        password.Clear();
        password.SendKeys("Admin1234!test1");
        loginButton = Driver.FindElement(By.Id("login_button"));
        loginButton.Click();
        await Task.Delay(2000);
        Assert.AreEqual("https://localhost:7081/login", Driver.Url);
    }
}