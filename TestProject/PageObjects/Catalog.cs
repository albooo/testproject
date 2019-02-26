using CommonProject.Helpers;
using CommonProjeect.Wrappers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.PageObjects
{
    class Catalog
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
                return new Element(_sectionLinkLocator).FindAllElements();
            }
        }

        public IEnumerable<Element> SubSections
        {
            get
            {
                return new Element(_subSectionLinkLocator).FindAllElements();
            }
        }
    }
}
