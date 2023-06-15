using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BordaCount
{
    public partial class Form1 : Form
    {
        // Dictionary to store the candidates and their scores
        private Dictionary<string, int> candidateScores = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add some sample candidates to the list box
            listBoxCandidates.Items.Add("Candidate A");
            listBoxCandidates.Items.Add("Candidate B");
            listBoxCandidates.Items.Add("Candidate C");
        }

        private void btnAddVote_Click(object sender, EventArgs e)
        {
            // Get the selected candidate and their score
            string selectedCandidate = listBoxCandidates.SelectedItem.ToString();
            int score = (int)numericUpDownScore.Value;

            // Add the score to the candidate's total score
            if (!candidateScores.ContainsKey(selectedCandidate))
            {
                candidateScores.Add(selectedCandidate, 0);
            }

            candidateScores[selectedCandidate] += score;

            // Clear the selected candidate and score
            listBoxCandidates.ClearSelected();
            numericUpDownScore.Value = 0;

            // Update the candidate scores in the results list box
            UpdateResults();
        }

        private void UpdateResults()
        {
            // Sort the candidates by their score
            var sortedCandidates = candidateScores.OrderByDescending(x => x.Value);

            // Clear the results list box
            listBoxResults.Items.Clear();

            // Add each candidate and their score to the results list box
            foreach (var candidate in sortedCandidates)
            {
                listBoxResults.Items.Add($"{candidate.Key}: {candidate.Value}");
            }
        }
    }
}
