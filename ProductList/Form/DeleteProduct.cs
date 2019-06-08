using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void DeleteProduct(ProductInfo product)
    {
        data.Remove(product);
        SerializeToFile();
        DeleteGroup(product);
        MessageBox.Show("Позиция удалена");
    }
}