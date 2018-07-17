using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TheApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openFileDialog.FileName);

                Predictor predictor = new Predictor();
                var prediction = predictor.PredictImage(File.ReadAllBytes(openFileDialog.FileName));

                dogProbability.Text = $"Dog {prediction.dogProbability.ToString("p")}";
                catProbability.Text = $"Cat {prediction.catProbability.ToString("p")}";
            }
        }
    }
}
