using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private bool EditProduct(ProductInformation product, string positionNumberText, string name, string priceText, string barcode)
    {
        if (string.IsNullOrEmpty(positionNumberText)
            && string.IsNullOrEmpty(name)
            && string.IsNullOrEmpty(priceText))
        {
            return false;
        }
        int? price = null, positionNumber = null;
        try
        {
            price = Convert.ToInt32(priceText);
        }
        catch { }
        try
        {
            positionNumber = Convert.ToInt32(positionNumberText);
        }
        catch { }
        if (!price.HasValue || !positionNumber.HasValue)
            return false;
        if (product.PositionNumber != positionNumber.Value)
        {
            LinkedListNode<ProductInformation> productNode = data.Find(product);
            data.Remove(productNode);
            product.PositionNumber = positionNumber.Value;
            product.Name = name;
            product.Price = price.Value;
            product.Barcode = barcode;
            AddProductToData(product);
        }
        else
        {
            product.PositionNumber = positionNumber.Value;
            product.Name = name;
            product.Price = price.Value;
            product.Barcode = barcode;
        }
        SerializeToFile();
        return true;
    }
}