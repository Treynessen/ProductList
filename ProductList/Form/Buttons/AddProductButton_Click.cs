using System;
using System.Windows.Forms;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void AddProductButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ProductNameTextBox.Text)
            && string.IsNullOrEmpty(ProductPriceTextBox.Text)
            && string.IsNullOrEmpty(ProductPositionNumberTextBox.Text))
        {
            MessageBox.Show("Форма не заполнена");
            return;
        }
        int? price = null, positionNumber = null;
        try
        {
            price = Convert.ToInt32(ProductPriceTextBox.Text);
        }
        catch { }
        try
        {
            positionNumber = Convert.ToInt32(ProductPositionNumberTextBox.Text);
        }
        catch { }
        if (!price.HasValue || !positionNumber.HasValue)
        {
            MessageBox.Show("Форма заполнена неверно");
            return;
        }
        ProductInformation product = new ProductInformation
        {
            PositionNumber = positionNumber.Value,
            Name = ProductNameTextBox.Text,
            Price = price.Value
        };
        if (productsPanelManager != null && (!displayedPosition.HasValue || displayedPosition.Value == product.PositionNumber))
        {
            bool createdPage = false;
            productsPanelManager.AddProduct(product, ref createdPage);
            if (createdPage)
                AddPageButtons();
        }
        AddProductToData(product);
        SerializeToFile();
        ProductPositionNumberTextBox.Text = ProductNameTextBox.Text = ProductPriceTextBox.Text = string.Empty;
        MessageBox.Show("Товар добавлен");
    }
}