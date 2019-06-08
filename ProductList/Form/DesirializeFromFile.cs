using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Treynessen.Products;

public partial class Form1 : Form
{
    private LinkedList<ProductInfo> DesirializeFromFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            return formatter.Deserialize(dataFile) as LinkedList<ProductInfo>;
        }
        catch
        {
            return new LinkedList<ProductInfo>();
        }
    }
}