using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void AddProduct(ProductInformation product)
    {
        if (data.Count == 0)
            data.AddLast(product);
        else
        {
            for (LinkedListNode<ProductInformation> it = data.First; it != null; it = it.Next)
            {
                if (product.PositionNumber < it.Value.PositionNumber)
                {
                    data.AddBefore(it, product);
                    break;
                }
                else if (it.Next == null)
                {
                    data.AddLast(product);
                    break;
                }
            }
        }
    }
}