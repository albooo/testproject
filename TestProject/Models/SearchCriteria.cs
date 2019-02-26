using TestProject.PageObjects;

namespace TestProject.Models
{
    public abstract class SearchCriteria
    {
        public abstract bool CheckProductMatching(ProductCard product);        
    }
}
