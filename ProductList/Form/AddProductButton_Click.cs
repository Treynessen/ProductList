using System;
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
        ProductInfo productInfo = new ProductInfo
        {
            Name = ProductNameTextBox.Text,
            Price = price,
            PositionNumber = positionNumber
        };
        if (data.Count == 0)
            data.AddLast(productInfo);
        else
        {
            for (LinkedListNode<ProductInfo> it = data.First; it != null; it = it.Next)
            {
                if (productInfo.PositionNumber < it.Value.PositionNumber)
                {
                    data.AddBefore(it, productInfo);
                    break;
                }
                else if (it.Next == null)
                {
                    data.AddLast(productInfo);
                    break;
                }
            }
        }
        ProductNameTextBox.Text = ProductPriceTextBox.Text = ProductPositionNumberTextBox.Text = string.Empty;
        SerializeToFile();
        RefreshProductList();
        MessageBox.Show("Товар добавлен");
    }
}