using CommonProject.Wrappers;
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public abstract class FilterParameterBlock
    {
        protected readonly Element _block;

        private readonly Element _header;
        
        protected FilterParameterBlock(string parameterName)
        {
            _block = new Element(By.XPath(
                $"//span[@class = 'ModelFilter__ParamName' and text() = '{parameterName}']/ancestor::div[contains(@class, 'ModelFilter__TipAttrWapper')]"));
            _header = new Element(By.XPath(
                $"//span[@class = 'ModelFilter__ParamName' and text() = '{parameterName}']/ancestor::div[@class = 'ModelFilter__HelpInfoBlock']"));            
        }

        public void ExpandBlock()
        {
            if (!IsBlockExpanded())
            {
                _header.Click();
            }
        }

        private bool IsBlockExpanded()
        {
            return _block.GetAttribute("class").Contains("open");
        }
    }
}
