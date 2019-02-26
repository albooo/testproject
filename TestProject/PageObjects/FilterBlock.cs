using CommonProject.Helpers;
using CommonProjeect.Wrappers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TestProject.Models;

namespace TestProject.PageObjects
{
    class FilterBlock
    {
        private readonly By _minPriceLocator = By.XPath("//input[@name = 'price_before']");
        private readonly By _maxPriceLocator = By.XPath("//input[@name = 'price_after']");
        private readonly By _applyFiltersButtonLocator = By.XPath("//span[@onclick = 'ModelFilter__ClickSubmitButton();']");

        public FilterBlock()
        {
            new Element(_applyFiltersButtonLocator).WaitForElementVisibility();
        }

        public Element ApplyFilters
        {
            get
            {
                return new Element(_applyFiltersButtonLocator);
            }
        }

        public decimal MinPrice
        {
            get
            {
                return decimal.Parse(new Element(_minPriceLocator).GetAttribute("oldvalue"));
            }

            set
            {
                new Element(_minPriceLocator).SendKeys(value);
            }
        }

        public decimal MaxPrice
        {
            get
            {
                return decimal.Parse(new Element(_maxPriceLocator).GetAttribute("oldvalue"));
            }

            set
            {
                new Element(_maxPriceLocator).SendKeys(value);
            }
        }
    }
}
