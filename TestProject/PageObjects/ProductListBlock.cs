using CommonProjeect.Wrappers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.PageObjects
{
    class ProductListBlock
    {
        private readonly By _productListLocator = By.XPath("//div[@class = 'ModelList']");
        private readonly By _productCardLocator = By.XPath("//div[@class = 'ModelList__ModelBlockRow']");

        private Element ProductListElement
        {
            get; set;
        }

        public ProductListBlock()
        {
            ProductListElement = new Element(_productListLocator);
        }

        public IEnumerable<ProductCard> ProductList
        {
            get
            {
                return ProductListElement.FindAllChildElements(_productCardLocator).ToList().Select(e => new ProductCard(e));
            }
        }
    }
}