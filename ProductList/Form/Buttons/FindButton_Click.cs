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
        if (data != null && data.Count > 0)
        {
            if (string.IsNullOrEmpty(FindTextBox.Text))
            {
                if (!displayedPosition.HasValue)
                    return;
                displayedPosition = null;
                DisplayProducts(data);
            }
            else
            {
                int? positionNumber = null;
                try
                {
                    positionNumber = Convert.ToInt32(FindTextBox.Text);
                }
                catch { }
                if (!positionNumber.HasValue)
                {
                    MessageBox.Show("Введен неверный запрос", "Ошибка");
                    return;
                }
                if (displayedPosition.HasValue && displayedPosition.Value == positionNumber.Value)
                    return;
                LinkedList<ProductInformation> foundProducts = new LinkedList<ProductInformation>(data.Where(p => p.PositionNumber == positionNumber.Value));
                displayedPosition = positionNumber;
                DisplayProducts(foundProducts);
            }
        }
    }
}