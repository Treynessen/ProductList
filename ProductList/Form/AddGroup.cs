using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void AddGroup(ProductInfo product)
    {
        ProductInfoGroup productGroup = new ProductInfoGroup(
                product: product,
                yPosition: 0,
                groupWidth: panel1.Width - 20,
                labelFont: new Font("Century Gothic", 10, FontStyle.Regular),
                textBoxFont: new Font("Century Gothic", 12, FontStyle.Regular)
        );
        if (displayedPosition.HasValue && displayedPosition.Value == product.PositionNumber)
        {
            if (displayedGroups.Count == 0)
                displayedGroups.AddLast(productGroup);
            else
            {
                productGroup.SetNewGroupYPosition(GetNextYPosition(displayedGroups.Last.Value.GetCurrentGroupYPosition()));
                displayedGroups.AddLast(productGroup);
            }
            
        }
        else if (!displayedPosition.HasValue)
        {
            LinkedListNode<ProductInfo> productNode = null;
            for (LinkedListNode<ProductInfo> it = data.First; it != null; it = it.Next)
            {
                if (ReferenceEquals(product, it.Value))
                {
                    productNode = it;
                    break;
                }
            }
            LinkedListNode<ProductInfoGroup> productGroupNode = null;
            if (productNode.Previous == null)
            {
                productGroupNode = displayedGroups.AddFirst(productGroup);
            }
            else if (productNode.Next == null)
            {
                productGroup.SetNewGroupYPosition(GetNextYPosition(displayedGroups.Last.Value.GetCurrentGroupYPosition()));
                productGroupNode = displayedGroups.AddLast(productGroup);
            }
            else
            {
                LinkedListNode<ProductInfoGroup> node = null;
                ProductInfo previousProduct = productNode.Previous.Value;
                for (LinkedListNode<ProductInfoGroup> it = displayedGroups.First; it != null; it = it.Next)
                {
                    if (it.Value.ReferenceEquals(previousProduct))
                    {
                        node = it;
                        break;
                    }
                }
                productGroup.SetNewGroupYPosition(GetNextYPosition(node.Value.GetCurrentGroupYPosition()));
                productGroupNode = displayedGroups.AddAfter(node, productGroup);
                for (LinkedListNode<ProductInfoGroup> it = productGroupNode.Next; it != null; it = it.Next)
                {
                    it.Value.SetNewGroupYPosition(GetNextYPosition(it.Value.GetCurrentGroupYPosition()));
                }
            }
        }
        productGroup.EditButton.Click += (sender, e) =>
        EditProduct(product, productGroup.ProductPositionNumberTextBox.Text, productGroup.ProductNameTextBox.Text, productGroup.ProductPriceTextBox.Text);
        productGroup.DeleteButton.Click += (sender, e) => DeleteProduct(product);
        panel1.Controls.Add(productGroup.ProductElementsGroup);
    }
}