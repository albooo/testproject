using System.Collections.Generic;
using CommonProject.Wrappers;
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public class Catalog
    {
        private readonly By _catalogLocator = By.Id("Catalog");
        private readonly By _sectionLinkLocator = By.XPath("//span[@data-level = '1']//a");
        private readonly By _subSectionLinkLocator = By.XPath("//span[@data-level = '3']//span[@class = 'Catalog__LinkTextBlock']");

        public Catalog()
        {
            new Element(_catalogLocator).WaitForElementVisibility();
        }

        public IEnumerable<Element> Sections
        {
            get
            {
                return new Element(_catalogLocator).FindAllChildElements(_sectionLinkLocator);
            }
        }

        public IEnumerable<Element> SubSections
        {
            get
            {
                return new Element(_catalogLocator).FindAllChildElements(_subSectionLinkLocator);
            }
        }
    }
}
