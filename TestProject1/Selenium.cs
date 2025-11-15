using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace TestProject1
{
    internal class Selenium
    {
        IWebDriver _driver;
        private WebDriverWait _wait;


        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            var URL = "http://localhost:8080";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);
            Assert.IsNotNull(_driver);


        }
        [Test]
        public void CreateCountryTest()
        {
            
            _driver.Navigate().GoToUrl("http://localhost:8080");

            var btnAgregarPais = _wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.XPath("//button[contains(text(), 'Agregar país')]")
                )
            );
            btnAgregarPais.Click();
            var txtNombre = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name")));
            txtNombre.SendKeys("China");

            var selectContinente = _driver.FindElement(By.Id("continente"));
            selectContinente.Click();
            selectContinente.FindElement(By.XPath("//option[contains(text(),'Asia')]")).Click();

            var txtIdioma = _driver.FindElement(By.Id("idioma"));
            txtIdioma.SendKeys("Mandarín");

            
            var btnGuardar = _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]"));
            btnGuardar.Click();

            _wait.Until(ExpectedConditions.UrlToBe("http://localhost:8080/"));

            var titulo = _wait.Until(
                ExpectedConditions.ElementIsVisible(
                    By.XPath("//h1[contains(text(),'Lista de países')]")
                )
            );

            Assert.IsTrue(titulo.Displayed, " No se volvió a la lista de países después de guardar.");

            Console.WriteLine(" País creado correctamente y redirección exitosa.");
        }
    }
}