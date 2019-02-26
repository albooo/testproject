using TestProject.PageObjects;

namespace TestProject.Models
{
    class LowPrice : SearchCriteria
    {
        private decimal _lowPrice;

        public LowPrice(decimal value)
        {
            _lowPrice = value;          
        }

        public override bool CheckProductMatching(ProductCard product)
        {
            return product.HighPrice == 0 ? _lowPrice < product.LowPrice : _lowPrice < product.HighPrice;
        }
    }
}
