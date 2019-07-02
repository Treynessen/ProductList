using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void DisplayProducts(LinkedList<ProductInformation> data)
    {
        if (data == null)
            return;
        
        if (productsPanelManager != null)
            productsPanel.Controls.Clear();

        productsPanelManager = new ProductsPanelManager(
            products: data,
            productsPanel: productsPanel,
            maxDisplayedCells: MAX_DISPLAYED_CELLS,
            editProduct: EditProduct,
            deleteProduct: DeleteProduct
        );

        productsPanelManager.NumOfCellsChanged += AddPageButtons;

        productsPanelManager.DisplayCurrentPage();

        AddPageButtons();
    }
}