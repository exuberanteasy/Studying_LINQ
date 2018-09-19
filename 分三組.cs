// 分三組

private void button1_Click(object sender, EventArgs e)
{
    int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 101 };

    //IEnumerable<IGrouping<int, int>> q = from n in nums
    //                                     group n by (n % 2);

    IEnumerable<IGrouping<string, int>> q = from n in nums
                                            group n by MyKey(n);



    this.dataGridView1.DataSource = q.ToList();

    foreach (var group in q)
    {
        TreeNode x = this.treeView1.Nodes.Add(group.Key.ToString());

        foreach (var item in group)
        {
            x.Nodes.Add(item.ToString());
        }
    }

    foreach (var group in q)
    {
        ListViewGroup lvg = this.listView2.Groups.Add(group.Key.ToString(), group.Key.ToString());

        foreach (var item in group)
        {
            this.listView2.Items.Add(item.ToString()).Group = lvg;
        }
    }

}

private string MyKey(int n)
{
    if (n<=5)
    {
        return "Small";
    }
    else if(n <= 10)
    {
        return "Medium";
    }
    else
    {
        return "Large";
    }
}
