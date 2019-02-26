using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace CommonProject.Wrappers
{
    public sealed class Element
    {
        private readonly IWebElement _element;

        private By _selector;

        public Element(By selector)
        {
            _selector = selector;
            _element = new WebDriverWait(ScenarioContext.Current.Get<IWebDriver>(), TimeSpan.FromSeconds(GlobalSettings.Timeout))
                .Until(ExpectedConditions.ElementExists(selector));
        }

        private Element(IWebElement element)
        {
            _element = element;
        }

        public void WaitForElementVisibility()
        {
            new WebDriverWait(ScenarioContext.Current.Get<IWebDriver>(), TimeSpan.FromSeconds(GlobalSettings.Timeout)).Until(d => _element.Displayed);
        }

        public void WaitForElementEnabling()
        {
            new WebDriverWait(ScenarioContext.Current.Get<IWebDriver>(), TimeSpan.FromSeconds(GlobalSettings.Timeout)).Until(d => _element.Enabled);
        }

        public IEnumerable<Element> FindAllElements()
        {
            return ScenarioContext.Current.Get<IWebDriver>().FindElements(_selector).Select(e => new Element(e));
        }

        public IEnumerable<Element> FindAllChildElements(By selector)
        {
            return _element.FindElements(selector).Select(e => new Element(e));
        }

        public string Text
        {
            get
            {
                return _element.Text.Trim();
            }
        }

        public string GetAttribute(string attributeName)
        {
            return _element.GetAttribute(attributeName);
        }

        public Element FindElement(By selector)
        {
            var childElement = new Element(_element.FindElement(selector))
            {
                _selector = selector
            };
            return childElement;
        }

        public void Select()
        {
            if (_element.Selected)
            {
                return;
            }
            Click();
        }

        public void Hover()
        {
            var actions = new Actions(ScenarioContext.Current.Get<IWebDriver>());
            actions.MoveToElement(_element);
            actions.Perform();
        }

        public void Click()
        {
            WaitForElementEnabling();
            WaitForElementVisibility();
            _element.Click();
        }

        public void SendKeys(string value)
        {
            WaitForElementEnabling();
            _element.SendKeys(value);
        }

        public void SendKeys(decimal value)
        {
            WaitForElementEnabling();
            _element.SendKeys(value.ToString());
        }
    }
}
