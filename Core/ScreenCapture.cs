using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Tesseract;

namespace ScreenCapture
{
    public class Core
    {
        public Bitmap CaptureScreen()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            return bitmap;
        }

        public string PerformOCR(Bitmap image)
        {
            using (var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default))
            {
                using (var page = engine.Process(image))
                {
                    return page.GetText();
                }
            }
        }

        public void CaptureAndRecognize()
        {
            Bitmap screenshot = CaptureScreen();
            string text = PerformOCR(screenshot);
            Console.WriteLine(text);
        }
    }
}