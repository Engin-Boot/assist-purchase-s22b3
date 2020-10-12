using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatBotDemo.Models
{
    public class ProductSizeDataModel
    {
        public double ProductLength { get; set; }

        public double ProductWidth { get; set; }

        public double ProductHeight { get; set; }

        public ProductSizeDataModel(double length,double width,double height)
        {
            this.ProductLength = length;
            this.ProductWidth = width;
            this.ProductHeight = height;
        }

        public ProductSizeDataModel()
        {

        }
    }
}
