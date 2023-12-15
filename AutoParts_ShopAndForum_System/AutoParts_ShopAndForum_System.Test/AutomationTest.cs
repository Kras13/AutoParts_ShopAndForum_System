using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace AutoParts_ShopAndForum_System.Test
{
    public class AutomationTest
    {
        private const string InvalidEmail = "The Email field is not a valid e-mail address.";
        private const string TooShortPassword = "Password must be more than 2 characters.";
        private const string WrongEmailOrPassword = "Invalid login attempt.";

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void OpenBrowserTest()
        {
            var webDriver = new EdgeDriver();

            webDriver.Url = "https://localhost:44362/";

            webDriver.Close();
        }

        [Test]
        public void TestLoginWithInvalidEmail()
        {
            var webDriver = new EdgeDriver();

            webDriver.Url = "https://localhost:44362/Identity/Account/Login";

            Thread.Sleep(300);
            webDriver.FindElement(By.Id("Input_Email")).SendKeys("invalidemail");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("Input_Password")).SendKeys("123456");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("login")).Click();

            Thread.Sleep(600);
            string validationText = webDriver.FindElement(By.Id("Input_Email-error")).Text;

            Assert.That(validationText, Is.EqualTo(InvalidEmail));

            webDriver.Close();
        }

        [Test]
        public void TestLoginWithShortPassword()
        {
            var webDriver = new EdgeDriver();

            webDriver.Url = "https://localhost:44362/Identity/Account/Login";

            Thread.Sleep(300);
            webDriver.FindElement(By.Id("Input_Email")).SendKeys("admin@abv.bg");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("Input_Password")).SendKeys("12");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("login")).Click();

            Thread.Sleep(600);
            string validationText = webDriver.FindElement(By.Id("Input_Password-error")).Text;

            Assert.That(validationText, Is.EqualTo(TooShortPassword));

            webDriver.Close();
        }

        [Test]
        public void TestLoginWithWrongCredentials()
        {
            var webDriver = new EdgeDriver();

            webDriver.Url = "https://localhost:44362/Identity/Account/Login";

            Thread.Sleep(300);
            webDriver.FindElement(By.Id("Input_Email")).SendKeys("admin@abv.bg");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("Input_Password")).SendKeys("123456");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("login")).Click();

            Thread.Sleep(600);
            string validationText = webDriver.FindElement(By.Id("summaryValidationId")).Text;

            Assert.That(validationText, Is.EqualTo(WrongEmailOrPassword));

            webDriver.Close();
        }

        [Test]
        public void SuccessfulLogin()
        {
            var webDriver = new EdgeDriver();

            webDriver.Url = "https://localhost:44362/Identity/Account/Login";

            Thread.Sleep(300);
            webDriver.FindElement(By.Id("Input_Email")).SendKeys("admin@abv.bg");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("Input_Password")).SendKeys("admin123");

            Thread.Sleep(600);
            webDriver.FindElement(By.Id("login")).Click();

            Thread.Sleep(600);
            bool hasLogOutButton = webDriver.FindElement(By.Id("logout")) != null;

            Assert.That(hasLogOutButton, Is.EqualTo(true));

            webDriver.Close();
        }
    }
}
