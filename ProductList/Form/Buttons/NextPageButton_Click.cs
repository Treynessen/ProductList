using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private void NextPageButton_Click(object sender, EventArgs e)
    {
        productsPanelManager.ToNextPage();
        PreviousPageButton.Visible = false;
        NextPageButton.Visible = false;
        RefreshFormFooter();
    }
}