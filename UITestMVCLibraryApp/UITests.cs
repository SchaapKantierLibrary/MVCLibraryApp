using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;

namespace UITestsMVCLibraryApp;

[TestFixture]
public class UITests
{
    private IWebDriver _driver;

    [SetUp]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();

        var options = new ChromeOptions();
        options.AcceptInsecureCertificates = true;
        _driver = new ChromeDriver(options);

    }

    [Test]
    public void TestHomePageTitle()
    {
        _driver.Navigate().GoToUrl("http://localhost:5076/"); // adjust this to your local setup
        Assert.AreEqual("http://localhost:5076/", _driver.Url);
    }

    [Test]
    public void TestLoginAsBezoeker()
    {
        // replace these with actual values
        string email = "User1@example.com";
        string password = "Password123!";

        _driver.Navigate().GoToUrl("http://localhost:5076/Bezoeker/Login");

        _driver.FindElement(By.Name("Email")).SendKeys(email);
        _driver.FindElement(By.Name("Password")).SendKeys(password);
        _driver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();


        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.Url == "http://localhost:5076/Bezoeker/Dashboard");

        Assert.AreEqual("http://localhost:5076/Bezoeker/Dashboard", _driver.Url);
    }

    [Test]
    public void TestLoginAsMedewerker()
    {
        // replace these with actual values
        string email = "Medewerker@example.com";
        string password = "Password123!";

        _driver.Navigate().GoToUrl("http://localhost:5076/Bezoeker/Login");

        _driver.FindElement(By.Name("Email")).SendKeys(email);
        _driver.FindElement(By.Name("Password")).SendKeys(password);
        _driver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();


        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.Url == "http://localhost:5076/Medewerker/Dashboard");

        Assert.AreEqual("http://localhost:5076/Medewerker/Dashboard", _driver.Url);
    }

    [Test]
    public void TestLoginAsBeheerder()
    {
        // replace these with actual values
        string email = "Admin@example.com";
        string password = "Password123!";

        _driver.Navigate().GoToUrl("http://localhost:5076/Bezoeker/Login");

        _driver.FindElement(By.Name("Email")).SendKeys(email);
        _driver.FindElement(By.Name("Password")).SendKeys(password);
        _driver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();


        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.Url == "http://localhost:5076/Beheerder/Dashboard");

        Assert.AreEqual("http://localhost:5076/Beheerder/Dashboard", _driver.Url);
    }

    [Test]
    public void TestUserRegistration()
    {
        // replace these with actual values. if you have run this test please change the Email with a number or character so it can register.
        string username = "testuser";
        string email = "testuser2234@example.com";
        string password = "Password123!";

        _driver.Navigate().GoToUrl("http://localhost:5076/Bezoeker/Register");

        _driver.FindElement(By.Name("Naam")).SendKeys(username);
        _driver.FindElement(By.Name("Email")).SendKeys(email);
        _driver.FindElement(By.Name("Password")).SendKeys(password);
        _driver.FindElement(By.Name("ConfirmPassword")).SendKeys(password);
        _driver.FindElement(By.CssSelector("button[type='submit'].btn.btn-primary")).Click();

        // Wait for a small delay before checking the URL.
        System.Threading.Thread.Sleep(1000); // wait for 1 second

        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.Url == "http://localhost:5076/Bezoeker/Dashboard");

        Assert.AreEqual("http://localhost:5076/Bezoeker/Dashboard", _driver.Url);
    }

    private void Login(string username, string password)
    {
        _driver.Navigate().GoToUrl("http://localhost:5076/Bezoeker/Login");
        _driver.FindElement(By.Name("Email")).SendKeys(username);
        _driver.FindElement(By.Name("Password")).SendKeys(password);
        _driver.FindElement(By.CssSelector("button[type='submit'].btn.btn-primary")).Click();

        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.Url == "http://localhost:5076/Bezoeker/Dashboard");
    }

    [Test]
    public void TestIndexItemsPage()
    {
        Login("User1@example.com", "Password123!");

        _driver.Navigate().GoToUrl("http://localhost:5076/Bezoeker/IndexItems");

        var locationDropdown = _driver.FindElement(By.Id("locationDropdown"));
        Assert.IsNotNull(locationDropdown);

        var searchTitleInput = _driver.FindElement(By.Name("title"));
        Assert.IsNotNull(searchTitleInput);

        var searchAuthorInput = _driver.FindElement(By.Name("authorSearch"));
        Assert.IsNotNull(searchAuthorInput);

        var searchButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
        Assert.IsNotNull(searchButton);
    }

    [Test]
    public void TestDashboardPage()
    {
        Login("User1@example.com", "Password123!");

        _driver.Navigate().GoToUrl("http://localhost:5076/Bezoeker/Dashboard");

        var reservationButton = _driver.FindElement(By.XPath("//a[contains(text(),'Your Reservations')]"));
        Assert.IsNotNull(reservationButton);

        var searchItemsButton = _driver.FindElement(By.XPath("//a[contains(text(),'Search Items')]"));
        Assert.IsNotNull(searchItemsButton);
    }


    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
