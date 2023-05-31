using System;
using System.Drawing;
using System.IO;

namespace HiddenImageMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            string primaryImageFile = "Papio-hamadryas-head.jpg";
            Console.WriteLine($"Path of primary image:\n{Path.GetFullPath(primaryImageFile)}");
            Console.WriteLine();
            Console.WriteLine($"Loading {primaryImageFile} into memory...");
            Image img = System.Drawing.Image.FromFile(primaryImageFile);
            float aspectRatio = (float)img.Height / (float)img.Width;
            Console.WriteLine("Calling GetThumbnailImage() on the image...");
            // You would expect this method to give you a simple thumbnail of the image:
            Image thumbnail = img.GetThumbnailImage(256, (int)(256 * aspectRatio), null, IntPtr.Zero);

            // It turns out the thumbnail is a separate image stored in the metadata of the file
            string filepath = Path.ChangeExtension(Path.GetTempFileName(), ".jpg");
            Console.WriteLine();
            Console.WriteLine($"Saving thumbnail to\n{filepath}");
            Console.WriteLine();
            Console.WriteLine("Take a look at it!");
            thumbnail.Save(filepath);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
