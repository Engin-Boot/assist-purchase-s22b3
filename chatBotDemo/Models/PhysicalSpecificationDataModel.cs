
namespace chatBotDemo.Models
{
    public class PhysicalSpecificationDataModel
    {
        public double ProductWeight { get; set; }

        public ProductSizeDataModel ProductSize { get; set; }

        public PhysicalSpecificationDataModel(double weight,ProductSizeDataModel size)
        {
            this.ProductWeight = weight;
            this.ProductSize = size;

        }
        public PhysicalSpecificationDataModel()
        {

        }
    }
}
