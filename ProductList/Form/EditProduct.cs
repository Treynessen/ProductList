using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void EditProduct(ProductInfo product, string positionNumber, string productName, string price)
    {
        int oldPositionNumber = product.PositionNumber;
        try
        {
            product.PositionNumber = Convert.ToInt32(positionNumber);
        }
        catch { }
        product.Name = productName;
        try
        {
            product.Price = Convert.ToInt32(price);
        }
        catch { }
        if (oldPositionNumber != product.PositionNumber)
        {
            for (LinkedListNode<ProductInfoGroup> it = displayedGroups.First; it != null; it = it.Next)
            {
                if (it.Value.ReferenceEquals(product))
                {
                    it.Value.ProductElementsGroup.Visible = false;
                    for (LinkedListNode<ProductInfoGroup> it_2 = it.Next; it_2 != null; it_2 = it_2.Next)
                    {
                        it_2.Value.SetNewGroupYPosition(GetPreviousYPosition(it_2.Value.GetCurrentGroupYPosition()));
                    }
                    panel1.Controls.Remove(it.Value.ProductElementsGroup);
                    displayedGroups.Remove(it);
                    break;
                }
            }
            data.Remove(product);
            AddProduct(product);
            AddGroup(product);
        }
        SerializeToFile();
        MessageBox.Show("Позиция изменена");
    }
}