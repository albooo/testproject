using TestProject.PageObjects;

namespace TestProject.Models
{
    class HighPrice : SearchCriteria
    {
        private decimal _highPrice;

        public HighPrice(decimal value)
        {
            _highPrice = value;          
        }

        public override bool CheckProductMatching(ProductCard product)
        {
            return product.LowPrice <= _highPrice;
        }
    }
}
