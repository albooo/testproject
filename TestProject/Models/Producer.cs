using TestProject.PageObjects;

namespace TestProject.Models
{
    class Producer : SearchCriteria
    {
        private string _producer;

        public Producer(string value)
        {
            _producer = value;          
        }

        public override bool CheckProductMatching(ProductCard product)
        {
            return product.ProductName.Contains(_producer);
        }
    }
}
