// LinqLabs (StartUp)_練習

private void button4_Click(object sender, EventArgs e)
{
    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    this.listBox1.Items.Clear();

    foreach (int n in nums)
    {
        this.listBox1.Items.Add(n);
    }
}

private void button4_Click(object sender, EventArgs e)
{
    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    this.listBox1.Items.Clear();

    foreach (int n in nums)
    {
        this.listBox1.Items.Add(n);
    }

    this.listBox1.Items.Add("===========================");

    //??????
   System.Collections.IEnumerator en = nums.GetEnumerator();  //IEnumerator 要注意有沒有選錯!

    while (en.MoveNext())
    {
        this.listBox1.Items.Add(en.Current);
    }
}

private void button5_Click(object sender, EventArgs e)
{
    List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
    // list.Add(1)

    //C# 內部轉譯

    foreach (int n in list)
    {
        this.listBox1.Items.Add(n);
    }
    this.listBox1.Items.Add("===================================");
}
