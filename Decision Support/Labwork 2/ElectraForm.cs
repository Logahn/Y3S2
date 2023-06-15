using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Methods
public partial class ElectraForm : Form
{
    // Declare class-level variables
    private string location;
    private int criteriaCount;
    private int alternativesCount;
    private float[] criteriaScores = new float[15];
    private float[] alternativeScores = new float[15];
    private int currentCriteriaIndex = 0;

    // Constructor to initialize form and assign location parameter
    public ElectraForm(string location)
    {
        InitializeComponent();
        this.location = location;
    }

    private void ShowCriteriaAndAlternatives(object sender, EventArgs e)
    {
        // Check if criteria and alternative counts are valid, then show them in data grids
        if (string.IsNullOrEmpty(criteriaTextBox.Text) || string.IsNullOrEmpty(alternativesTextBox.Text))
        {
            MessageBox.Show("Please enter values for both fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            criteriaCount = Convert.ToInt32(criteriaTextBox.Text);
            alternativesCount = Convert.ToInt32(alternativesTextBox.Text);

            for (int i = 0; i < criteriaCount; i++)
            {
                criteriaDataGridView.Rows.Add();
                criteriaDataGridView.Rows[i].Cells[0].Value = "Criteria " + (i + 1);
            }

            for (int i = 0; i < alternativesCount; i++)
            {
                alternativesDataGridView.Rows.Add();
                alternativesDataGridView.Rows[i].Cells[0].Value = "Alternative " + (i + 1);
            }

            criteriaGroupBox.Visible = true;
        }
    }

    private void RecordCriteriaScores(object sender, EventArgs e)
    {
        // Record criteria scores to array
        for (int i = 0; i < criteriaCount; i++)
        {
            criteriaScores[i] = Convert.ToSingle(criteriaDataGridView.Rows[i].Cells[1].Value);
        }

        alternativesGroupBox.Visible = true;
    }

    private void RecordAlternativeScores(object sender, EventArgs e)
    {
        // Record alternative scores to array
        for (int i = 0; i < alternativesCount; i++)
        {
            alternativeScores[i] += Convert.ToSingle(alternativesDataGridView.Rows[i].Cells[1].Value) / criteriaScores[currentCriteriaIndex];
        }

        currentCriteriaIndex++;

        // Enable/disable buttons based on current criteria
        if (currentCriteriaIndex == criteriaCount - 1)
        {
            nextCriteriaButton.Visible = false;
            finishButton.Visible = true;
        }
        else
        {
            ClearAlternativeScores();
            criteriaLabel.Text = "Criteria " + (currentCriteriaIndex + 1);
        }
    }

    private void FinishAndCalculateScores(object sender, EventArgs e)
    {
        // Record final alternative scores to array, then show results form
        for (int i = 0; i < alternativesCount; i++)
        {
            alternativeScores[i] += Convert.ToSingle(alternativesDataGridView.Rows[i].Cells[1].Value) / criteriaScores[currentCriteriaIndex];
        }

        ResultForm resultForm = new ResultForm(alternativeScores, location, alternativesCount, criteriaCount, "Electricity");
        resultForm.Left = this.Left;
        resultForm.Top = this.Top;
        resultForm.Show();
    }

    private void ClearAlternativeScores()
    {
        // Clear alternative scores to prepare for next criteria
        for (int i = 0; i < alternativesCount; i++)
        {
            alternativesDataGridView.Rows[i].Cells[1].Value = 0;
        }
    }
}