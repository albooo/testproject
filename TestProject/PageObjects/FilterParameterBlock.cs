using CommonProjeect.Wrappers;
using OpenQA.Selenium;

namespace TestProject.Models
{
    abstract class FilterParameterBlock
    {
        protected Element _header;

        protected Element _block;

        public abstract void SetFilterValue(object parameterValue);

        public FilterParameterBlock(string parameterName)
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
