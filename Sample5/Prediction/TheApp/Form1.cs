using ImageProcessor;
using ModelInferenceLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TheApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var url = txtImageUrl.Text;
            var imageFilePath = Path.GetTempFileName();

            DownloadImage(url, imageFilePath);

            ResizeImage(imageFilePath);

            using (var bitmap = new Bitmap(imageFilePath))
            {
                var model = new Model();
                var data = ExtractCHW(bitmap);
                var result = model.Evaluate(new List<List<float>> { data })
                    .ToList()[0]
                    .ToList();

                var parsedResponse = new YoloResponse(result);
                RenderResult(imageFilePath, parsedResponse);
            }
        }

        private static void DownloadImage(string url, string imageFilePath)
        {
            using (var wc = new WebClient())
            {
                wc.DownloadFile(url, imageFilePath);
            }
        }

        private static void ResizeImage(string imageFilePath)
        {
            using (var factory = new ImageFactory())
            {
                factory.Load(imageFilePath);

                var originalWidth = factory.Image.Width;
                var originalHeight = factory.Image.Height;

                var imageWidth = 416;
                var imageHeight = 416;
                using (var resizedImage = factory.Resize(new Size(imageWidth, imageHeight)))
                {
                    resizedImage.Save(imageFilePath);
                }
            }
        }

        private void RenderResult(string imageFilePath, YoloResponse parsedResponse)
        {
            var topObjectsFound = parsedResponse.GetTopObjectsDetected(20);

            Image image = Image.FromFile(imageFilePath);

            var builder = new StringBuilder();
            var random = new Random();

            using (Graphics g = Graphics.FromImage(image))
            {
                topObjectsFound
                   .ForEach(a =>
                   {
                       Color customColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                       var pen = new Pen(customColor, 2);
                       // IMPORTANT
                       var x = a.X - a.Width / 2;
                       var y = a.Y - a.Height / 2;

                       builder.AppendLine($"{a.ObjectLabel} with confidence {a.Confidence:p}. Position : x = {a.X}, y = {a.Y}");
                       g.DrawRectangle(pen, x, y, a.Width, a.Height);

                       var brush = new SolidBrush(Color.Yellow);
                       var font = new Font(FontFamily.GenericSansSerif, 4, FontStyle.Bold);
                       g.DrawString(a.ObjectLabel, font, brush, x, y-20);

                       g.DrawString("X", font, new SolidBrush(customColor), a.X, a.Y);
                   });

                txtResults.Text = builder.ToString();
                pictureBox.Image = image;
            }
        }

        public List<float> ExtractCHW(Bitmap image)
        {
            var features = new List<float>(image.Width * image.Height * 3);
            for (var c = 0; c < 3; c++)
            {
                for (var h = 0; h < image.Height; h++)
                {
                    for (var w = 0; w < image.Width; w++)
                    {
                        // IMPORTANT
                        var pixel = image.GetPixel(w, h);
                        float v = c == 0 ? pixel.R : c == 1 ? pixel.G : pixel.B;
                        features.Add(v);
                    }
                }
            }

            return features;
        }
    }
}
