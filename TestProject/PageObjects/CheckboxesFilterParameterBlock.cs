using CommonProjeect.Wrappers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Models
{
    class CheckboxesFilterParameterBlock : FilterParameterBlock
    {
        private readonly By _checkBoxSelector = By.XPath(".//input[@type = 'checkbox']");
        private readonly By _checkBoxLabelSelector = By.XPath(".//input[@type = 'checkbox']/following-sibling::label");

        private IEnumerable<Element> _optionsList;

        public CheckboxesFilterParameterBlock(string parameterName) : base(parameterName)
        {
            _optionsList = _block.FindAllChildElements(_checkBoxLabelSelector);
        }

        public override void SetFilterValue(object parameterValue)
        {
            _optionsList.Single(e => e.Text.StartsWith(parameterValue.ToString())).Click();
        }
    }
}
