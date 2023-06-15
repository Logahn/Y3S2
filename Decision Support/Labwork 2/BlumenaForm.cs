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
    public partial class BlumForm : Form
    {
        // Declaring private variables for the selection name, criteria values, alternative values, current criterion index, and criteria sum
        private string _selectionName;
        private readonly List<float> _criteriaValues = new List<float>();
        private readonly List<List<float>> _alternativeValues = new List<List<float>>();
        private int _currentCriterionIndex = 0;
        private float _criteriaSum = 0;

        // Defining a public constructor that takes in a selection name
        public BlumForm(string selectionName)
        {
            InitializeComponent();
            _selectionName = selectionName;
        }

        // Method to add rows to the CriteriaTable
        private void AddCriterionRows()
        {
            for (int i = 0; i < CriteriaCountInput.Value; i++)
            {
                CriteriaTable.Rows.Add("Критерий " + (i + 1));
            }
        }

        // Method to add rows to the AlternativesTable
        private void AddAlternativeRows()
        {
            for (int i = 0; i < AlternativesCountInput.Value; i++)
            {
                // Creating a new row with default values and adding it to the _alternativeValues list
                var row = new List<float>(CriteriaCountInput.Value);
                for (int j = 0; j < CriteriaCountInput.Value; j++)
                {
                    row.Add(0);
                }
                _alternativeValues.Add(row);
                // Adding a new row to the AlternativesTable with the appropriate name
                AlternativesTable.Rows.Add("Альтернатива " + (i + 1));
            }
        }

        // Method to calculate the sum of the criteria values
        private void CalculateCriteriaSum()
        {
            _criteriaSum = _criteriaValues.Sum();
        }

        // Method to calculate the value of each alternative based on the criteria values
        private void CalculateAlternativesValues()
        {
            for (int i = 0; i < _alternativeValues.Count; i++)
            {
                var alt = _alternativeValues[i];
                float sum = 0;
                for (int j = 0; j < alt.Count; j++)
                {
                    sum += alt[j] * _criteriaValues[j];
                }
                _alternativeValues[i] = new List<float>{sum};
                AlternativesTable.Rows[i].Cells[1].Value = sum;
            }
        }

        // Event handler for when the CriteriaCountInput value changes
        private void CriteriaCountInput_ValueChanged(object sender, EventArgs e)
        {
            CriteriaTable.Rows.Clear();
            _criteriaValues.Clear();
            AddCriterionRows();
        }

        // Event handler for when the AlternativesCountInput value changes
        private void AlternativesCountInput_ValueChanged(object sender, EventArgs e)
        {
            AlternativesTable.Rows.Clear();
            _alternativeValues.Clear();
            AddAlternativeRows();
        }

        // Event handler for when the CriteriaSubmitButton is clicked
        private void CriteriaSubmitButton_Click(object sender, EventArgs e)
        {
            // Populating the _criteriaValues list with the values entered in CriteriaTable
            foreach (DataGridViewRow row in CriteriaTable.Rows)
            {
                float value;
                if (float.TryParse(row.Cells[1].Value.ToString(), out value))
                {
                    _criteriaValues.Add(value);
                }
                else
                {
                    // Displaying an error message if a non-numeric value is entered
                    MessageBox.Show("Введите числовое значение", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        if (_currentCriterionIndex < CriteriaCountInput.Value - 1)
        {
            _currentCriterionIndex++;
            AlternativesTable.Columns[1].HeaderText = $"значение ({_currentCriterionIndex + 1} критерий)";
        }
        else
        {
            AlternativesGroupBox.Enabled = false;
            ResultsGroupBox.Enabled = true;
        }

        CalculateAlternativesValues();
    }

    private void ResultsButton_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < _alternativeValues.Count; i++)
        {
            _alternativeValues[i][0] /= _criteriaSum;
        }

        var resultForm = new ResultsForm(_alternativeValues.Select(x => x[0]).ToArray(),
                                         _selectionName,
                                         Convert.ToInt32(AlternativesCountInput.Value),
                                         Convert.ToInt32(CriteriaCountInput.Value),
                                         "Блюмена");
        resultForm.Left = Left;
        resultForm.Top = Top;
        resultForm.Show();
        Close();
    }
}