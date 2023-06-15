using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vote_Casting
{
    // Form1 class which represents the main form of the application
    public partial class Form1 : Form
    {
        // Constructor of the Form1 class
        public Form1()
        {
            // InitializeComponent method which initializes the form's components
            InitializeComponent();
        }

        // Click event handler for the button1 control
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the number of candidates to be voted for from the textBox1 control
            int numberOfCandidates = Convert.ToInt32(textBox1.Text);

            // Get the method of voting from the comboBox1 control
            string votingMethod = comboBox1.SelectedItem.ToString();

            // Get the candidate of choice from the comboBox2 control
            string candidateOfChoice = comboBox2.SelectedItem.ToString();

            // Validate the input
            // If the number of candidates is less than or equal to 0, show an error message and return
            if (numberOfCandidates <= 0)
            {
                MessageBox.Show("Количество кандидатов должно быть больше 0.");
                return;
            }

            // Check the voting method and create a new Vote object with the specified parameters
            // Add the vote to the list of votes
            if (votingMethod == "Метод Борда")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else if (votingMethod == "Метод Борда Мод")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else if (votingMethod == "Метод Кондорсе")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else if (votingMethod == "Метод Доджсона")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else if (votingMethod == "Метод Симпсона")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else if (votingMethod == "Метод Нансена")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else if (votingMethod == "Метод Коупленда")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else if (votingMethod == "Метод Фишберна")
            {
                Vote vote = new Vote(numberOfCandidates, votingMethod, candidateOfChoice);
                vote.Add(vote);
            }
            else
            {
                MessageBox.Show("Недопустимый способ голосования.");
                return;
            }

            // Display the result of the vote in the richTextBox1 control
            richTextBox1.Text = Votes.ToString();
        }

        // Click event handler for the button2 control
        private void button2_Click(object sender, EventArgs e)
        {
            // Clear the input fields
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            richTextBox1.Text = "";
        }

        // Click event handler for the button3 control
        private void button3_Click(object sender, EventArgs e)
        {
            // Call the GetResults method to get the results of the vote
            GetResults();
        }

        // Method that gets the results of the vote
       private void GetResults()
{
    // Get the list of candidates from the comboBox1 control
    List<string> candidates = new List<string>();
    for (int i = 0; i < comboBox1.Items.Count; i++)
    {
        candidates.Add(comboBox1.Items[i].ToString());
    }

    // Get the number of votes for each candidate from the list of votes
    Dictionary<string, int> votesPerCandidate = new Dictionary<string, int>();
    for (int i = 0; i < votesPerCandidate.Count; i++)
    {
        // If the candidate is not in the dictionary, add it with a value of 0
        if (!votesPerCandidate.ContainsKey(votes[i].CandidateOfChoice))
        {
            votesPerCandidate.Add(votes[i].CandidateOfChoice, 0);
        }

        // Increment the number of votes for the candidate
        votesPerCandidate[votes[i].CandidateOfChoice]++;
    }

    // Display the results of the vote using a message box
    foreach (var vote in votesPerCandidate)
    {
        MessageBox.Show($"{vote.Key}: {vote.Value}");
    }
}

// Vote class which represents a single vote
public class Vote
{
    // Properties for the number of candidates, voting method, and candidate of choice
    public int NumberOfCandidates { get; set; }
    public string VotingMethod { get; set; }
    public string CandidateOfChoice { get; set; }

    // Constructor for the Vote class
    public Vote(int numberOfCandidates, string votingMethod, string candidateOfChoice)
    {
        NumberOfCandidates = numberOfCandidates;
        VotingMethod = votingMethod;
        CandidateOfChoice = candidateOfChoice;
    }

    // Override the ToString method to display the vote information in a specific format
    public override string ToString()
    {
        return $"{VotingMethod}\n  Кандидат {NumberOfCandidates} набрал {CandidateOfChoice} голосов\n Победивший кандидат {CandidateWithHighestVotes} набрал {CandidateOfChoice} голосов";
    }

    // Method to add a vote to the list of votes (not implemented)
    internal void Add(Vote vote)
    {
        throw new NotImplementedException();
    }

}
