using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1a2b
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private int[] ans = new int[10];
		private string[] gnum = new string[10];
		private int tmp,r;
		private Random random = new Random();

	

		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Text = "請輸入 4 個數字";
			label2.Text = "目前輸入 " + textBox1.TextLength.ToString() + " 字";
			label3.Text = "";

			button1.Text = "確定";
			button2.Text = "看答案";
			button3.Text = "重玩";
			
			for(int i=0; i<10; i++)
			{
				ans[i] = i;
			}
			
			for(int i =0; i < 10; i++)
			{
				r = random.Next(0, 10 - i);
				tmp = ans[r];
				ans[r] = ans[9 - i];
				ans[9 - i] = tmp;
			}
			
		}
		string num;

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			label2.Text = "目前輸入 " + textBox1.TextLength.ToString() + " 字";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			label3.Text = "";
			for (int i = 1; i <= 4; i++) { label3.Text += ans[i]; }
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter&& button1.Enabled == true)
			{
				button1_Click(sender, e);
				textBox1.Focus();
				textBox1.SelectAll();
				//e.SuppressKeyPress = true;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			label2.Text = "";
			textBox1.Text = "";
			textBox2.Text = "";
			label3.Text = "";
			button1.Enabled = true;
			for (int i = 0; i < 10; i++)
			{
				r = random.Next(0, 10 - i);
				tmp = ans[r];
				ans[r] = ans[9 - i];
				ans[9 - i] = tmp;
			}
			for (int j = 1; j <= 4; j++)
			{ gnum[j] = ""; }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int a = 0, b = 0;
			if (textBox1.TextLength != 4)
			{
				MessageBox.Show("請輸入4個不一樣數字");
			}

			else
			{
				for (int j = 1; j <= 4; j++)
				{
					gnum[j] = textBox1.Text.Substring(j - 1, 1);
					num += gnum[j];
				}
				if ((gnum[1] == gnum[2] || gnum[1] == gnum[3]
				|| gnum[1] == gnum[4] || gnum[2] == gnum[3]
				|| gnum[2] == gnum[4] || gnum[3] == gnum[4]))
				{
					MessageBox.Show("請不要輸入一樣的");
				}
				else
				{
					for (int k = 1; k <= 4; k++)
					{
						for (int l = 1; l <= 4; l++)
						{
							if (gnum[k] == ans[l].ToString())
							{
								if (k == l) { a++; }
								else if (k != l) { b++; }
							}
						}
					}

					textBox2.Text += num + "--"+ a.ToString() + "A" + b.ToString() + "B" + "\r\n";
					label3.Text = "你已經猜了" + (textBox2.Lines.Length - 1) + "次了";
					textBox1.Focus(); textBox1.SelectAll();
					num = "";
				}
				if (a == 4 && b == 0)
				{
					MessageBox.Show("恭喜你猜對了");
					button1.Enabled = false;
				}
				else if (textBox2.Lines.Length == 11)
				{
					MessageBox.Show("你已經GG了");
					button1.Enabled = false;
				}
			}
		}
	}
}
