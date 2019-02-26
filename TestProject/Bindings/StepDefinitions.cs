using CommonProject.Helpers;
using CommonProjeect;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TestProject.Models;
using TestProject.PageObjects;

namespace TestProject.Bindings
{
    [Binding]
    public sealed class StepDefinitions
    {
        private static List<SearchCriteria> _criteriaList = new List<SearchCriteria>();
        
        [Given(@"Market main page displayed")]
        public void GivenMarketMainPageDisplayed()
        {
            WebDriver.Navigate(GlobalSettings.MarketMainPageUri);
        }

        [When(@"I select (.*) subsection in (.*) section")]
        public void ProceedToSubsection(string subsection, string section)
        {
            var catalog = new Catalog();
            catalog.Sections.Single(e => e.Text == section).Hover();
            catalog.SubSections.Single(e => e.Text == subsection).Click();
        }

        [When(@"I fill in (.*) filter with (.*) value")]
        public void SetFilterValue(string parameter, string value)
        {
            var filterBlock = new FilterBlock();
            var parameterFilterBlock = new CheckboxesFilterParameterBlock(parameter);
            parameterFilterBlock.SetFilterValue(value);
            AddSearchCriteria(parameter, value);
        }

        [When(@"I set prices range from (.*) to (.*)")]
        public void SetPricesRange(decimal minPrice, decimal maxPrice)
        {
            var filterBlock = new FilterBlock
            {
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };
            _criteriaList.Add(new HighPrice(maxPrice));
            _criteriaList.Add(new LowPrice(minPrice));
        }

        [When(@"Apply entered filter values")]
        public void ApplyFilters()
        {
            var filterBlock = new FilterBlock();
            filterBlock.ApplyFilters.Click();
        }

        [Then(@"Search results should be displayed with correct values")]
        public void CheckSearchResults()
        {
            var productListBlock = new ProductListBlock();
            var productList = productListBlock.ProductList;
            foreach (var product in productList)
            {
                foreach (var criteria in _criteriaList)
                {
                    Assert.IsTrue(criteria.CheckProductMatching(product), "Product doesn't match expected criteria");
                }
            }
        }

        private void AddSearchCriteria(string parameter, string value)
        {
            switch (parameter)
            {
            case "Производитель":
                {
                    _criteriaList.Add(new Producer(value));
                    break;
                }
            }
        }
    }
}
