using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private ProductsPanelManager productsPanelManager;
    private const int MAX_DISPLAYED_CELLS = 25;
    private int? displayedPosition;

    private LinkedList<ProductInformation> data;
    private FileStream dataFile;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        dataFile = new FileStream("products.data", FileMode.OpenOrCreate);
        data = DesirializeFromFile();
        DisplayProducts(data);
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        dataFile.Close();
    }
}