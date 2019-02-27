using CommonProject.Wrappers;
using OpenQA.Selenium;
using System.Linq;

namespace TestProject.PageObjects
{
    public abstract class FilterParameterBlock
    {
        private static readonly By _showFullOptionsListLinkLocator = 
            By.XPath(".//span[contains(@class, 'ModelFilter__OpenHideAttrTxt') and text() = 'Еще' and not(contains(@class, 'hidden'))]");
        
        protected readonly Element _block;

        private readonly Element _header;
        
        protected FilterParameterBlock(string parameterName)
        {
            _block = new Element(By.XPath(
                $"//span[@class = 'ModelFilter__ParamName' and text() = '{parameterName}']/ancestor::div[contains(@class, 'ModelFilter__TipAttrWapper')]"));
            _header = new Element(By.XPath(
                $"//span[@class = 'ModelFilter__ParamName' and text() = '{parameterName}']"));
            ExpandBlock();
            ShowFullOptionsList();
        }

        public void ExpandBlock()
        {
            if (!IsBlockExpanded())
            {
                _header.Click();
            }
        }

        public void ShowFullOptionsList()
        {
            var linksList = _block.FindAllChildElements(_showFullOptionsListLinkLocator);
            if (linksList.Any())
            {
                linksList.FirstOrDefault().Click();
            }
        }

        private bool IsBlockExpanded()
        {
            return _block.GetAttribute("class").Contains("Open");
        }
    }
}
