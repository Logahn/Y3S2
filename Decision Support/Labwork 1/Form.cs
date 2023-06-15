using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert
{
	public partial class Form1 : Form
	{
		public float[] inter_score= new float[3];
		public float sub_group = 0;
		public float self_score = 0;
		public float qualifier = 0;
		public float professional_competence = 0;
		public void info()
		{
			MessageBox.Show("Данные записаны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
// Calculates the average of an array of floats.
public float CalculateAverage(float[] values)
{
    float sum = 0;

    // Loop through the array and add up all the values.
    for (int i = 0; i < values.Length; i++)
    {
        sum += values[i];
    }

    // Divide the sum by the length of the array to get the average.
    float average = sum / values.Length;

    // Return the average.
    return average;
}

// Prints the current form to the default printer.
private void PrintForm()
{
    // Create a new bitmap with the same dimensions as the form.
    using (var bitmap = new Bitmap(this.Width, this.Height))
    {
        // Draw the form onto the bitmap.
        this.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

        // Create a new PrintDocument object.
        var printDoc = new PrintDocument();

        // Add an event handler to the PrintPage event that draws the bitmap onto the printer graphics.
        printDoc.PrintPage += (s, e) => e.Graphics.DrawImage(bitmap, 0, 0);

        // Send the document to the default printer.
        printDoc.Print();
    }
}

// The constructor for the Form1 class.
public Form1()
{
    // Call the InitializeComponent method to initialize the form components.
    InitializeComponent();
}


// Handles the click event for the beksp button.
private void BekspButton_Click(object sender, EventArgs e)
{
    // If no expert is selected in the combo box, show an error message.
    if (comboBox1.SelectedIndex == -1)
    {
        MessageBox.Show("Выберите эксперта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    // If an expert is selected, show the appropriate group boxes.
    else
    {
        groupBox15.Visible = false;
        bocenkarab.Visible = true;
        bocenkkwa.Visible = true;
        bprofcomp.Visible = true;
        bself_score.Visible = true;
        binter_score
        .Visible = true;
        bres.Visible = true;
    }
}

// Handles the click event for the bprofcomp button.
private void BprofcompButton_Click(object sender, EventArgs e)
{
    // Show the appropriate group boxes.
    groupBox16.Visible = false;
    groupBox7.Visible = false;
    groupBox11.Visible = false;
    groupBox12.Visible = false;
    groupBox13.Visible = false;
    groupBox14.Visible = true;
}

// Handles the click event for the button1 button.
// This method calculates the self-evaluation score based on the selected radio buttons.
private void CalculateSelfEvaluationScore(object sender, EventArgs e)
{
    // Call the info method to populate the expert information.
    info();

    // Initialize the self-evaluation score to 0.
    float selfEvaluationScore = 0;

    // Add points to the score based on the selected radio buttons.
    if (radioButton1.Checked)
    {
        selfEvaluationScore += 1.5f;
    }
    if (radioButton6.Checked)
    {
        selfEvaluationScore += 1.5f;
    }
    if (radioButton9.Checked)
    {
        selfEvaluationScore += 1.5f;
    }
    if (radioButton18.Checked)
    {
        selfEvaluationScore += 1.5f;
    }
    if (radioButton15.Checked)
    {
        selfEvaluationScore += 1.5f;
    }
    if (radioButton12.Checked)
    {
        selfEvaluationScore += 1.5f;
    }
    if (radioButton2.Checked)
    {
        selfEvaluationScore += 0.9f;
    }
    if (radioButton5.Checked)
    {
        selfEvaluationScore += 0.9f;
    }
    if (radioButton8.Checked)
    {
        selfEvaluationScore += 0.9f;
    }
    if (radioButton17.Checked)
    {
        selfEvaluationScore += 0.9f;
    }
    if (radioButton14.Checked)
    {
        selfEvaluationScore += 0.9f;
    }
    if (radioButton11.Checked)
    {
        selfEvaluationScore += 0.9f;
    }
    if (radioButton3.Checked)
    {
        selfEvaluationScore += 0.45f;
    }
    if (radioButton4.Checked)
    {
        selfEvaluationScore += 0.45f;
    }
    if (radioButton7.Checked)
    {
        selfEvaluationScore += 0.45f;
    }
    if (radioButton16.Checked)
    {
        selfEvaluationScore += 0.45f;
    }
    if (radioButton13.Checked)
    {
        selfEvaluationScore += 0.45f;
    }
    if (radioButton10.Checked)
    {
        selfEvaluationScore += 0.45f;
    }

    // Set the self-evaluation score to the calculated value.
    self_score = selfEvaluationScore;
}


// Handles the click event for the bself_score button.
private void Bself_scoreButton_Click(object sender, EventArgs e)
{
    // Show the appropriate group boxes.
    groupBox16.Visible = false;
    groupBox7.Visible = true;
    groupBox11.Visible = false;
    groupBox12.Visible = false;
    groupBox13.Visible = false;
    groupBox14.Visible = false;
}

// Handles the click event for the bocenkarab button.
private void BocenkarabButton_Click(object sender, EventArgs e)
{
    // Show the appropriate group boxes.
    groupBox7.Visible = false;
    groupBox11.Visible = true;
    groupBox12.Visible = false;
    groupBox13.Visible = false;
    groupBox14.Visible = false;
}

// Handles the click event for the button2 button.
// This method calculates the group evaluation score based on the selected radio buttons.
private void CalculateGroupEvaluationScore(object sender, EventArgs e)
{
    // Call the info method to populate the expert information.
    info();

    // Initialize the group evaluation score to 0.
    float groupEvaluationScore = 0;

    // Add points to the score based on the selected radio buttons.
    if (radioButton19.Checked)
    {
        groupEvaluationScore += 3.3f;
    }
    if (radioButton26.Checked)
    {
        groupEvaluationScore += 3.3f;
    }
    if (radioButton30.Checked)
    {
        groupEvaluationScore += 3.3f;
    }
    if (radioButton20.Checked)
    {
        groupEvaluationScore += 2.5f;
    }
    if (radioButton25.Checked)
    {
        groupEvaluationScore += 2.5f;
    }
    if (radioButton29.Checked)
    {
        groupEvaluationScore += 2.5f;
    }
    if (radioButton21.Checked)
    {
        groupEvaluationScore += 1.67f;
    }
    if (radioButton24.Checked)
    {
        groupEvaluationScore += 1.67f;
    }
    if (radioButton28.Checked)
    {
        groupEvaluationScore += 1.67f;
    }
    if (radioButton22.Checked)
    {
        groupEvaluationScore += 1;
    }
    if (radioButton23.Checked)
    {
        groupEvaluationScore += 1;
    }
    if (radioButton27.Checked)
    {
        groupEvaluationScore += 1;
    }

    // Set the group evaluation score to the calculated value.
    sub_group = groupEvaluationScore;
}

// Handles the click event for the binter_score
 button.
private void Binter_score
Button_Click(object sender, EventArgs e)
{
    // Show the appropriate group boxes.
    groupBox16.Visible = false;
    groupBox12.Visible = true;
    groupBox7.Visible = false;
    groupBox11.Visible = false;
    groupBox13.Visible = false;
    groupBox14.Visible = false;

    // Set the appropriate value in the inter_score
     array based on the selected expert.
    if (comboBox1.SelectedIndex == 0)
    {
        label24.Visible = false;
        comboBox2.Visible = false;
        inter_score
        [0] = 0.4f;
    }
    if (comboBox1.SelectedIndex == 1)
    {
        label25.Visible = false;
        comboBox3.Visible = false;
        inter_score
        [1] = 0.4f;
    }
    if (comboBox1.SelectedIndex == 2)
    {
        label26.Visible = false;
        comboBox4.Visible = false;
        inter_score
        [2] = 0.4f;
    }
}

// Handles the click event for the binter_score
 button.
private void Binter_score
Button_Click(object sender, EventArgs e)
{
    // Show the appropriate group boxes.
    groupBox16.Visible = false;
    groupBox12.Visible = true;
    groupBox7.Visible = false;
    groupBox11.Visible = false;
    groupBox13.Visible = false;
    groupBox14.Visible = false;

    // Set the appropriate value in the inter_score
     array based on the selected expert.
    if (comboBox1.SelectedIndex == 0)
    {
        label24.Visible = false;
        comboBox2.Visible = false;
        inter_score
        [0] = 0.4f;
    }
    if (comboBox1.SelectedIndex == 1)
    {
        label25.Visible = false;
        comboBox3.Visible = false;
        inter_score
        [1] = 0.4f;
    }
    if (comboBox1.SelectedIndex == 2)
    {
        label26.Visible = false;
        comboBox4.Visible = false;
        inter_score
        [2] = 0.4f;
    }
}

// Handles the click event for the button3 button.
// This method sets the appropriate value in the inter_score
 array based on the selected combo box values.
private void Setinter_score
Values(object sender, EventArgs e)
{
    // Call the info method to populate the expert information.
    info();

    // Set the appropriate value in the inter_score
     array based on the selected combo box values.
    switch (comboBox2.SelectedIndex)
    {
        case 0: inter_score
        [0] = 2; break;
        case 1: inter_score
        [0] = 1.6f; break;
        case 2: inter_score
        [0] = 1.2f; break;
        case 3: inter_score
        [0] = 0.8f; break;
        case 4: inter_score
        [0] = 0.4f; break;
    }
    switch (comboBox3.SelectedIndex)
    {
        case 0: inter_score
        [1] = 2; break;
        case 1: inter_score
        [1] = 1.6f; break;
        case 2: inter_score
        [1] = 1.2f; break;
        case 3: inter_score
        [1] = 0.8f; break;
        case 4: inter_score
        [1] = 0.4f; break;
    }
    switch (comboBox4.SelectedIndex)
    {
        case 0: inter_score
        [2] = 2; break;
        case 1: inter_score
        [2] = 1.6f; break;
        case 2: inter_score
        [2] = 1.2f; break;
        case 3: inter_score
        [2] = 0.8f; break;
        case 4: inter_score
        [2] = 0.4f; break;
    }
}


		private void bocenkkwa_Click(object sender, EventArgs e)
		{
			groupBox16.Visible = false;
			groupBox13.Visible = true;
			groupBox12.Visible = false;
			groupBox7.Visible = false;
			groupBox11.Visible = false;
			groupBox14.Visible = false;
		}
	

	// Handles the click event for the button4 button.
private void Button4_Click(object sender, EventArgs e)
{
    // Initialize variables.
    double num1 = 0.0;
    double num2 = Convert.ToDouble(this.textBox1.Text) + Convert.ToDouble(this.textBox2.Text) + Convert.ToDouble(this.textBox3.Text) + Convert.ToDouble(this.textBox4.Text);

    // Check if the sum of probabilities is within a valid range.
    if (num2 <= 1.05 && num2 >= 0.95)
    {
        // Calculate the total score based on the user's input.
        double num3 = Convert.ToDouble(this.textBox1.Text) != 0.4 ? (Convert.ToDouble(this.textBox1.Text) != 0.3 && Convert.ToDouble(this.textBox1.Text) != 0.5 ? num1 + 0.0 : num1 + 1.0) : num1 + 2.0;
        double num4 = Convert.ToDouble(this.textBox2.Text) != 0.3 ? (Convert.ToDouble(this.textBox2.Text) != 0.2 && Convert.ToDouble(this.textBox1.Text) != 0.4 ? num3 + 0.0 : num3 + 1.0) : num3 + 2.0;
        double num5 = Convert.ToDouble(this.textBox3.Text) != 0.2 ? (Convert.ToDouble(this.textBox3.Text) != 0.1 && Convert.ToDouble(this.textBox1.Text) != 0.3 ? num4 + 0.0 : num4 + 1.0) : num4 + 2.0;
        double num6 = Convert.ToDouble(this.textBox4.Text) != 0.1 ? (Convert.ToDouble(this.textBox4.Text) != 0.2 ? num5 + 0.0 : num5 + 1.0) : num5 + 2.0;

        // Add bonus points based on the user's selections.
        if (this.comboBox5.SelectedIndex == 0)
            num6 += 1.6;
        if (this.comboBox6.SelectedIndex == 2)
            num6 += 1.6;
        if (this.comboBox7.SelectedIndex == 1)
            num6 += 1.6;
        if (this.comboBox8.SelectedIndex == 3)
            num6 += 1.6;
        if (this.comboBox9.SelectedIndex == 4)
            num6 += 1.6;
        if (this.comboBox14.SelectedIndex == 4)
            num6 += 1.6;
        if (this.comboBox10.SelectedIndex == 3)
            num6 += 1.6;
        if (this.comboBox11.SelectedIndex == 2)
            num6 += 1.6;
        if (this.comboBox12.SelectedIndex == 1)
            num6 += 1.6;
        if (this.comboBox13.SelectedIndex == 0)
            num6 += 1.6;

        // Calculate the qualifier score.
        double qualifier = num6 / 2.4;
        if (qualifier > 10.0)
            qualifier = 10.0;
    }
    else
    {
        // Show an error message if the sum of probabilities is not within the valid range.
        int num9 = (int)MessageBox.Show("Упс! Что-то пошло не так (возможно это вероятности)");
    }

    // Show additional information.
    info();
}

		
		private void button5_Click_1(object sender, EventArgs e)
		{
			professional_competence = 0;
			if (comboBox15.SelectedIndex == -1 || comboBox16.SelectedIndex == -1 || comboBox17.SelectedIndex == -1 || comboBox18.SelectedIndex == -1 ||
							comboBox19.SelectedIndex == -1 || comboBox20.SelectedIndex == -1 || comboBox21.SelectedIndex == -1 || comboBox22.SelectedIndex == -1 ||
							comboBox23.SelectedIndex == -1 || comboBox24.SelectedIndex == -1 || textBox6.Text == "" || textBox7.Text == "" ||
							comboBox26.SelectedIndex == -1 || comboBox27.SelectedIndex == -1 || comboBox28.SelectedIndex == -1)
			{
				MessageBox.Show("Ответьте на все вопросы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				info();
				if (comboBox15.SelectedIndex == 0)//1
				{ professional_competence += 1.5f; }
				if (comboBox16.SelectedIndex == 2)//2
				{ professional_competence += 1.5f; }
				if (comboBox17.SelectedIndex == 0)//3
				{ professional_competence += 1.5f; }
				if (comboBox18.SelectedIndex == 1)//4
				{ professional_competence += 1.5f; }
				if (comboBox19.SelectedIndex == 3)//5
				{ professional_competence += 1.5f; }
				if (comboBox24.SelectedIndex == 2)//6
				{ professional_competence += 1.5f; }
				if (comboBox23.SelectedIndex == 1)//7
				{ professional_competence += 1.5f; }
				if (comboBox22.SelectedIndex == 1)//8
				{ professional_competence += 1.5f; }
				if (comboBox21.SelectedIndex == 2)//9
				{ professional_competence += 1.5f; }
				if (comboBox20.SelectedIndex == 1)//10
				{ professional_competence += 1.5f; }
				if (textBox6.Text == "Компилятор" || textBox6.Text == "компилятор" ||
					textBox6.Text == " Компилятор" || textBox6.Text == " компилятор" ||
					textBox6.Text == "Компилятор " || textBox6.Text == "компилятор ")
				{
					professional_competence += 4;
				}
				if (textBox7.Text == "3")
				{
					professional_competence += 8;
				}
				if (comboBox25.SelectedIndex == 3)
					professional_competence += 1.5f;
				if (comboBox26.SelectedIndex == 1)
					professional_competence += 1.5f;
				if (comboBox27.SelectedIndex == 0)
					professional_competence += 1.5f;
				if (comboBox28.SelectedIndex == 4)
					professional_competence += 1.5f;
			}

		}

// Handles the click event for the bres button.
private void BresButton_Click(object sender, EventArgs e)
{
    // Show the appropriate group boxes.
    groupBox12.Visible = false;
    groupBox7.Visible = false;
    groupBox11.Visible = false;
    groupBox13.Visible = false;
    groupBox14.Visible = false;
    groupBox16.Visible = true;

    // Add the expert information to the text box.
    textBox8.Text += "\r\nЭксперт: " + comboBox1.SelectedItem + "\r\n" +
        "Cамооценка: " + self_score + "\r\n" +
        "Профессиональная пригодность: " + professional_competence + "\r\n" +
        "Этическая гибкость: " + sub_group + "\r\n" +
        "Комвалиметрическая компетентность: " + qualifier + "\r\n" +
        "Взаимооценка: " + srar(inter_score
        );
}

// Handles the click event for the button6 button.
// This method appends the text box content to a file.
private void SaveToFile(object sender, EventArgs e)
{
    using (StreamWriter incdate = File.AppendText(@"result.txt"))
    {
        incdate.WriteLine(textBox8.Text, '\n');
    }
}

// Handles the click event for the button7 button.
private void PrintForm(object sender, EventArgs e)
{
    PrintForm();
}

// Handles the click event for the button8 button.
private void Button8_Click(object sender, EventArgs e)
{
    // Show the appropriate group boxes.
    groupBox12.Visible = false;
    groupBox7.Visible = false;
    groupBox11.Visible = false;
    groupBox13.Visible = false;
    groupBox14.Visible = false;
    groupBox16.Visible = false;
    groupBox15.Visible = true;
}

	}
}