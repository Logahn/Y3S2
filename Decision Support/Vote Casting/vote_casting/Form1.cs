using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPR1
{
	public partial class Form1 : Form
	{
		public int[] x = new int[15];
		public int[] y = new int[15];
		public int n, k = 0, p = 0, res = 0, u = 0, smp = 0; int d = 0;
		

		private void button5_Click(object sender, EventArgs e)// Кнопка помощи
		{
			if (comboBox2.SelectedIndex == -1)
			{
				MessageBox.Show("Для начала работы выберите метод посдсчета голосов, и проведите голосвание. Для понимания как проводить процесс заполнения и расчета, после выбранного метода нажмите на кнопку Подсказка еще раз. Для получения подробной информации ", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (comboBox2.SelectedIndex == 0)//Метод Борда
			{
				MessageBox.Show("Для подсчета голосов методом Борда, нужно расставить кандидатов в порядке приоритета. После выбора каждого кандидата необходимо нажать на кнопку Проголосовать. После завершения процесса голосования необходимо нажать на кнопку Следующий избератель. После голосования последним изберателем, перед нажатием на кнопку Результат необходимо нажать на кнопку следующий избиратель повторно", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//----------------------------------------------------------------------------------------------
			else if (comboBox2.SelectedIndex == 1)//Метод Борда Мод.
			{
				MessageBox.Show("Для подсчета голосов методом Борда Модифицированного, нужно расставить кандидатов в порядке приоритета. После выбора каждого кандидата необходимо нажать на кнопку Проголосовать. После завершения процесса голосования необходимо нажать на кнопку Следующий избератель. После голосования последним изберателем, перед нажатием на кнопку Результат необходимо нажать на кнопку следующий избиратель повторно", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//----------------------------------------------------------------------------------------------
			else if (comboBox2.SelectedIndex == 2)//Процедура Кондорсе
			{
				MessageBox.Show("Для подсчета голосов методом Кондорсе необходимо выбрать кандидата, который ему больше нравится, после чего нажать кнопку Проголосовать столько раз, сколько всего кандидатов. За следующих кандидатов нужно голосовать на 1 меньше, так же в порядке приоритета ", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//--------------------------------------------------------------------------------------------------
			else if (comboBox2.SelectedIndex == 3)//Процедура Доджсона
			{
				MessageBox.Show("Для подсчета голосов методом Доджсона необходимо выбрать кандидата, который ему больше нравится, после чего нажать кнопку Проголосовать столько раз, сколько всего кандидатов. За следующих кандидатов нужно голосовать на 1 меньше, так же в порядке приоритета ", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//--------------------------------------------------------------------------------------------------
			else if (comboBox2.SelectedIndex == 4) //Процедуры Симпсона
			{
				MessageBox.Show("Для подсчета голосов методом Симсона, нужно расставить кандидатов в порядке приоритета. После выбора каждого кандидата необходимо нажать на кнопку Проголосовать. После завершения процесса голосования необходимо нажать на кнопку Следующий избератель. После голосования последним изберателем, перед нажатием на кнопку Результат необходимо нажать на кнопку следующий избиратель повторно", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//--------------------------------------------------------------------------------------------------
			else if (comboBox2.SelectedIndex == 5) // Процедура Нансона
			{
				MessageBox.Show("Для подсчета голосов методом Нансона, нужно расставить кандидатов в порядке приоритета. После выбора каждого кандидата необходимо нажать на кнопку Проголосовать. После завершения процесса голосования необходимо нажать на кнопку Следующий избератель. После голосования последним изберателем, перед нажатием на кнопку Результат необходимо нажать на кнопку следующий избиратель повторно", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//--------------------------------------------------------------------------------------
			else if (comboBox2.SelectedIndex == 6) // Процедура Коупленда
			{
				MessageBox.Show("Для подсчета голосов методом Коупленда необходимо выбрать кандидата, который ему больше нравится, после чего нажать кнопку Проголосовать столько раз, сколько всего кандидатов. За следующих кандидатов нужно голосовать на 1 меньше, так же в порядке приоритета ", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//----------------------------------------------------------------------------------------
			else if (comboBox2.SelectedIndex == 7) // Метод Рыборожденного
			{
				MessageBox.Show("Для подсчета голосов методом Фишберна, нужно расставить кандидатов в порядке приоритета. После выбора каждого кандидата необходимо нажать на кнопку Проголосовать. После завершения процесса голосования необходимо нажать на кнопку Следующий избератель. После голосования последним изберателем, перед нажатием на кнопку Результат необходимо нажать на кнопку следующий избиратель повторно", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)//Заполнение комбобокса кындидатами 
		{

			if (textBox1.Text == "" && d == 3)
			{
				MessageBox.Show("ПОЖАЛУЙСТА,заполните количество кандидатов‍!! ", "Ошибка!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
				d++;
			}
			else if (textBox1.Text == "" && d == 5)
			{
				MessageBox.Show("ДЛЯ ЧАЙНИКОВ!\nЗаполните поле количество кондидатов\nЭТО ТО, ЧТО ЧУТЬ ВЫШЕ!☝☝☝☝", "!ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Question);
				d++;
			}
			else if (textBox1.Text == "" && d == 10)
			{
				MessageBox.Show("Мое терпение практически лопнуло!\nЗаполните уже это дурацкое поле!", "ЭТЭНШЭН, блэт!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
				d++;
			}
			else if (textBox1.Text == "" && d == 15)
			{
				MessageBox.Show("Мое терпение лопнуло!\nАрривидерчи", "Покусики", MessageBoxButtons.OK, MessageBoxIcon.Question);
				this.Close();
			}
			else if (textBox1.Text == "")
			{
				MessageBox.Show("Заполните количество кандидатов‍", "Oшибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				d++;
			}
			else
			{
				n = Convert.ToInt32(textBox1.Text);
				int[] z = new int[n];
				for (int i = 0; i < n; i++)
				{
					z[i] = i + 1;
					comboBox1.Items.Add("Кандидат " + z[i]);
					y[i] = 0;
				}
				smp = n;
				label1.Visible = false;
				textBox1.Visible = false;
				button1.Visible = false;
				label2.Visible = true;
				label3.Visible = true;
				label4.Visible = true;
				label5.Visible = true;
				label6.Visible = true;
				comboBox1.Visible = true;
				comboBox2.Visible = true;
				button2.Visible = true;
				button3.Visible = true;
				button4.Visible = true;
				textBox2.Visible = true;
				button5.Visible = true;
			}
		}
		private void button2_Click(object sender, EventArgs e) // кнопка голосвания
		{
			if (comboBox2.SelectedIndex == 0)//Метод Борда
			{
				x[comboBox1.SelectedIndex] = n - k;
				k++; res = 1;
			}
			//----------------------------------------------------------------------------------------------
			if (comboBox2.SelectedIndex == 1)//Метод Борда Мод.
			{
				x[comboBox1.SelectedIndex] = n - k;
				k++; res = 2;
			}
			//----------------------------------------------------------------------------------------------
			if (comboBox2.SelectedIndex == 2)//Процедура Кондорсе
			{
				res = 3;
				for (int i = 0; i < n; i++)
				{
					if (comboBox1.SelectedIndex == i)
					{
						x[comboBox1.SelectedIndex] += 1;
					}
				}
			}
			//--------------------------------------------------------------------------------------------------
			if (comboBox2.SelectedIndex == 3)//Процедура Доджсона
			{
				res = 4;
				for (int i = 0; i < n; i++)
				{
					if (comboBox1.SelectedIndex == i)
					{
						x[comboBox1.SelectedIndex] += 1;
					}
				}
			}
			//--------------------------------------------------------------------------------------------------
			if (comboBox2.SelectedIndex == 4) //Процедуры Симпсона
			{
				res = 5;
				x[comboBox1.SelectedIndex] += smp;
				smp = smp - 1;
			}
			//--------------------------------------------------------------------------------------------------
			if (comboBox2.SelectedIndex == 5) // Процедура Нансона
			{
				res = 6;
				x[comboBox1.SelectedIndex] += smp;
				smp = smp - 1;
			}
			//--------------------------------------------------------------------------------------
			if (comboBox2.SelectedIndex == 6) // Процедура Коупленда
			{
				res = 7;
				for (int i = 0; i < n; i++)
				{
					if (comboBox1.SelectedIndex == i)
					{
						x[comboBox1.SelectedIndex] += 1;
					}
				}
			}
			//----------------------------------------------------------------------------------------
			if (comboBox2.SelectedIndex == 7) // Метод Рыборожденного
			{
				x[comboBox1.SelectedIndex] = n - k;
				k++; res = 8;
			}
		}

		private void button4_Click_1(object sender, EventArgs e)//Следующий избератель
		{
			MessageBox.Show("Очередь следующего избирателя\n🚶‍🚶‍💃🏃‍", "Спасибо за голос 🚀", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			if (res == 1 || res == 2 || res == 8)
			{
				for (int i = 0; i < n; i++)
				{
					y[i] = y[i] + x[i];
					x[i] = 0;
					k = 0;
				}
			}
			if (res == 5 || res == 6)
			{
				smp = n;
			}
		}
		private void button3_Click_1(object sender, EventArgs e) // кнопка ризультат
		{
			textBox2.Text += ("-------------------------------------------------------------------------\r\n");
			if (res == 1 || res == 8)
			{
				int max1 = -5555;
				for (int i = 0; i < n; i++)
				{
					if (y[i] > max1)
					{
						max1 = y[i];
						k = i + 1;
					}
				}
				if (res == 1)
				{ textBox2.Text += ("Метод Борда\r\n"); }
				if (res == 8)
				{ textBox2.Text += ("Метод Фишберна\r\n"); }
				for (int o = 0; o < n; o++)
				{
					textBox2.Text += ("Кандидат " + (o + 1) + " набрал " + y[o] + " голосов\r\n");
				}
				textBox2.Text += ("\r\n Победил кандидат " + k + " набрал " + max1 + " баллов\r\n");
			}
			//--------------------------------------------------------------------------------
			if (res == 2)
			{
				textBox2.Text += ("Метод Борда Модифицированный\r\n");
				int max2 = -5555;
				for (int i = 0; i < n; i++)
				{
					if (y[i] > max2)
					{
						max2 = y[i];
						k = i + 1;
					}
				}
				for (int i = 0; i < n; i++)
				{
					int Help = i + 1;
					textBox2.Text += ("Кандидат " + Help + " набрал " + y[i] + " голосов\r\n");
				}
				textBox2.Text += ("\r\n Победил кандидат " + k + " набрал " + max2 + " баллов\r\n");
			}
			//--------------------------------------------------------------------------------
			if (res == 3  ||res == 4 || res == 7)
            {
				int max = -555555; int maksimalniy_index = 0;
				if (res == 3)
				{ textBox2.Text += ("Принцип Кондорсе\r\n"); }
				if (res == 4)
				{
					textBox2.Text += ("Процедура Доджсона\r\n");
					for (int i = 0; i < n; i++)
					{
						for (int j = 0; j < n; j++)
						{
							if (x[i] > x[j])
							{
								y[i] += 1;
							}
						}
					}
				}
				if (res == 7)
				{
					textBox2.Text += ("Процедура Коупленда\r\n");
					for (int i = 0; i < n; i++)
					{
						for (int j = 0; j < n; j++)
						{
							if (x[i] > x[j])
							{
								y[i] += 1;
							}
						}
					}
				}


				for (int i = 0; i < n; i++)
				{
					if (res == 7)
					{
						if (y[i] != 0)
						{
							int Help = i + 1;
							textBox2.Text += ("Кандидат " + Help + " набрал " + y[i] + " баллов\r\n");
						}
					}
					else { int Help = i + 1; textBox2.Text += ("Кандидат " + Help + " набрал " + x[i] + " баллов\r\n"); }
				}
				for (int i = 0; i < n; i++)
				{
					if (res==3) {
						if (x[i] > max) { 
						max = x[i];
						maksimalniy_index = i;
						}
					}
					if (res==4|| res==7) {
						if (y[i] > max)
						{
							max = y[i];
							maksimalniy_index = i;
						}
					}
				}
				textBox2.Text += ("\r\n Победил кандидат " + (maksimalniy_index+1) + " набрал " + max + " баллов\r\n");
			}

			if (res == 5)
			{
				int max = -500000, k = 0;
				textBox2.Text += ("Процедура Симпсона\r\n");
				for (int i = 0; i < n; i++)
				{
					if (x[i] > max)
					{
						max = x[i];
						k = i + 1;
					}
					int Help = i + 1;
					textBox2.Text += ("Кандидат " + Help + " набрал " + x[i] + " баллов\r\n");
				}
				textBox2.Text += ("\r\n Победил кандидат " + k + " набрал " + max + " баллов\r\n");
			}

			if (res == 6)
			{
				int srar = 0;
				textBox2.Text += ("Метод Нансона \r\n");
				int max = -500000, k = 0;
				for (int o = 0; o < n; o++)
				{
					if (x[o] > max)
					{
						max = x[o];
						k = o + 1;
					}
				}
					for (int i = 0; i < n; i++)
					{
						srar += x[i];
					}
					srar = srar / n;
					for (int i = 0; i < n; i++)
					{
						if (x[i] > srar)
						{
							textBox2.Text += ("Победил кандидат " + (i + 1) + " набрал " + x[i] + " баллов\r\n");
						}
					}
					textBox2.Text += ("\r\n Победил кандидат " + k + " набрал " + max + " баллов\r\n");
				}
			using (StreamWriter incdate = File.AppendText(@"Otchet.txt")) { incdate.WriteLine(textBox2.Text, '\n'); }
		}
		}
}