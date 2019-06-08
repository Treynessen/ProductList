using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void AddProductButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ProductNameTextBox.Text)
            && string.IsNullOrEmpty(ProductPriceTextBox.Text)
            && string.IsNullOrEmpty(ProductPositionNumberTextBox.Text))
            return;
        int price = 0, positionNumber = 0;
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
        ProductInfo product = new ProductInfo
        {
            Name = ProductNameTextBox.Text,
            Price = price,
            PositionNumber = positionNumber
        };
        AddProduct(product);
        ProductNameTextBox.Text = ProductPriceTextBox.Text = ProductPositionNumberTextBox.Text = string.Empty;
        SerializeToFile();
        AddGroup(product);
        MessageBox.Show("Товар добавлен");
    }
}