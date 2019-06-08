using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void RefreshProductList(LinkedList<ProductInfo> products = null)
    {
        if (productInfoGroups != null)
        {
            foreach (var group in productInfoGroups)
                group.ProductElementsGroup.Visible = false;
            panel1.Controls.Clear();
        }
        int productInfoWidth = panel1.Width - 20;
        productInfoGroups = new LinkedList<ProductFormElements>();
        int currentYPosition = 0;
        if (products == null)
            products = data;
        foreach (var d in products)
        {
            ProductFormElements currentProductGroup = new ProductFormElements(currentYPosition, productInfoWidth, new Font("Century Gothic", 10, FontStyle.Regular), new Font("Century Gothic", 12, FontStyle.Regular));
            currentProductGroup.SetProductInfo(d.PositionNumber, d.Name, d.Price);
            currentProductGroup.EditButton.Click += (sender, e) =>
            {
                try
                {
                    d.PositionNumber = Convert.ToInt32(currentProductGroup.ProductPositionNumberTextBox.Text);
                }
                catch { }
                d.Name = currentProductGroup.ProductNameTextBox.Text;
                try
                {
                    d.Price = Convert.ToInt32(currentProductGroup.ProductPriceTextBox.Text);
                }
                catch { }
                MessageBox.Show("Позиция изменена");
            };
            currentProductGroup.DeleteButton.Click += (sender, e) =>
            {
                data.Remove(d);
                RefreshProductList();
            };
            productInfoGroups.AddLast(currentProductGroup);
            panel1.Controls.Add(productInfoGroups.Last.Value.ProductElementsGroup);
            currentYPosition += 72;
        }
    }
}