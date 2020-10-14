using System;
using System.IO;

namespace AssistPurchase.Models
{
    public class ProductImageDataModel
    {
        public string LocalImageSource;
        string ImageDirectory = "ProductImages";

        public string ImageSource { get; set; }

        public ProductImageDataModel() { }
        public ProductImageDataModel(string imageSource)
        {
            this.ImageSource = Path.Combine(Directory.GetCurrentDirectory() + imageSource);

            //ImageSaveAs(imageName);
        }

        public bool ImageSaveAs(string imageName)
        {
            try
            {

                ImageSource = Path.Combine('\\' + ImageDirectory, imageName + ".jpeg");
                var fs = File.Create(Directory.GetCurrentDirectory() + ImageSource);
                byte[] b = File.ReadAllBytes(LocalImageSource);

                fs.Write(b, 0, b.Length);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }

    public class ImageProcessing
    {

    }
}
