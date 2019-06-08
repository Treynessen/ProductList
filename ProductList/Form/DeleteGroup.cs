using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void DeleteGroup(ProductInfo product)
    {
        LinkedListNode<ProductInfoGroup> groupNode = null;
        for (LinkedListNode<ProductInfoGroup> it = displayedGroups.First; it != null; it = it.Next)
        {
            if (it.Value.ReferenceEquals(product))
            {
                groupNode = it;
                break;
            }
        }
        if (groupNode == null)
            return;
        for(LinkedListNode<ProductInfoGroup> it = groupNode.Next; it != null; it = it.Next)
        {
            it.Value.SetNewGroupYPosition(GetPreviousYPosition(it.Value.GetCurrentGroupYPosition()));
        }
        groupNode.Value.ProductElementsGroup.Visible = false;
        panel1.Controls.Remove(groupNode.Value.ProductElementsGroup);
        displayedGroups.Remove(groupNode);
    }
}