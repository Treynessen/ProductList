using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void DeleteGroup(ProductInformation product)
    {
        LinkedListNode<ProductInfoGroup> groupNode = null;
        for (LinkedListNode<ProductInfoGroup> it = displayedGroups.First; it != null; it = it.Next)
        {
            // Находим в списке отображенных групп нашу позицию
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
            // смещаем последующие позиции из группы вниз
            it.Value.SetNewGroupYPosition(GetPreviousYPosition(it.Value.GetCurrentGroupYPosition()));
        }
        // делаем товар невидимым и удаляем
        groupNode.Value.ProductElementsGroup.Visible = false;
        panel1.Controls.Remove(groupNode.Value.ProductElementsGroup);
        displayedGroups.Remove(groupNode);
    }
}