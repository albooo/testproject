using CommonProjeect.Wrappers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.PageObjects
{
    public class ProductCard
    {
        private readonly By _productNameLocator = By.XPath(".//a[@class = 'ModelList__LinkModel']/span[@itemprop = 'name']");
        private readonly By _productDescriptionLocator = By.XPath(".//div[@class = 'ModelList__DescBlock']");
        private readonly By _productPriceLocator = By.XPath(".//span[@class = 'PriceBlock__PriceValue']/span");

        private readonly Element _productCard;
        private IEnumerable<Element> _productPrices;

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
            _productCard = card;
            _productPrices = _productCard.FindAllChildElements(_productPriceLocator);
            ProductName = _productCard.FindElement(_productNameLocator).Text;
            ProductDescription = _productCard.FindElement(_productDescriptionLocator).Text;
        }
    }
}