using System;
using System.IO;

namespace AssistPurchase.Models
{
    public class ProductImageDataModel
    {
        
        readonly string ImageDirectory = "ProductImages";

        public string ImageSource { get; set; }

        public ProductImageDataModel() { }
        public ProductImageDataModel(string imageSource)
        {
            this.ImageSource = Path.Combine(Directory.GetCurrentDirectory() + imageSource);

        }

        public bool ImageSaveAs(string imageName,string localImageSource )
        {
            try
            {
                ImageSource = Path.Combine('\\' + ImageDirectory, imageName + ".jpeg");
                var fs = File.Create(Directory.GetCurrentDirectory() + ImageSource);
                byte[] b = File.ReadAllBytes(localImageSource);

                fs.Write(b, 0, b.Length);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

    }
}
