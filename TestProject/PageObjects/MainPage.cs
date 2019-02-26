using CommonProject.Wrappers;
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public class MainPage
    {
        private readonly By _mainPageBodyLocator = By.XPath("//body[@data-page = 'main']");

        public MainPage()
        {
            new Element(_mainPageBodyLocator).WaitForElementVisibility();
        }
    }
}