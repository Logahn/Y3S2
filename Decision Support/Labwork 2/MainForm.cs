// Importing necessary libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Creating a namespace
namespace Methods 
{
    // Defining a partial class that extends the Form class
    public partial class MainForm : Form 
    {
        public MainForm() 
        { 
            InitializeComponent(); 
        }

        /// <summary>
        /// Opens a form for the selected subject with the given choice.
        /// </summary>
        /// <param name="choice">The user's choice for the subject.</param>
        private void OpenSubjectForm(string choice)
        {
            if (string.IsNullOrWhiteSpace(choice))
            {
                // Displaying an error message if the user did not enter a choice
                MessageBox.Show("Введите все значения", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int selectedIndex = comboBoxSubjects.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < comboBoxSubjects.Items.Count)
            {
                string subject = comboBoxSubjects.Items[selectedIndex] as string;
                if (!string.IsNullOrWhiteSpace(subject))
                {
                    // Creating a new form for the selected subject and choice, and displaying it
                    Form form;
                    switch (subject)
                    {
                        case "Электра":
                            form = new ElectronForm(choice);
                            break;
                        case "МАИ":
                            form = new MaiForm(choice);
                            break;
                        case "МСИ":
                            form = new MsiForm(choice);
                            break;
                        case "Блюм":
                            form = new BlumForm(choice);
                            break;
                        default:
                            // Displaying an error message if the selected subject is not recognized
                            MessageBox.Show("Неизвестный предмет", "Ошибка", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    form.StartPosition = FormStartPosition.Manual; // Optional: set the form's start position
                    form.Location = Location; // Pass the location of this form to the new form
                    form.Show();
                }
            }
        }

        // Event handler for the Open button
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenSubjectForm(textBoxChoice.Text);
        }
    }
}
