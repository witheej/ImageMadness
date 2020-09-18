using System;
using System.Drawing;
using System.IO;

namespace HiddenImageMadness
{
  class Program
  {
    static void Main(string[] args)
    {
      Image img = System.Drawing.Image.FromFile("Papio-hamadryas-head.jpg");
      float aspectRatio = (float)img.Height / (float)img.Width;
      Image thumbnail = img.GetThumbnailImage(256, (int)(256 * aspectRatio), null, IntPtr.Zero);

      string filepath = Path.GetTempFileName() + ".jpg";
      Console.WriteLine($"Saving thumbnail to {filepath}");
      thumbnail.Save(Path.GetTempFileName() + ".jpg");

      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
