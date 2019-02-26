using TestProject.PageObjects;

namespace TestProject.Models
{
    public class Producer : SearchCriteria
    {
        private readonly string _producer;

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
