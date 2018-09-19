//混合查詢運算式  &&  查詢方法

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();

            this.productsTableAdapter1.Fill(this.northwindDataSet1.Products);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ArrayList arrList = new ArrayList();
            arrList.Add(1);
            arrList.Add(2);

            var q = from n in arrList.Cast<int>()
                    select new { n };

            foreach (var n in q)
            {
                this.listBox1.Items.Add(n);
            }
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = (from p in this.northwindDataSet1.Products
                     where p.CategoryID == 1
                     select p).Take(3);

            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
