using ModelInferenceLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TheApp
{
    public partial class Form1 : Form
    {
        private readonly Model _model;
        private Dictionary<string, int> _word2Index;
        private Dictionary<int, string> _index2Word;
        private const int SequenceLength = 20;
        public Form1()
        {
            InitializeComponent();

            _model = new Model();
            LoadDictionaries();
        }

        private void LoadDictionaries()
        {
            _word2Index = File.ReadAllLines("word2index.csv")
                .Select(x => x.Split(','))
                .ToDictionary(x => x[0], x => int.Parse(x[1]));

            _index2Word = File.ReadAllLines("index2word.csv")
                .Select(x => x.Split(','))
                .ToDictionary(x => int.Parse(x[0]), x => x[1]);
        }

        private string[] DataWords => txtData.Text.Split(' ');
        private void txtData_TextChanged(object sender, EventArgs e)
        {
            if (DataWords.Length < SequenceLength || !txtData.Text.EndsWith(" "))
                return;

            var seed = DataWords.Select(x => x.ToLower()).Skip(DataWords.Length - SequenceLength);

            var inputData = seed
                .Select(x => _word2Index.ContainsKey(x) ? (float)_word2Index[x] : 0)
                .ToList();

            var prediction = _model.Predict(new List<List<float>> { inputData })
                .Single()
                .ToList();

            var wordsWithProbabilites = prediction
                .Select((x, index) => new { Probability = x, Word = index == 0 ? "UNKOWN" : _index2Word[index] })
                .OrderByDescending(x => x.Probability)
                .ToList();


            btnOptionA.Text = wordsWithProbabilites[0].Word;
            btnOptionB.Text = wordsWithProbabilites[1].Word;
            btnOptionC.Text = wordsWithProbabilites[2].Word;
        }

        private void btnOptionA_Click(object sender, EventArgs e)
        {
            txtData.Text += $"{btnOptionA.Text} ";
        }

        private void btnOptionB_Click(object sender, EventArgs e)
        {
            txtData.Text += $"{btnOptionB.Text} ";
        }

        private void btnOptionC_Click(object sender, EventArgs e)
        {
            txtData.Text += $"{btnOptionC.Text} ";
        }
    }

}
