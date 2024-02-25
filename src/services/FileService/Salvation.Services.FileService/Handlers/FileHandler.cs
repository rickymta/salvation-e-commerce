using static System.Net.Mime.MediaTypeNames;

namespace Salvation.Services.FileService.Handlers;

public class FileHandler
{
    public static void SaveBase64StringAsImage(string base64String, string outputPath)
    {
        try
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                if (!File.Exists(outputPath))
                {
                    File.Create(outputPath);
                }

                using var fs = new FileStream(outputPath, FileMode.Create);
                ms.WriteTo(fs);
            }

            Console.WriteLine("Image saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    //private static void SaveByteArrayAsImage(string fullOutputPath, string base64String)
    //{
    //    byte[] bytes = Convert.FromBase64String(base64String);

    //    Image image;
    //    using (MemoryStream ms = new MemoryStream(bytes))
    //    {
    //        image = Image.FromStream(ms);
    //    }

    //    image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Png);
    //}
}
