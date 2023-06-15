using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FishburnsMethod
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
                // Use the pairwise results to calculate the Fishburn winner
                string fishburnWinner = CalculateFishburnWinner();

                // Display the Fishburn winner in a message box
                MessageBox.Show($"The Fishburn winner is {fishburnWinner}");
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

        private string CalculateFishburnWinner()
        {
            // Create a list of all possible candidate orders
            List<List<string>> candidateOrders = GenerateCandidateOrders();

            // Calculate the Fishburn score for each candidate order
            Dictionary<List<string>, int> orderScores = new Dictionary<List<string>, int>();

            foreach (var order in candidateOrders)
        // Sort the candidate orders by their Fishburn scores
        var sortedOrders = orderScores.OrderByDescending(x => x.Value);

        // Determine the maximum Fishburn score
        int maxScore = sortedOrders.First().Value;

        // Create a list of candidate orders with the maximum Fishburn score
        List<List<string>> maxScoreOrders = new List<List<string>>();

        foreach (var order in sortedOrders)
        {
            if (order.Value == maxScore)
            {
                maxScoreOrders.Add(order.Key);
            }
            else
            {
                break;
            }
        }

        // Check if there is only one candidate order with the maximum Fishburn score
        if (maxScoreOrders.Count == 1)
        {
            return String.Join(" > ", maxScoreOrders[0]);
        }
        else
        {
            // Use the pairwise comparison results to determine the winner
            int[,] pairwiseScores = new int[candidates.Count, candidates.Count];

            foreach (var order in maxScoreOrders)
            {
                for (int i = 0; i < candidates.Count; i++)
                {
                    for (int j = i + 1; j < candidates.Count; j++)
                    {
                        int indexA = order.IndexOf(candidates[i]);
                        int indexB = order.IndexOf(candidates[j]);

                        int result = pairwiseResults[indexA, indexB] - pairwiseResults[indexB, indexA];

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

            // Calculate the pairwise scores for each candidate
            Dictionary<string, int> candidateScores = new Dictionary<string, int>();

            for (int i = 0; i < candidates.Count; i++)
            {
                int score = 0;

                for (int j = 0; j < candidates.Count; j++)
                {
                    if (i != j)
                    {
                        score += pairwiseScores[i, j];
                    }
                }

                candidateScores.Add(candidates[i], score);
            }

            // Sort the candidates by their pairwise scores
            var sortedCandidates = candidateScores.OrderByDescending(x => x.Value);

            return sortedCandidates.First().Key;
        }
    }

    private List<List<string>> GenerateCandidateOrders()
    {
        // Create a list of all possible candidate orders
        List<List<string>> candidateOrders = new List<List<string>>();

        foreach (var candidate in candidates)
        {
            List<List<string>> newOrders = new List<List<string>>();

            foreach (var order in candidateOrders)
            {
                for (int i = 0; i <= order.Count; i++)
                {
                    List<string> newOrder = new List<string>(order);
                    newOrder.Insert(i, candidate);
                    newOrders.Add(newOrder);
                }
            }

            candidateOrders.AddRange(newOrders);

            if (candidateOrders.Count == 0)
            {
                candidateOrders.Add(new List<string>() { candidate });
            }
        }

        return candidateOrders;
    }

    private int CalculateFishburnScore(List<string> order)
    {
        // Calculate the Fishburn score for the given candidate order
        int score = 0;

        for (int i = 0; i < candidates.Count; i++)
        {
            for (int j = i + 1; j < candidates.Count; j++)
            {
                int indexA = order.IndexOf(candidates[i]);
                int indexB = order.IndexOf(candidates[j]);

                int result = pairwiseResults[indexA, indexB] - pairwiseResults[indexB, indexA];

                if (result > 0)
                {
                    score++;
                }
            }
        }

        return score;
    }
}
