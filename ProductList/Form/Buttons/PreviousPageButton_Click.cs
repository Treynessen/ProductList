using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private void PreviousPageButton_Click(object sender, EventArgs e)
    {
        productsPanelManager.ToPreviousPage();
        PreviousPageButton.Visible = false;
        NextPageButton.Visible = false;
        RefreshFormFooter();
    }
}