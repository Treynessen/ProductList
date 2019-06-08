using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private LinkedList<ProductInfo> data;
    private FileStream dataFile;
    private LinkedList<ProductFormElements> productInfoGroups;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        dataFile = new FileStream("products.data", FileMode.OpenOrCreate);
        data = DesirializeFromFile();
        RefreshProductList();
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        dataFile.Close();
    }
}