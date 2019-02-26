using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using static TechTalk.SpecFlow.ScenarioContext;

namespace CommonProjeect.Wrappers
{
    public class Element
    {
        protected IWebElement _element;

        protected By _selector;

        public Element(By selector)
        {
            _selector = selector;
            _element = new WebDriverWait(Current.Get<IWebDriver>(), TimeSpan.FromSeconds(GlobalSettings.Timeout))
                .Until(ExpectedConditions.ElementExists(selector));
        }

        protected Element(IWebElement element)
        {
            _element = element;
        }

        public void WaitForElementVisibility()
        {
            new WebDriverWait(Current.Get<IWebDriver>(), TimeSpan.FromSeconds(GlobalSettings.Timeout)).Until(d => _element.Displayed);
        }

        public void WaitForElementEnabling()
        {
            new WebDriverWait(Current.Get<IWebDriver>(), TimeSpan.FromSeconds(GlobalSettings.Timeout)).Until(d => _element.Enabled);
        }

        public virtual IEnumerable<Element> FindAllElements()
        {
            return Current.Get<IWebDriver>().FindElements(_selector).Select(e => new Element(e));
        }

        public virtual IEnumerable<Element> FindAllChildElements(By selector)
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
            if (_element.Selected) return;
            Click();
        }

        public virtual void Hover()
        {
            var actions = new Actions(Current.Get<IWebDriver>());
            actions.MoveToElement(_element);
            actions.Perform();
        }

        public virtual void Click()
        {
            WaitForElementEnabling();
            WaitForElementVisibility();
            _element.Click();
        }

        public virtual void SendKeys(string value)
        {
            WaitForElementEnabling();
            _element.SendKeys(value);
        }

        public virtual void SendKeys(decimal value)
        {
            WaitForElementEnabling();
            _element.SendKeys(value.ToString());
        }
    }
}
