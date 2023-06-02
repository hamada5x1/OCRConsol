using System;
using System.IO;
using Tesseract;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractTextFromImage();
        }

        static void ExtractTextFromImage()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Specify the path to your input image file (JPEG)
            string imagePath = @"..\..\..\ARIMG.jpg";

            // Specify the path to the tessdata folder containing the language data files and font file
            string tessDataPath = Path.GetFullPath(@"..\..\..\tessdata\");

            // Initialize Tesseract engine with the specified languages and tessdata path
            using (var engine = new TesseractEngine(tessDataPath, "ara", EngineMode.Default))
            {
                // Set the page segmentation mode to treat the image as a single text line
                engine.DefaultPageSegMode = PageSegMode.Auto;

                // Load the image using Tesseract Pix
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        // Get the recognized text
                        var recognizedText = page.GetText();

                        // Print the recognized text
                        Console.WriteLine(recognizedText);
                    }
                }
            }
        }
    }
}
