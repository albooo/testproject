using CommonProjeect.Wrappers;
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    class MainPage
    {
        private readonly By _mainPageBodyLocator = By.XPath("//body[@data-page = 'main']");

        public MainPage()
        {
            new Element(_mainPageBodyLocator).WaitForElementVisibility();
        }
    }
}