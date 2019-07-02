using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private void RefreshFormFooter()
    {
        if (productsPanelManager.NumberOfPages < 2)
        {
            PageInfoLabel.Visible = ProductPositionInfoLabel.Visible = PreviousPageButton.Visible = NextPageButton.Visible = false;
            MaximumSize = MinimumSize = Size = new Size(816, 628);
        }
        else if (productsPanelManager.CurrentPageNum == 1)
        {
            PreviousPageButton.Visible = false;
            NextPageButton.Location = new Point(11, 588);
            NextPageButton.Visible = true;
            MaximumSize = MinimumSize = Size = new Size(816, 664);
            PageInfoLabel.Visible = ProductPositionInfoLabel.Visible = true;
            PageInfoLabel.Width = ProductPositionInfoLabel.Width = 276;
            PageInfoLabel.Text = $"Страница {productsPanelManager.CurrentPageNum} из {productsPanelManager.NumberOfPages}";
            ProductPositionInfoLabel.Text = $"Отображены позиции {productsPanelManager.FirstProductPositionNum} - {productsPanelManager.LastProductPositionNum}";
        }
        else
        {
            PreviousPageButton.Location = new Point(11, 588);
            PreviousPageButton.Visible = true;
            if (productsPanelManager.CurrentPageNum != productsPanelManager.NumberOfPages)
            {
                NextPageButton.Location = new Point(261, 588);
                NextPageButton.Visible = true;
            }
            MaximumSize = MinimumSize = Size = new Size(816, 664);
            PageInfoLabel.Visible = ProductPositionInfoLabel.Visible = true;
            PageInfoLabel.Width = ProductPositionInfoLabel.Width = 276;
            PageInfoLabel.Text = $"Страница {productsPanelManager.CurrentPageNum} из {productsPanelManager.NumberOfPages}";
            ProductPositionInfoLabel.Text = $"Отображены позиции {productsPanelManager.FirstProductPositionNum} - {productsPanelManager.LastProductPositionNum}";
        }
    }
}