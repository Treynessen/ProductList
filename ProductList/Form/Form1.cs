using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private int? displayedPosition;

    private LinkedList<ProductInformation> data;
    private FileStream dataFile;

    private LinkedList<ProductInfoGroup> displayedGroups;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        dataFile = new FileStream("products.data", FileMode.OpenOrCreate);
        data = DesirializeFromFile();
        DisplayProductList(data);
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        dataFile.Close();
    }

    private int GetNextYPosition(int currentYPosition) => currentYPosition + 108;

    private int GetPreviousYPosition(int currentYPosition) => currentYPosition - 108;
}