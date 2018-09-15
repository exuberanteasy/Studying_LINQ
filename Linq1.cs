// 15-4

using System;

using System.Linq;

namespace Linq1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] Salary = new int[] { 50000, 80000, 20000, 30000, 45000 };

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var result = from s in Salary select s;

            int i = 0;
            foreach (var s in result)   //將 s 中所有資料逐行顯示在 richTextBox1控制項上
            {
                i++;
                richTextBox1.Text += i.ToString();
            }
        }
    }
}
