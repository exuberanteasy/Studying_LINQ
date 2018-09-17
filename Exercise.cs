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

//---- LINQ Method -------------------------
// 20-17

//----- Book.cs ---------
namespace Linq_Method1
{
    class Book
    {
        public string Id { get; set; }  //書號
        public string Name { get; set; }  //書名
        public int Price { get; set; }  //單價
    }
}


//-------- Linq_Method1.sln ---------
using System.Linq;

namespace Linq_Method1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //建立 Book書籍陣列物件
        Book[] books = new Book[]
        {
            new Book {Id="AEL015400", Name="Java 8 基礎必修課", Price=530},
            new Book {Id="AEL017400", Name="Visual C# 2017 基礎必修課", Price=500},
            new Book {Id="AEL014700", Name="Visual Basic 2017 程式設計經典", Price=650},
            new Book {Id="AEL014300", Name="Visual C# 2017 程式設計經典", Price=750}
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = books.ToList();
        }

        //查詢
        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            var result = books
                .Where(m => m.Name.Contains(keyword)).ToList();
            dataGridView1.DataSource = result;
        }

        //書籍列表
        private void button2_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        //單價遞增排序
        private void button3_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            var result = books.OrderBy(m => m.Price).ToList();
            dataGridView1.DataSource = result;
        }

        //單價遞減排序
        private void button4_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            var result = books.OrderByDescending(m => m.Price).ToList();
            dataGridView1.DataSource = result;
        }
    }
}

//----- Linq_Method2.sln ---------------------------------------------------
// 20-20
//----- 建一個 Book.cs ---------

using System.Linq;

namespace Linq_Method2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //建立 Book 書籍陣列物件
        Book[] books = new Book[]
        {
            new Book { Id="AEL015400", Name = "Jave 8 基礎必修課", Price = 530},
            new Book { Id="AEL017400", Name = "Visual C# 2017 基礎必修課", Price = 600},
            new Book { Id="AEL014700", Name = "Visual Basic 2017 程式設計經典", Price = 650},
            new Book { Id="AEL014300", Name = "Visual C# 2017 程式設計經典", Price = 700}
        };

        //宣告 index 整數變數，用來表示陣列中的第幾筆書籍資料
        int index = 0;
        
        //定義ShowRecord，可傳入指定的書籍物件，並將該物件資訊顯示在表單控制項上
        void ShowRecord(Book t)
        {
            textBox1.Text = t.Id;
            textBox2.Text = t.Name;
            textBox3.Text = t.Price.ToString();

            pictureBox1.Image = new Bitmap(t.Id + ".jpg");
            label4.Text = (index + 1) + " /" + books.Count();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var result = books.FirstOrDefault();
            ShowRecord(result);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //上一筆
        private void button1_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = books.Count() - 1;
            }
            var result = books.Skip(index).FirstOrDefault();
            ShowRecord(result);
        }

        //下一筆
        private void button2_Click(object sender, EventArgs e)
        {
            index++;
            if (books.Count() <= index)
            {
                index = 0;
            }
            var result = books.Skip(index).FirstOrDefault();
            ShowRecord(result);
        }
    }
}





