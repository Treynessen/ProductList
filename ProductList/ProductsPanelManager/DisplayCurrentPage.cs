public partial class ProductsPanelManager
{
    public void DisplayCurrentPage()
    {
        if (currentPage != null)
        {
            foreach (var cell in currentPage.Value)
            {
                cell.RefreshProductInfo();
                cell.Cell.Visible = true;
                productsPanel.Controls.Add(cell.Cell);
            }
        }
    }
}