using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_2
{
	public partial class Form_Blum : Form
	{
		private string Cel;
		public Form_Blum(string Cel)
		{
			InitializeComponent();
			this.Cel = Cel;
		}
		public string metod = "Блюмена";
		public int kriter;
		public int alt;
		float[] arr_krit = new float[15];
		float[] arr_alt = new float[15];
		float summkrit = 0;
		int f = 0;
		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "" || textBox2.Text == "")
			{
				MessageBox.Show("Введите все значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				groupBox1.Visible = true;
				kriter = Convert.ToInt32(textBox1.Text);
				alt = Convert.ToInt32(textBox2.Text);
				for (int i = 0; i < kriter; i++)
				{
					dataGridView1.Rows.Add();
					dataGridView1.Rows[i].Cells[0].Value = "Критерий " + (i + 1);
				}
				for (int i = 0; i < alt; i++)
				{
					dataGridView2.Rows.Add();
					dataGridView2.Rows[i].Cells[0].Value = "Альтернатива " + (i + 1);
				}

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < kriter; i++)
			{
				arr_krit[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
				summkrit += arr_krit[i];
			}
			groupBox2.Visible = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < alt; i++)
			{
				arr_alt[i] += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);
			}
			button5.Visible = true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < alt; i++)
			{
				arr_alt[i] += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value)*arr_krit[f];

			}
			f++;
			for (int i = 0; i < alt; i++)
			{
				dataGridView2.Rows[i].Cells[1].Value = " ";
			}
			label6.Text = "Критерия " + (f + 1);
			if (f == kriter - 1)
			{
				button4.Visible = false;
				button3.Visible = true;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < alt; i++)
			{
				arr_alt[i]= arr_alt[i]/summkrit;
			}
			Form ifrm = new Form_Res(arr_alt, Cel, alt, kriter, metod);
			ifrm.Left = this.Left;
			ifrm.Top = this.Top;
			ifrm.Show();

		}
	}
}
