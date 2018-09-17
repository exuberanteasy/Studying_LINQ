// Linq_to_Object2.sln
// C#2017_碁峯 => 20-8

//----------LINQ to Objects------------------------------------
using System.Linq;
using System.IO;

namespace Linq_to_Object2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //搜尋
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
                FileInfo[] f = dir.GetFiles();
                var myFile = from s in f
                             select s.FullName;

                foreach (var s in myFile)
                {
                    textBox2.Text += s + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = "路徑有錯";
                //throw;
            }
        }
    }
}
