using System.Collections.Generic;
using System.Linq;
using CommonProject.Wrappers;
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public class ProductCard
    {
        private readonly By _productNameLocator = By.XPath(".//a[@class = 'ModelList__LinkModel']/span[@itemprop = 'name']");
        private readonly By _productDescriptionLocator = By.XPath(".//div[@class = 'ModelList__DescBlock']");
        private readonly By _productPriceLocator = By.XPath(".//span[@class = 'PriceBlock__PriceValue']/span");

        private readonly IEnumerable<Element> _productPrices;

        public string ProductName
        {
            get; private set;
        }

        public string ProductDescription
        {
            get; private set;
        }

        public decimal LowPrice
        {
            get
            {
                return decimal.Parse(_productPrices.FirstOrDefault().Text.Replace(",", ".").Replace(" ", string.Empty));
            }
        }

        public decimal HighPrice
        {
            get
            {
                return _productPrices.ToList().Count > 1 ? decimal.Parse(_productPrices.ElementAt(1).Text.Replace(",", ".").Replace(" ", string.Empty)) : 0;
            }
        }

        public ProductCard(Element card)
        {
            var productCard = card;
            _productPrices = productCard.FindAllChildElements(_productPriceLocator);
            ProductName = productCard.FindElement(_productNameLocator).Text;
            ProductDescription = productCard.FindElement(_productDescriptionLocator).Text;
        }
    }
}