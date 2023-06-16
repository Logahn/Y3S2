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

namespace Lr1
{
	public partial class Form1 : Form
	{
		public float[] vzaimoocenka = new float[3];//0-я 1-ты 2-гослинг вхаимооценка
		public float rabgruppa = 0;//рабочей группой
		public float samoocenka = 0;
		public float kvalimetr = 0;
		public float profkomp = 0;
		public void info()
		{
			MessageBox.Show("Данные записаны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		public float srar(float []vzaimoocenka) {
			float k = 0;
			for (int i = 0; i < 3; i++) 
			{
				k += vzaimoocenka[i];
			}
			float srar= k/3;
			return srar;
		}
		private void PrintForm()
		{
			using (var bmp = new Bitmap(this.Width, this.Height))
			{
				this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
				var printDoc = new PrintDocument();
				printDoc.PrintPage += (s, e) => e.Graphics.DrawImage(bmp, 0, 0);
				printDoc.Print();
			}
		}
		public Form1()
		{
			InitializeComponent();
		}

		private void beksp_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == -1)
			{
				MessageBox.Show("Выберите эксперта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				groupBox15.Visible = false;
				bocenkarab.Visible = true;
				bocenkkwa.Visible = true;
				bprofcomp.Visible = true;
				bsamoocenka.Visible = true;
				bvzaimoocenka.Visible = true;
				bres.Visible = true;
			}
		}

		private void bprofcomp_Click(object sender, EventArgs e)
		{
			groupBox16.Visible = false;
			groupBox7.Visible = false;
			groupBox11.Visible = false;
			groupBox12.Visible = false;
			groupBox13.Visible = false;
			groupBox14.Visible = true;
		}
		//
		//Кнопка СОХРАНИТЬ в групбоксе 7 - самооценка 
		//
		private void button1_Click(object sender, EventArgs e)
		{
			info();
			samoocenka = 0;
			if (radioButton1.Checked)
			{
				samoocenka += 1.5f;
			}
			if (radioButton6.Checked)
			{
				samoocenka += 1.5f;
			}
			if (radioButton9.Checked)
			{
				samoocenka += 1.5f;
			}
			if (radioButton18.Checked)
			{
				samoocenka += 1.5f;
			}
			if (radioButton15.Checked)
			{
				samoocenka += 1.5f;
			}
			if (radioButton12.Checked)
			{
				samoocenka += 1.5f;
			}
			if (radioButton2.Checked)
			{
				samoocenka += 0.9f;
			}
			if (radioButton5.Checked)
			{
				samoocenka += 0.9f;
			}
			if (radioButton8.Checked)
			{
				samoocenka += 0.9f;
			}
			if (radioButton17.Checked)
			{
				samoocenka += 0.9f;
			}
			if (radioButton14.Checked)
			{
				samoocenka += 0.9f;
			}
			if (radioButton11.Checked)
			{
				samoocenka += 0.9f;
			}
			if (radioButton3.Checked)
			{
				samoocenka += 0.45f;
			}
			if (radioButton4.Checked)
			{
				samoocenka += 0.45f;
			}
			if (radioButton7.Checked)
			{
				samoocenka += 0.45f;
			}
			if (radioButton16.Checked)
			{
				samoocenka += 0.45f;
			}
			if (radioButton13.Checked)
			{
				samoocenka += 0.45f;
			}
			if (radioButton10.Checked)
			{
				samoocenka += 0.45f;
			}
		}

		private void bsamoocenka_Click(object sender, EventArgs e)
		{
			groupBox16.Visible = false;
			groupBox7.Visible = true;
			groupBox11.Visible = false;
			groupBox12.Visible = false;
			groupBox13.Visible = false;
			groupBox14.Visible = false;

		}

		private void bocenkarab_Click(object sender, EventArgs e)
		{
			groupBox7.Visible = false;
			groupBox11.Visible = true;
			groupBox12.Visible = false;
			groupBox13.Visible = false;
			groupBox14.Visible = false;
		}
		//
		//Кнопка СОХРАНИТЬ в групбоксе 11 - оценка рабочей группой 
		//
		private void button2_Click(object sender, EventArgs e)
		{
			info();
			rabgruppa = 0;
			if (radioButton19.Checked)
			{
				rabgruppa += 3.3f;
			}
			if (radioButton26.Checked)
			{
				rabgruppa += 3.3f;
			}
			if (radioButton30.Checked)
			{
				rabgruppa += 3.3f;
			}
			if (radioButton20.Checked)
			{
				rabgruppa += 2.5f;
			}
			if (radioButton25.Checked)
			{
				rabgruppa += 2.5f;
			}
			if (radioButton29.Checked)
			{
				rabgruppa += 2.5f;
			}
			if (radioButton21.Checked)
			{
				rabgruppa += 1.67f;
			}
			if (radioButton24.Checked)
			{
				rabgruppa += 1.67f;
			}
			if (radioButton28.Checked)
			{
				rabgruppa += 1.67f;
			}
			if (radioButton22.Checked)
			{
				rabgruppa += 1;
			}
			if (radioButton23.Checked)
			{
				rabgruppa += 1;
			}
			if (radioButton27.Checked)
			{
				rabgruppa += 1;
			}
		}

		private void bvzaimoocenka_Click(object sender, EventArgs e)
		{
			groupBox16.Visible = false;
			groupBox12.Visible = true;
			groupBox7.Visible = false;
			groupBox11.Visible = false;
			groupBox13.Visible = false;
			groupBox14.Visible = false;
			if (comboBox1.SelectedIndex == 0)
			{
				label24.Visible = false;
				comboBox2.Visible = false;
				vzaimoocenka[0] = 0.4f;
			}
			if (comboBox1.SelectedIndex == 1)
			{
				label25.Visible = false;
				comboBox3.Visible = false;
				vzaimoocenka[1] = 0.4f;
			}
			if (comboBox1.SelectedIndex == 2)
			{
				label26.Visible = false;
				comboBox4.Visible = false;
				vzaimoocenka[2] = 0.4f;
			}
		}
		//
		//Кнопка СОХРАНИТЬ в групбоксе 12 - Взаимооценка 
		//
		private void button3_Click(object sender, EventArgs e)
		{
			info();
			switch (comboBox2.SelectedIndex)
			{
				case 0: vzaimoocenka[0] = 2; break;
				case 1: vzaimoocenka[0] = 1.6f; break;
				case 2: vzaimoocenka[0] = 1.2f; break;
				case 3: vzaimoocenka[0] = 0.8f; break;
				case 4: vzaimoocenka[0] = 0.4f; break;
			}
			switch (comboBox3.SelectedIndex)
			{
				case 0: vzaimoocenka[1] = 2; break;
				case 1: vzaimoocenka[1] = 1.6f; break;
				case 2: vzaimoocenka[1] = 1.2f; break;
				case 3: vzaimoocenka[1] = 0.8f; break;
				case 4: vzaimoocenka[1] = 0.4f; break;
			}
			switch (comboBox4.SelectedIndex)
			{
				case 0: vzaimoocenka[2] = 2; break;
				case 1: vzaimoocenka[2] = 1.6f; break;
				case 2: vzaimoocenka[2] = 1.2f; break;
				case 3: vzaimoocenka[2] = 0.8f; break;
				case 4: vzaimoocenka[2] = 0.4f; break;
			}
			//label23.Text = "" + x[2];
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
		//
		//Кнопка СОХРАНИТЬ в групбоксе 13 - Квалиметрическая компетентность
		//
		private void button4_Click(object sender, EventArgs e)
		{
			double num1 = 0.0;
			double num2 = Convert.ToDouble(this.textBox1.Text) + Convert.ToDouble(this.textBox2.Text) + Convert.ToDouble(this.textBox3.Text) + Convert.ToDouble(this.textBox4.Text);
			if (num2 <= 1.05 && num2 >= 0.95)
			{
				double num3 = Convert.ToDouble(this.textBox1.Text) != 0.4 ? (Convert.ToDouble(this.textBox1.Text) != 0.3 && Convert.ToDouble(this.textBox1.Text) != 0.5 ? num1 + 0.0 : num1 + 1.0) : num1 + 2.0;
				double num4 = Convert.ToDouble(this.textBox2.Text) != 0.3 ? (Convert.ToDouble(this.textBox2.Text) != 0.2 && Convert.ToDouble(this.textBox1.Text) != 0.4 ? num3 + 0.0 : num3 + 1.0) : num3 + 2.0;
				double num5 = Convert.ToDouble(this.textBox3.Text) != 0.2 ? (Convert.ToDouble(this.textBox3.Text) != 0.1 && Convert.ToDouble(this.textBox1.Text) != 0.3 ? num4 + 0.0 : num4 + 1.0) : num4 + 2.0;
				double num6 = Convert.ToDouble(this.textBox4.Text) != 0.1 ? (Convert.ToDouble(this.textBox4.Text) != 0.2 ? num5 + 0.0 : num5 + 1.0) : num5 + 2.0;
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
				double kvalimetr = num6 / 2.4;
				if (kvalimetr > 10.0)
					kvalimetr = 10.0;
			}
			else
			{
				int num9 = (int)MessageBox.Show("Упс! Что-то пошло не так (возможно это вероятности)");
			}
			info();
		}
		//
		//Кнопка СОХРАНИТЬ в групбоксе 14 - Проф компетентность 
		//
		private void button5_Click_1(object sender, EventArgs e)
		{
			profkomp = 0;
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
				{ profkomp += 1.5f; }
				if (comboBox16.SelectedIndex == 2)//2
				{ profkomp += 1.5f; }
				if (comboBox17.SelectedIndex == 0)//3
				{ profkomp += 1.5f; }
				if (comboBox18.SelectedIndex == 1)//4
				{ profkomp += 1.5f; }
				if (comboBox19.SelectedIndex == 3)//5
				{ profkomp += 1.5f; }
				if (comboBox24.SelectedIndex == 2)//6
				{ profkomp += 1.5f; }
				if (comboBox23.SelectedIndex == 1)//7
				{ profkomp += 1.5f; }
				if (comboBox22.SelectedIndex == 1)//8
				{ profkomp += 1.5f; }
				if (comboBox21.SelectedIndex == 2)//9
				{ profkomp += 1.5f; }
				if (comboBox20.SelectedIndex == 1)//10
				{ profkomp += 1.5f; }
				if (textBox6.Text == "Компилятор" || textBox6.Text == "компилятор" ||
					textBox6.Text == " Компилятор" || textBox6.Text == " компилятор" ||
					textBox6.Text == "Компилятор " || textBox6.Text == "компилятор ")
				{
					profkomp += 4;
				}
				if (textBox7.Text == "3")
				{
					profkomp += 8;
				}
				if (comboBox25.SelectedIndex == 3)
					profkomp += 1.5f;
				if (comboBox26.SelectedIndex == 1)
					profkomp += 1.5f;
				if (comboBox27.SelectedIndex == 0)
					profkomp += 1.5f;
				if (comboBox28.SelectedIndex == 4)
					profkomp += 1.5f;
			}

		}

		private void bres_Click(object sender, EventArgs e)
		{
			groupBox12.Visible = false;
			groupBox7.Visible = false;
			groupBox11.Visible = false;
			groupBox13.Visible = false;
			groupBox14.Visible = false;
			groupBox16.Visible = true;
			textBox8.Text += "\r\nЭксперт: " + comboBox1.SelectedItem + "\r\n" +
				"Cамооценка: " + samoocenka + "\r\n" +
				"Профессиональная компетентность: " + profkomp + "\r\n" +
				"Оценка рабочей группой: " + rabgruppa + "\r\n" +
				"Оценка квалиметрической компетентности: " + kvalimetr + "\r\n" +
				"Взаимооценка: " + srar(vzaimoocenka);
		}
		//Coxpaнить в файл
		private void button6_Click(object sender, EventArgs e)
		{
			using (StreamWriter incdate = File.AppendText(@"result.txt")) { incdate.WriteLine(textBox8.Text, '\n'); }
		}

		private void button7_Click(object sender, EventArgs e)
		{
			PrintForm();
		}

		private void button8_Click(object sender, EventArgs e)
		{
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
