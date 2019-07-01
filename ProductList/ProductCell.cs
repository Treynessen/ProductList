using System.Drawing;
using System.Windows.Forms;
using Treynessen.Products;

public class ProductCell
{
    public ProductInformation Product { get; private set; }

    public GroupBox Cell { get; set; }
    public Label ProductPositionNumberLabel { get; set; }
    public TextBox ProductPositionNumberTextBox { get; set; }
    public Label ProductNameLabel { get; set; }
    public TextBox ProductNameTextBox { get; set; }
    public Label ProductPriceLabel { get; set; }
    public TextBox ProductPriceTextBox { get; set; }
    public Label ProductBarcodeLabel { get; set; }
    public TextBox ProductBarcodeTextBox { get; set; }
    public Button EditButton { get; set; }
    public Button DeleteButton { get; set; }

    public ProductCell(ProductInformation product, int yPosition, int groupWidth, 
        Font labelFont, Font textBoxFont, Font barcodeLabelFont)
    {
        Product = product;

        Cell = new GroupBox();
        Cell.Location = new Point(0, yPosition);
        Cell.Width = groupWidth;
        Cell.Height = 108;
        Cell.Visible = false;

        ProductPositionNumberLabel = new Label();
        ProductPositionNumberLabel.Font = labelFont;
        ProductPositionNumberLabel.Width = 60;
        ProductPositionNumberLabel.Text = "Номер";
        ProductPositionNumberLabel.Location = new Point(6, 11);
        ProductPositionNumberLabel.Visible = true;

        ProductPositionNumberTextBox = new TextBox();
        ProductPositionNumberTextBox.Font = textBoxFont;
        ProductPositionNumberTextBox.Width = 60;
        ProductPositionNumberTextBox.Location = new Point(10, 34);
        ProductPositionNumberTextBox.Text = product.PositionNumber.ToString();
        ProductPositionNumberTextBox.Visible = true;

        ProductNameLabel = new Label();
        ProductNameLabel.Font = labelFont;
        ProductNameLabel.Width = 400;
        ProductNameLabel.Text = "Название";
        ProductNameLabel.Location = new Point(75, 11);
        ProductNameLabel.Visible = true;

        ProductNameTextBox = new TextBox();
        ProductNameTextBox.Font = textBoxFont;
        ProductNameTextBox.Width = 400;
        ProductNameTextBox.Location = new Point(79, 34);
        ProductNameTextBox.Text = product.Name;
        ProductNameTextBox.Visible = true;

        ProductPriceLabel = new Label();
        ProductPriceLabel.Font = labelFont;
        ProductPriceLabel.Width = 131;
        ProductPriceLabel.Text = "Цена";
        ProductPriceLabel.Location = new Point(484, 11);
        ProductPriceLabel.Visible = true;

        ProductPriceTextBox = new TextBox();
        ProductPriceTextBox.Font = textBoxFont;
        ProductPriceTextBox.Width = 131;
        ProductPriceTextBox.Location = new Point(488, 34);
        ProductPriceTextBox.Text = product.Price.ToString();
        ProductPriceTextBox.Visible = true;

        ProductBarcodeLabel = new Label();
        ProductBarcodeLabel.Font = barcodeLabelFont;
        ProductBarcodeLabel.Width = 110;
        ProductBarcodeLabel.Text = "Штрих-код";
        ProductBarcodeLabel.Location = new Point(5, 72);
        ProductBarcodeLabel.Visible = true;

        ProductBarcodeTextBox = new TextBox();
        ProductBarcodeTextBox.Font = textBoxFont;
        ProductBarcodeTextBox.Width = 500;
        ProductBarcodeTextBox.Location = new Point(119, 70);
        ProductBarcodeTextBox.Text = product.Barcode;
        ProductBarcodeTextBox.Visible = true;

        EditButton = new Button();
        EditButton.Font = labelFont;
        EditButton.Width = 120;
        EditButton.Height = 30;
        EditButton.Text = "Изменить";
        EditButton.Location = new Point(627, 32);
        EditButton.Visible = true;

        DeleteButton = new Button();
        DeleteButton.Font = labelFont;
        DeleteButton.Width = 120;
        DeleteButton.Height = 30;
        DeleteButton.Text = "Удалить";
        DeleteButton.Location = new Point(627, 68);
        DeleteButton.Visible = true;

        Cell.Controls.Add(ProductPositionNumberLabel);
        Cell.Controls.Add(ProductPositionNumberTextBox);
        Cell.Controls.Add(ProductNameLabel);
        Cell.Controls.Add(ProductNameTextBox);
        Cell.Controls.Add(ProductPriceLabel);
        Cell.Controls.Add(ProductPriceTextBox);
        Cell.Controls.Add(ProductBarcodeLabel);
        Cell.Controls.Add(ProductBarcodeTextBox);
        Cell.Controls.Add(EditButton);
        Cell.Controls.Add(DeleteButton);
    }
    
    public void RefreshProductInfo()
    {
        ProductPositionNumberTextBox.Text = Product.PositionNumber.ToString();
        ProductNameTextBox.Text = Product.Name;
        ProductPriceTextBox.Text = Product.Price.ToString();
        ProductBarcodeTextBox.Text = Product.Barcode;
    }

    public int GetCurrentGroupYPosition() => Cell.Location.Y;

    public void SetNewGroupYPosition(int yPos)
    {
        int xPos = Cell.Location.X;
        Cell.Location = new Point(xPos, yPos);
    }

    public bool ReferenceEquals(ProductInformation obj) => ReferenceEquals(Product, obj);
}