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
