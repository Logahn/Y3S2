// Importing necessary libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Creating a namespace
namespace Methods
{
    // Defining a partial class that extends the Form class
    public partial class MAIForm : Form
    {
        // Declaring a private variable for the selected MAI option
        private string selectedOption;

        // Defining a public constructor that takes in a selected MAI option
        public MAIForm(string option)
        {
            InitializeComponent();
            this.selectedOption = option;
        }

        private void MAIForm_Load(object sender, EventArgs e)
        {

        }

        // Declaring public variables for the method name, criteria count, and alternative count
        public string methodName = "МАИ";
        public int criteriaCount;
        public int alternativeCount;

        // Declaring private variables for the criteria values, alternative values, and criteria index
        float[] criteriaValues = new float[15];
        float[] alternativeValues = new float[15];
        int criteriaIndex = 0;

        // Event handler for the AddCriteriaAndAlternatives button
        private void AddCriteriaAndAlternatives_Click(object sender, EventArgs e)
        {
            if (criteriaTextBox.Text == "" || alternativesTextBox.Text == "")
            {
                // Displaying an error message if the user did not enter all values
                MessageBox.Show("Please enter all values", "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
            }
            else
            {
                groupBox1.Visible = true;
                criteriaCount = Convert.ToInt32(criteriaTextBox.Text);
                alternativeCount = Convert.ToInt32(alternativesTextBox.Text);

                // Adding rows to CriteriaGridView and AlternativeGridView with the appropriate names
                for (int i = 0; i < criteriaCount; i++)
                {
                    criteriaGridView.Rows.Add();
                    criteriaGridView.Rows[i].Cells[0].Value = "Criteria " + (i + 1);
                }

                for (int i = 0; i < alternativeCount; i++)
                {
                    alternativeGridView.Rows.Add();
                    alternativeGridView.Rows[i].Cells[0].Value = "Alternative " + (i + 1);
                }
            }
        }

        // Event handler for the CalculateCriteriaValues button
        private void CalculateCriteriaValues_Click(object sender, EventArgs e)
        {
            // Calculating the criteria values based on the values entered in CriteriaGridView and the MAI formula
            for (int i = 0; i < criteriaCount; i++)
            {
                criteriaValues[i] = (float)Math.Exp(0.7 * Convert.ToInt32(criteriaGridView.Rows[i].Cells[1].Value));
            }
            groupBox2.Visible = true;
        }

        // Event handler for the CalculateAlternativesValues button
        private void CalculateAlternativesValues_Click(object sender, EventArgs e)
        {
            // Calculating the alternative values based on the values entered in AlternativeGridView, the criteria values, and the MAI formula
            for (int i = 0; i < alternativeCount; i++)
            {
                alternativeValues[i] += (float)Math.Exp(0.7 * (Convert.ToInt32(alternativeGridView.Rows[i].Cells[1].Value) / 
                criteriaValues[criteriaIndex]));
            }

            criteriaIndex++;

            // Clearing the values in AlternativeGridView and updating the CriteriaLabel
            for (int i = 0; i < alternativeCount; i++)
            {
                alternativeGridView.Rows[i].Cells[1].Value = "";
            }

            criteriaLabel.Text = "Criteria " + (criteriaIndex + 1);

            if (criteriaIndex == criteriaCount - 1)
            {
                // Hiding the CalculateAlternativesButton and showing the ShowResultsButton when all

            CalculateAlternativesButton.Visible = false;
            ShowResultsButton.Visible = true;
        }
    }

    private void ShowResults_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < alternativeCount; i++)
        {
            alternativeValues[i] += (float)Math.Exp(0.7 * (Convert.ToInt32(alternativeGridView.Rows[i].Cells[1].Value) / 
            criteriaValues[criteriaIndex]));
        }

        ResultForm resultForm = new ResultForm(alternativeValues, selectedOption, alternativeCount, criteriaCount, methodName);
        resultForm.Left = this.Left;
        resultForm.Top = this.Top;
        resultForm.Show();
    }
}
