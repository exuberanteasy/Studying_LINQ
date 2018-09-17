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
