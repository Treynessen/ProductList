using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void FindButton_Click(object sender, EventArgs e)
    {
        try
        {
            int positionNumber = Convert.ToInt32(FindTextBox.Text);
            LinkedList<ProductInfo> foundProducts = new LinkedList<ProductInfo>(data.Where(d => d.PositionNumber == positionNumber));
            RefreshProductList(foundProducts);
        }
        catch
        {
            MessageBox.Show("Неверно задан номер позиции");
        }
        finally
        {
            FindTextBox.Text = string.Empty;
        }
    }
}