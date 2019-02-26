using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CommonProject.Helpers
{
    public static class WebDriver
    {
        private static IWebDriver _instance;

        public static IWebDriver Start()
        {
            _instance = _instance ?? StartChromeDriver();
            return _instance;
        }

        public static void Navigate(Uri url)
        {
            _instance.Navigate().GoToUrl(url);
        }

        public static void Navigate(object marketMainPageUri)
        {
            throw new NotImplementedException();
        }

        public static void Quit()
        {
            if (_instance != null)
            {
                _instance.Quit();
                _instance = null;
            }
        }

        private static IWebDriver StartChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            options.AddArgument("start-maximized");
            return new ChromeDriver(options);
        }
    }
}
