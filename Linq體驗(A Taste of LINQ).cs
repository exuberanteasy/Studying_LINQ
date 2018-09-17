Linq體驗(A Taste of LINQ)

using System.Linq;

private void button2_Click(object sender, EventArgs e)
{
    //Step 1: 
    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    //Step 2: 
    // 完整一點是這樣 IEnumerable<int> q = 
    var q = from n in nums
            where n > 5 && n <= 8
            select n;

    //Step 3: 
    foreach (int n  in q)
    {
        this.listBox1.Items.Add(n);
    }
}

//===============================================
private void button7_Click(object sender, EventArgs e)
{
    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
    // var q = 
    IEnumerable<Point> q = from n in nums
            where n > 5 && n <= 8
            select new Point(n, n * n);  //可以輸出任意型別??

    foreach (Point p in q)
    {
        this.listBox1.Items.Add(p);
    }
}

private void button7_Click(object sender, EventArgs e)
{
    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    // var q = 
    IEnumerable<Point> q = from n in nums
                           where n > 0 
                           select new Point(n, n * n);  //可以輸出任意型別??

    foreach (Point p in q)
    {
        this.listBox1.Items.Add(p);
    }

    //================================================
    this.dataGridView1.DataSource = q.ToList(); //loop......

    this.chart1.DataSource = q.ToList();
    this.chart1.Series[0].XValueMember = "X";
    this.chart1.Series[0].YValueMembers = "Y";
    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
}
//==============================================================
 private void button10_Click(object sender, EventArgs e)
{
    this.productsTableAdapter1.Fill(this.northwindDataSet1.Products);
    this.dataGridView1.DataSource = this.northwindDataSet1.Products;

    var q = from p in this.northwindDataSet1.Products
            where !p.IsUnitPriceNull() &&  p.UnitPrice > 30
            select p;

    foreach (global::LinqLabs.NorthwindDataSet.ProductsRow p in q)
    {
        this.listBox1.Items.Add(p.ProductName + p.UnitPrice);
    }

    this.dataGridView1.DataSource = q.ToList();
}



