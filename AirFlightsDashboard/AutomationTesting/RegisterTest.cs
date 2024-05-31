using AutomationTesting.BaseClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTesting
{
    public class RegisterTest : Test
    {
        [Test]
        public async Task RegisterSuccesTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7081/register");
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../../AirFlights/wwwroot/images/blog/contact.jpg";
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
        public async Task RegisterUserExistTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7081/register");
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../../AirFlights/wwwroot/images/blog/contact.jpg";
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
            username.SendKeys("admin");

            //Email
            var email = Driver.FindElement(By.Id("email_register"));
            email.Clear();
            email.SendKeys("admin@admin.ro");

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
            await Task.Delay(2000);
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
            await Task.Delay(2000);
            actions.MoveToElement(upload);
            actions.Perform();
            upload.Click();
            await Task.Delay(2000);

            var registerButton = Driver.FindElement(By.Id("register_button"));
            actions.MoveToElement(registerButton);
            actions.Perform();
            registerButton.Click();
            await Task.Delay(5000);
            Assert.AreEqual("https://localhost:7081/register", Driver.Url);
        }

        [Test]
        public async Task InvalidPasswordTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7081/register");
            await Task.Delay(2000);

            //Password
            var password = Driver.FindElement(By.Id("password_register"));
            password.Clear();
            password.SendKeys("admin1234");

            await Task.Delay(2000);
            var error = Driver.FindElement(By.Id("password_error_message"));
            Assert.AreNotEqual(error.Text, string.Empty);

        }

        [Test]
        public async Task InvalidEmailTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7081/register");
            await Task.Delay(2000);
            //Password
            var password = Driver.FindElement(By.Id("email_register"));
            password.Clear();
            password.SendKeys("admin@admin");

            await Task.Delay(2000);
            var error = Driver.FindElement(By.Id("required_email"));
            Assert.AreNotEqual(error.Text, string.Empty);
        }

        [Test]
        public async Task DontMatchesPasswordTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7081/register");
            await Task.Delay(2000);
            //Password
            var password = Driver.FindElement(By.Id("password_register"));
            password.Clear();
            password.SendKeys("Admin1234!");
            await Task.Delay(2000);
            //Password Confirm
            var password_confirm = Driver.FindElement(By.Id("password_confirm_register"));
            password_confirm.Clear();
            password_confirm.SendKeys("Admin123!");
            await Task.Delay(2000);

            var confirmation = Driver.FindElement(By.Id("confirmation"));
            Assert.AreNotEqual(confirmation.Text, string.Empty);
        }

        [Test]
        public async Task RequiredFieldsTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:7081/register");
            await Task.Delay(2000);
            Actions actions = new Actions(Driver);
            var registerButton = Driver.FindElement(By.Id("register_button"));
            actions.MoveToElement(registerButton);
            actions.Perform();
            registerButton.Click();
            await Task.Delay(5000);
            var firstname = Driver.FindElement(By.Id("required_firstname"));
            Assert.AreNotEqual(firstname.Text, string.Empty);
            var lastname = Driver.FindElement(By.Id("required_lastname"));
            Assert.AreNotEqual(lastname.Text, string.Empty);
            var cnp = Driver.FindElement(By.Id("required_cnp"));
            Assert.AreNotEqual(cnp.Text, string.Empty);
            var username = Driver.FindElement(By.Id("required_username"));
            Assert.AreNotEqual(username.Text, string.Empty);
            var email = Driver.FindElement(By.Id("required_email"));
            Assert.AreNotEqual(email.Text, string.Empty);
            var phone = Driver.FindElement(By.Id("required_phone"));
            Assert.AreNotEqual(phone.Text, string.Empty);
            var password = Driver.FindElement(By.Id("password_error_message"));
            Assert.AreNotEqual(password.Text, string.Empty);
            var passwordconfirm = Driver.FindElement(By.Id("confirmation"));
            Assert.AreNotEqual(passwordconfirm.Text, string.Empty);
        }
    }
}
