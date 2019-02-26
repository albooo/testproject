using System.Collections.Generic;
using System.Linq;
using CommonProject.Wrappers;
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public class ProductListBlock
    {
        private readonly By _productListLocator = By.XPath("//div[@class = 'ModelList']");
        private readonly By _productCardLocator = By.XPath("//div[@class = 'ModelList__ModelBlockRow']");

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

        private Element ProductListElement
        {
            get; set;
        }
    }
}