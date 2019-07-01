public partial class ProductsPanelManager
{
    public ProductsPanelManager ToNextPage()
    {
        if (currentPage != null && currentPage.Next != null)
        {
            ClearProductsPanel();
            currentPage = currentPage.Next;
            CurrentPageNum += 1;
            DisplayCurrentPage();
        }
        return this;
    }
}