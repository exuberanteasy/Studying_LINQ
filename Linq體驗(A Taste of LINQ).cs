Linq體驗(A Taste of LINQ)

using System.Linq;

private void button2_Click(object sender, EventArgs e)
{
    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    // 完整一點是這樣 IEnumerable<int> q = 
    var q = from n in nums
            where n > 5 && n <= 8
            select n;

    foreach (int n  in q)
    {
        this.listBox1.Items.Add(n);
    }
}
