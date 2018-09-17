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

//------ LINQ to XML ---------------------------
//20-12  Linq_to_XML1.sln
using System.Linq;
using System.Xml.Linq;

namespace Linq_to_XML1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XElement xmlFile = XElement.Load("person.xml");

        //表單載入時執行
        private void Form1_Load(object sender, EventArgs e)
        {
            var stu = from s in xmlFile.Elements()
                      select new
                      {
                          學生學號 = (string)s.Element("學號"),
                          學生姓名 = (string)s.Element("姓名"),
                          學生電話 = (string)s.Element("電話"),
                          學生信箱 = (string)s.Element("信箱")
                      };
            dataGridView1.DataSource = stu.ToList();
            textBox1.Text = "學生共" + stu.Count().ToString() + "人";
        }

        //搜尋
        private void button1_Click(object sender, EventArgs e)
        {
            var stu = from s in xmlFile.Elements()
                      where (string)s.Element("學號") == textBox1.Text
                      select new
                      {
                          學生學號 = (string)s.Element("學號"),
                          學生姓名 = (string)s.Element("姓名"),
                          學生電話 = (string)s.Element("電話"),
                          學生信箱 = (string)s.Element("信箱")
                      };
            if (stu.Count() == 0)
            {
                MessageBox.Show("沒有學號 " + textBox1.Text + "這位學生");
            }
            else
            {
                foreach (var s in stu)
                {
                    MessageBox.Show(" 學生學號: " + s.學生學號 +
                                  "\n 學生姓名: " + s.學生姓名 +
                                  "\n 學生信箱: " + s.學生信箱,
                                  "\n 搜尋結果: ", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                }
            }
        }
    }
}



