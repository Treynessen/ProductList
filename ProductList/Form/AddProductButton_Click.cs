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
        {
            MessageBox.Show("Форма не заполнена или заполнена неверно");
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
        if (!positionNumber.HasValue && string.IsNullOrEmpty(ProductNameTextBox.Text) && !price.HasValue)
        {
            MessageBox.Show("Форма не заполнена или заполнена неверно");
            return;
        }
        if (!positionNumber.HasValue)
            positionNumber = 0;
        if (!price.HasValue)
            price = 0;
        ProductInfo product = new ProductInfo
        {
            Name = ProductNameTextBox.Text,
            Price = price.Value,
            PositionNumber = positionNumber.Value
        };
        AddProduct(product);
        ProductNameTextBox.Text = ProductPriceTextBox.Text = ProductPositionNumberTextBox.Text = string.Empty;
        SerializeToFile();
        AddGroup(product);
        MessageBox.Show("Товар добавлен");
    }
}