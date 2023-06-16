using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LR_2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "")
			{
				MessageBox.Show("Введите все значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				string Cel = textBox1.Text;
				switch (comboBox1.SelectedIndex)
				{
					case 0:
						{
							Form ifrm = new Form_Electr(Cel);
							ifrm.Left = this.Left;
							ifrm.Top = this.Top;
							ifrm.Show();
						}
						break;

					case 1:
						{
							Form ifrm1 = new Form_MAI(Cel);
							ifrm1.Left = this.Left;
							ifrm1.Top = this.Top;
							ifrm1.Show();
						}
						break;

					case 2:
						{
							Form ifrm2 = new Form_MSI(Cel);
							ifrm2.Left = this.Left;
							ifrm2.Top = this.Top;
							ifrm2.Show();
						}
						break;

					case 3:
						{
							Form ifrm3 = new Form_Blum(Cel);
							ifrm3.Left = this.Left;
							ifrm3.Top = this.Top;
							ifrm3.Show();
						}
						break;
				}
			}

		}
	}
}
