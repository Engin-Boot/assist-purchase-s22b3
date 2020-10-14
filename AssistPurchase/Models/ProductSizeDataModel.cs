

namespace AssistPurchase.Models
{
    public class ProductSizeDataModel
    {
        public double ProductLength { get; set; }

        public double ProductWidth { get; set; }

        public double ProductHeight { get; set; }

        public ProductSizeDataModel(double length,double width,double height)
        {
            ProductLength = length;
           ProductWidth = width;
            ProductHeight = height;
        }

        public ProductSizeDataModel()
        {

        }
    }
}
