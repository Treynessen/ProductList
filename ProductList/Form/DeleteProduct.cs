using System.Windows.Forms;
using Treynessen.Products;

public partial class Form1 : Form
{
    private bool DeleteProduct(ProductInformation product)
    {
        bool success = data.Remove(product);
        if (success)
            SerializeToFile();
        return success;
    }
}