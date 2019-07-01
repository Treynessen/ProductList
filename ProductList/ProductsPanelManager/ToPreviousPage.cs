public partial class ProductsPanelManager
{
    public ProductsPanelManager ToPreviousPage()
    {
        if (currentPage != null && currentPage.Previous != null)
        {
            ClearProductsPanel();
            currentPage = currentPage.Previous;
            CurrentPageNum -= 1;
            DisplayCurrentPage();
        }
        return this;
    }
}