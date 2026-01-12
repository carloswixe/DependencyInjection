namespace OCRTesseract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string pathImage = @"./LICENSE_FRONT.jpeg";
            string path = System.IO.Path.GetFullPath(@"./");
            string text = "";
            try
            {
                using (var engine = new Tesseract.TesseractEngine(@"./tessdata", "spa", Tesseract.EngineMode.TesseractAndLstm))
                {
                    using (var img = Tesseract.Pix.LoadFromFile(pathImage))
                    {
                        using (var page = engine.Process(img))
                        {
                            text = page.GetText();
                            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());
                        }
                    }
                }

            }
            catch (Exception Ex)
            {                
                Console.WriteLine(Ex.Message);
            }
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
