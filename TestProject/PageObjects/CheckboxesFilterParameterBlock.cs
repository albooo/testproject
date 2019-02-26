using System.Collections.Generic;
using System.Linq;
using CommonProject.Wrappers;
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    public sealed class CheckboxesFilterParameterBlock : FilterParameterBlock
    {
        private readonly By _checkBoxLabelSelector = By.XPath(".//input[@type = 'checkbox']/following-sibling::label");

        private readonly IEnumerable<Element> _optionsList;

        public CheckboxesFilterParameterBlock(string parameterName) : base(parameterName)
        {
            _optionsList = _block.FindAllChildElements(_checkBoxLabelSelector);
        }

        public void SetFilterValue(object parameterValue)
        {
            _optionsList.Single(e => e.Text.StartsWith(parameterValue.ToString())).Click();
        }
    }
}
