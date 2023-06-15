using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CopelandsMethod
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
                // Use the pairwise results to calculate the Copeland winner
                string copelandWinner = CalculateCopelandWinner();

                // Display the Copeland winner in a message box
                MessageBox.Show($"The Copeland winner is {copelandWinner}");
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

        private string CalculateCopelandWinner()
        {
            // Create a dictionary to store the candidates and their Copeland scores
            Dictionary<string, int> candidateScores = new Dictionary<string, int>();

            // Calculate the Copeland score for each candidate
            for (int i = 0; i < candidates.Count; i++)
            {
                int
                for (int j = 0; j < candidates.Count; j++)
                {
                    if (i != j)
                    {
                        int result = pairwiseResults[i, j] - pairwiseResults[j, i];

                        if (result > 0)
                        {
                            candidateScores[candidates[i]]++;
                        }
                        else if (result < 0)
                        {
                            candidateScores[candidates[j]]++;
                        }
                    }
                }
            }

            // Sort the candidates by their Copeland scores
            var sortedCandidates = candidateScores.OrderByDescending(x => x.Value);

            // Determine the maximum Copeland score
            int maxScore = sortedCandidates.First().Value;

            // Create a list of candidates with the maximum Copeland score
            List<string> maxScoreCandidates = new List<string>();

            foreach (var candidate in sortedCandidates)
            {
                if (candidate.Value == maxScore)
                {
                    maxScoreCandidates.Add(candidate.Key);
                }
                else
                {
                    break;
                }
            }

            // Check if there is only one candidate with the maximum Copeland score
            if (maxScoreCandidates.Count == 1)
            {
                return maxScoreCandidates[0];
            }
            else
            {
                // Use the pairwise comparison results to determine the winner
                int[,] pairwiseScores = new int[candidates.Count, candidates.Count];

                for (int i = 0; i < candidates.Count; i++)
                {
                    for (int j = 0; j < candidates.Count; j++)
                    {
                        if (i != j)
                        {
                            int result = pairwiseResults[i, j] - pairwiseResults[j, i];

                            if (result > 0)
                            {
                                pairwiseScores[i, j]++;
                            }
                            else if (result < 0)
                            {
                                pairwiseScores[j, i]++;
                            }
                        }
                    }
                }

                // Calculate the pairwise scores for the candidates with the maximum Copeland score
                Dictionary<string, int> maxScorePairwiseScores = new Dictionary<string, int>();

                foreach (var candidate in maxScoreCandidates)
                {
                    int index = candidates.IndexOf(candidate);
                    int pairwiseScore = 0;

                    for (int i = 0; i < candidates.Count; i++)
                    {
                        if (i != index)
                        {
                            pairwiseScore += pairwiseScores[index, i];
                        }
                    }

                    maxScorePairwiseScores.Add(candidate, pairwiseScore);
                }

                // Sort the candidates with the maximum Copeland score by their pairwise scores
                var sortedMaxScoreCandidates = maxScorePairwiseScores.OrderByDescending(x => x.Value);

                return sortedMaxScoreCandidates.First().Key;
            }
        }
    }
}
