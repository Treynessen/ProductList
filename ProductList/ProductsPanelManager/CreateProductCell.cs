using System;
using System.Drawing;
using System.Windows.Forms;
using Treynessen.Products;

public partial class ProductsPanelManager
{
    private const int startedYPos = -5;

    private Font labelFont = new Font("Century Gothic", 10, FontStyle.Regular);
    private Font textBoxFont = new Font("Century Gothic", 12, FontStyle.Regular);
    private Font barcodeLabelFont = new Font("Century Gothic", 14, FontStyle.Regular);

    private Action<ProductInformation, string, string, string, string> editProduct;
    private Func<ProductInformation, bool> deleteProduct;

    private ProductCell CreateProductCell(ProductInformation product, int currentYPosition)
    {
        ProductCell cell = new ProductCell(
                product: product,
                yPosition: currentYPosition,
                groupWidth: productsPanel.Width - 20,
                labelFont: labelFont,
                textBoxFont: textBoxFont,
                barcodeLabelFont: barcodeLabelFont
            );

        cell.EditButton.Click += (o, arg) =>
        {
            int oldPositionNumber = product.PositionNumber;
            editProduct(
                product, 
                cell.ProductPositionNumberTextBox.Text,
                cell.ProductNameTextBox.Text, 
                cell.ProductPriceTextBox.Text, 
                cell.ProductBarcodeTextBox.Text
            );
            if (oldPositionNumber != product.PositionNumber)
            {
                EditCell(product);
            }
            MessageBox.Show($"Товар {product.Name} изменен");
        };

        cell.DeleteButton.Click += (o, arg) =>
        {
            bool successfullyDeleted = deleteProduct(product);
            if (successfullyDeleted)
            {
                DeleteCell(product);
            }
            MessageBox.Show($"Товар {product.Name} удален");
        };

        return cell;
    }
}