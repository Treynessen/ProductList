public partial class ProductsPanelManager
{
    private void ClearProductsPanel()
    {
        if (currentPage != null)
        {
            int currentYPos = startedYPos;
            foreach (var cell in currentPage.Value)
            {
                cell.SetNewGroupYPosition(currentYPos); // после скроллинга сбивается локация
                productsPanel.Controls.Remove(cell.Cell);
                cell.Cell.Visible = false;
                currentYPos = GetNextYPos(currentYPos);
            }
        }
    }
}