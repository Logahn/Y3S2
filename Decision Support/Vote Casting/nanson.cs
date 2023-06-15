using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NansonMethod
{
    public partial class Form1 : Form
    {
        // List to store the candidates
        private List<string> candidates = new List<string>();

        // 2D array to store the pairwise comparison results
        private int[,] pairwiseResults;

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

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            // Add the new candidate to the list box and the candidates list
            string newCandidate = txtNewCandidate.Text;
            listBoxCandidates.Items.Add(newCandidate);
            candidates.Add(newCandidate);

            // Resize the pairwise results array to accommodate the new candidate
            ResizePairwiseResults();

            // Clear the new candidate text box
            txtNewCandidate.Text = "";
        }

        private void ResizePairwiseResults()
        {
            // Get the current size of the pairwise results array
            int currentSize = pairwiseResults?.GetLength(0) ?? 0;

            // Create a new array with the new size
            int[,] newPairwiseResults = new int[currentSize + 1, currentSize + 1];

            // Copy the values from the old array to the new array
            for (int i = 0; i < currentSize; i++)
            {
                for (int j = 0; j < currentSize; j++)
                {
                    newPairwiseResults[i, j] = pairwiseResults[i, j];
                }
            }

            // Set the new array as the pairwise results array
            pairwiseResults = newPairwiseResults;
        }

        private void btnAddResult_Click(object sender, EventArgs e)
        {
            // Get the selected candidates and their comparison result
            string candidateA = listBoxCandidates.SelectedItem.ToString();
            string candidateB = listBoxPairwiseCandidates.SelectedItem.ToString();
            int result = (int)numericUpDownResult.Value;

            // Add the comparison result to the pairwise results array
            int indexA = candidates.IndexOf(candidateA);
            int indexB = candidates.IndexOf(candidateB);
            pairwiseResults[indexA, indexB] = result;

            // Clear the selected candidates and result
            listBoxCandidates.ClearSelected();
            listBoxPairwiseCandidates.ClearSelected();
            numericUpDownResult.Value = 0;

            // Check if all pairwise comparisons have been made
            if (AllPairwiseComparisonsMade())
            {
                // Use the pairwise results to calculate the Nanson winner
                string nansonWinner = CalculateNansonWinner();

                // Display the Nanson winner in a message box
                MessageBox.Show($"The Nanson winner is {nansonWinner}");
            }
        }

        private bool AllPairwiseComparisonsMade()
        {
            // Check if all pairwise comparisons have been made
            for (int i = 0; i < pairwiseResults.GetLength(0); i++)
            {
                for (int j = i + 1; j < pairwiseResults.GetLength(1); j++)
                {
                    if (pairwiseResults[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string CalculateNansonWinner()
        {
            // Create a list of candidates and their scores
            List<KeyValuePair<string, int>> candidateScores = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < candidates.Count; i++)
            {
                int score = 0;

                for (int j = 0;
                for (int j = 0; j < candidates.Count; j++)
                {
                    if (i != j)
                    {
                        if (pairwiseResults[i, j] > pairwiseResults[j, i])
                        {
                            score++;
                        }
                    }
                }

                candidateScores.Add(new KeyValuePair<string, int>(candidates[i], score));
            }

            // Sort the candidates by their scores
            var sortedCandidates = candidateScores.OrderByDescending(x => x.Value);

            // Determine the minimum score required to win
            int minScoreToWin = sortedCandidates.Last().Value;

            // Create a list of candidates with the minimum score
            List<string> minScoreCandidates = new List<string>();

            foreach (var candidate in sortedCandidates)
            {
                if (candidate.Value == minScoreToWin)
                {
                    minScoreCandidates.Add(candidate.Key);
                }
                else
                {
                    break;
                }
            }

            // Check if there is only one candidate with the minimum score
            if (minScoreCandidates.Count == 1)
            {
                return minScoreCandidates[0];
            }
            else
            {
                // Remove the candidate(s) with the fewest first-choice votes
                foreach (var candidate in minScoreCandidates)
                {
                    int index = candidates.IndexOf(candidate);

                    for (int i = 0; i < candidates.Count; i++)
                    {
                        if (pairwiseResults[index, i] > pairwiseResults[i, index])
                        {
                            candidateScores.First(x => x.Key == candidates[i]).Value--;
                        }
                    }
                }

                var remainingCandidates = candidateScores.Where(x => minScoreCandidates.Contains(x.Key) == false);
                var remainingSortedCandidates = remainingCandidates.OrderByDescending(x => x.Value);

                return remainingSortedCandidates.First().Key;
            }
        }
    }
}
