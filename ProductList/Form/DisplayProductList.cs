using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void DisplayProductList(LinkedList<ProductInfo> productList = null)
    {
        if (displayedGroups != null)
        {
            foreach (var group in displayedGroups)
                group.ProductElementsGroup.Visible = false;
            panel1.Controls.Clear();
        }
        displayedGroups = new LinkedList<ProductInfoGroup>();
        int currentYPosition = 0;
        foreach (var d in productList)
        {
            ProductInfoGroup productGroup = new ProductInfoGroup(
                product: d,
                yPosition: currentYPosition,
                groupWidth: panel1.Width - 20,
                labelFont: new Font("Century Gothic", 10, FontStyle.Regular),
                textBoxFont: new Font("Century Gothic", 12, FontStyle.Regular)
            );
            LinkedListNode<ProductInfoGroup> currentProductGroupNode = new LinkedListNode<ProductInfoGroup>(productGroup);

            productGroup.EditButton.Click += (sender, e) => 
            EditProduct(d, productGroup.ProductPositionNumberTextBox.Text, productGroup.ProductNameTextBox.Text, productGroup.ProductPriceTextBox.Text);
            productGroup.DeleteButton.Click += (sender, e) => DeleteProduct(d);
            displayedGroups.AddLast(currentProductGroupNode);
            panel1.Controls.Add(productGroup.ProductElementsGroup);
            currentYPosition = GetNextYPosition(currentYPosition);
        }
    }
}