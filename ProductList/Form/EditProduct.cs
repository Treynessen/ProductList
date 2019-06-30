using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void EditProduct(ProductInformation product, string positionNumber, string productName, string price, string barcode)
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
        product.Barcode = barcode;
        if (oldPositionNumber != product.PositionNumber)
        {
            for (LinkedListNode<ProductInfoGroup> it = displayedGroups.First; it != null; it = it.Next)
            {
                // Находим в списке отображенных групп нашу позицию
                if (it.Value.ReferenceEquals(product))
                {
                    // и делаем её невидимой 
                    it.Value.ProductElementsGroup.Visible = false;
                    for (LinkedListNode<ProductInfoGroup> it_2 = it.Next; it_2 != null; it_2 = it_2.Next)
                    {
                        // смещаем последующие позиции из группы вниз
                        it_2.Value.SetNewGroupYPosition(GetPreviousYPosition(it_2.Value.GetCurrentGroupYPosition()));
                    }
                    panel1.Controls.Remove(it.Value.ProductElementsGroup);
                    displayedGroups.Remove(it);
                    break;
                }
            }
            // удаляем товар
            data.Remove(product);
            // снова добавляем его (это было глупое решение - проводить так сортировку, но переделывать уже лень)
            AddProduct(product);
            AddGroup(product);
        }
        SerializeToFile();
        MessageBox.Show("Позиция изменена");
    }
}