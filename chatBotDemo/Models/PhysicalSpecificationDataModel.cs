
namespace AssistPurchase.Models
{
    public class PhysicalSpecificationDataModel
    {
        public double ProductWeight { get; set; }

        public ProductSizeDataModel ProductSize { get; set; }

        public PhysicalSpecificationDataModel(double weight,ProductSizeDataModel size)
        {
            ProductWeight = weight;
            ProductSize = size;

        }
        public PhysicalSpecificationDataModel()
        {

        }
    }
}
