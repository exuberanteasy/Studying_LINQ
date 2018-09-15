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
                richTextBox1.Text += i.ToString() + "\n";
            }
            richTextBox1.Text += "平均薪資: " + result.Average().ToString(); //顯示平均
        }

        //遞增
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "遞增排序: \n";
            var result = from s in Salary    
                         orderby s ascending  //將 Salary陣列所有元素 遞增排序
                         select s;
            int i = 0;
            foreach (var s in result)
            {
                i++;
                richTextBox1.Text += i.ToString() + ". " + s.ToString() + "\n";
            }
        }

        //遞減
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "遞減排序: \n";
            var result = from s in Salary     
                         orderby s descending   //將 Salary陣列所有元素 遞減排序
                         select s;
            int i = 0;
            foreach (var s in result)
            {
                i++;
                richTextBox1.Text += i.ToString() + ". " + s.ToString() + "\n";
            }
        }

        //大於3000
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "大於3000薪資: \n";
            var result = from s in Salary    //將Salary陣列中薪資 大於3萬元以遞減排序
                         orderby s descending
                         where s > 30000
                         select s;
            int i = 0;
            foreach (var s in result)
            {
                i++;
                richTextBox1.Text += i.ToString() + ". " + s.ToString() + "\n";
            }
            richTextBox1.Text += "共" + result.Count().ToString() + " 人";  // 取 > 30000筆數

        }

        // 小於30000
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "小於等於30000薪資: \n";
            var result = from s in Salary    //將Salary陣列中薪資 小於3萬元以遞減排序
                         orderby s descending
                         where s <= 30000
                         select s;
            int i = 0;
            foreach (var s in result)
            {
                i++;
                richTextBox1.Text += i.ToString() + ". " + s.ToString() + "\n";
            }
            richTextBox1.Text += "共" + result.Count().ToString() + " 人";  // 取 <= 30000筆數
        }

        // 平均
        private void button5_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);  //呼叫Form1_Load 事件，兩者程式碼相同
        }
        
    }
}
