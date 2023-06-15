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
    public partial class MSIForm : Form
    {
        // Declaring private variables for the decision unit, method, criteria count, alternative count, criteria array, alternative array, and criteria index
        private string _decisionUnit;
        private readonly string _method = "MSI";
        private int _criteriaCount;
        private int _alternativeCount;
        private readonly float[] _criteriaArray = new float[15];
        private readonly float[] _alternativeArray = new float[15];
        private int _criteriaIndex = 0;

        // Defining a public constructor that takes in a decision unit
        public MSIForm(string decisionUnit)
        {
            InitializeComponent();
            _decisionUnit = decisionUnit;
        }

        // Event handler for when the CalculateButton is clicked
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (CriteriaTextBox.Text == "" || AlternativeTextBox.Text == "")
            {
                // Displaying an error message if the user did not enter all values
                MessageBox.Show("Введите все значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CriteriaGroupBox.Visible = true;
                _criteriaCount = Convert.ToInt32(CriteriaTextBox.Text);
                _alternativeCount = Convert.ToInt32(AlternativeTextBox.Text);

                // Adding rows to CriteriaDataGridView and AlternativeDataGridView with the appropriate names
                for (int i = 0; i < _criteriaCount; i++)
                {
                    CriteriaDataGridView.Rows.Add();
                    CriteriaDataGridView.Rows[i].Cells[0].Value = "Критерий " + (i + 1);
                }

                for (int i = 0; i < _alternativeCount; i++)
                {
                    AlternativeDataGridView.Rows.Add();
                    AlternativeDataGridView.Rows[i].Cells[0].Value = "Альтернатива " + (i + 1);
                }

            }
        }

        // Event handler for the CriteriaNextButton
        private void CriteriaNextButton_Click(object sender, EventArgs e)
        {
            // Populating the _criteriaArray with the values entered in CriteriaDataGridView
            for (int i = 0; i < _criteriaCount; i++)
            {
                _criteriaArray[i] = Convert.ToInt32(CriteriaDataGridView.Rows[i].Cells[1].Value);
            }
            AlternativeGroupBox.Visible = true;
        }

        // Event handler for the CalculateButton in the AlternativeGroupBox
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            // Calculating the weighted sum of each alternative based on the criteria values and adding it to the _alternativeArray
            for (int i = 0; i < _alternativeCount; i++)
            {
                _alternativeArray[i] += Convert.ToInt32(AlternativeDataGridView.Rows[i].Cells[1].Value) * _criteriaArray[_criteriaIndex];
            }

            _criteriaIndex++;

            // Clearing the values in AlternativeDataGridView and updating the CriteriaLabel
            for (int i = 0; i < _alternativeCount; i++)
            {
                AlternativeDataGridView.Rows[i].Cells[1].Value = " ";
            }

            CriteriaLabel.Text = "Критерия " + (_criteriaIndex + 1);

            if (_criteriaIndex == _criteriaCount - 1)
            {
                // Hiding the CalculateButton and showing the FinishButton when all criteria have been evaluated
                CalculateButton.Visible = false;
                FinishButton.Visible = true;
            }
        }

        // Event handler for the FinishButton
        private void FinishButton_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < _alternativeCount; i++)
        {
            _alternativeArray[i] += Convert.ToInt32(AlternativeDataGridView.Rows[i].Cells[1].Value) * _criteriaArray[_criteriaIndex];
        }
        ResultButton.Visible = true;
    }

    private void ResultButton_Click(object sender, EventArgs e)
    {
        Form resultForm = new ResultForm(_alternativeArray, _decisionUnit, _alternativeCount, _criteriaCount, _method);
        resultForm.Left = this.Left;
        resultForm.Top = this.Top;
        resultForm.Show();
    }
}
