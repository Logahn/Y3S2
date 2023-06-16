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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LR_2
{
	public partial class Form_Res : Form
	{
		private string Cel;
		float[] res = new float[15];
		int alt; int kriter;
		public string metod;
		ZaPiska zaPiska = new ZaPiska();
		public Form_Res(float[] res, string Cel,int alt, int kriter,string metod)
		{
			InitializeComponent();
			this.Cel = Cel;
			this.res = res;
			this.alt = alt;
			this.kriter = kriter;
			this.metod = metod;
		}

		private void Form_Res_Load(object sender, EventArgs e)
		{
			label1.Text = "Цель сравнения: " + Cel+"\r\nСравнение методом: "+metod;
			label2.Text = "Количество критериев: " + kriter + "\r\nКоличество альтернатив: " + alt;
			for (int i = 0; i < alt; i++)
			{
				dataGridView1.Rows.Add();
				dataGridView1.Rows[i].Cells[0].Value = "Альтернатива  " + (i + 1);
				dataGridView1.Rows[i].Cells[1].Value = res[i];
			}
			
		}		
	
		private void button1_Click(object sender, EventArgs e, DataGridView dataGridView)
		{
			zaPiska.SaveToExcel(dataGridView1, "Resutl.xlx");
		}
	}
}
