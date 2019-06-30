using System.Drawing;
using System.Windows.Forms;
using Treynessen.Products;

public class ProductInfoGroup
{
    private ProductInformation product;

    public GroupBox ProductElementsGroup { get; set; }
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

    public ProductInfoGroup(ProductInformation product, int yPosition, int groupWidth, Font labelFont, Font textBoxFont, Font barcodeLabel)
    {
        this.product = product;

        ProductElementsGroup = new GroupBox();
        ProductElementsGroup.Location = new Point(0, yPosition);
        ProductElementsGroup.Width = groupWidth;
        ProductElementsGroup.Height = 108;
        ProductElementsGroup.Visible = true;

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
        ProductBarcodeLabel.Font = barcodeLabel;
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

        ProductElementsGroup.Controls.Add(ProductPositionNumberLabel);
        ProductElementsGroup.Controls.Add(ProductPositionNumberTextBox);
        ProductElementsGroup.Controls.Add(ProductNameLabel);
        ProductElementsGroup.Controls.Add(ProductNameTextBox);
        ProductElementsGroup.Controls.Add(ProductPriceLabel);
        ProductElementsGroup.Controls.Add(ProductPriceTextBox);
        ProductElementsGroup.Controls.Add(ProductBarcodeLabel);
        ProductElementsGroup.Controls.Add(ProductBarcodeTextBox);
        ProductElementsGroup.Controls.Add(EditButton);
        ProductElementsGroup.Controls.Add(DeleteButton);
    }
    
    public void RefreshProductInfo()
    {
        ProductPositionNumberTextBox.Text = product.PositionNumber.ToString();
        ProductNameTextBox.Text = product.Name;
        ProductPriceTextBox.Text = product.Price.ToString();
        ProductBarcodeTextBox.Text = product.Barcode;
    }

    public int GetCurrentGroupYPosition() => ProductElementsGroup.Location.Y;

    public void SetNewGroupYPosition(int yPos)
    {
        int xPos = ProductElementsGroup.Location.X;
        ProductElementsGroup.Location = new Point(xPos, yPos);
    }

    public bool ReferenceEquals(ProductInformation obj) => ReferenceEquals(product, obj);
}