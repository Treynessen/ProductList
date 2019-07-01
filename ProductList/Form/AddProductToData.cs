using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void AddProductToData(ProductInformation product)
    {
        if (data != null)
        {
            LinkedListNode<ProductInformation> productNode = null;
            for (LinkedListNode<ProductInformation> it = data.First; it != null; it = it.Next)
            {
                if (product.PositionNumber < it.Value.PositionNumber)
                {
                    productNode = data.AddBefore(it, product);
                    break;
                }
            }
            if (productNode == null)
                data.AddLast(product);
        }
    }
}