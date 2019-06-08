using System.Drawing;
using System.Windows.Forms;

public class ProductFormElements
{
    public GroupBox ProductElementsGroup { get; set; }
    public Label ProductPositionNumberLabel { get; set; }
    public TextBox ProductPositionNumberTextBox { get; set; }
    public Label ProductNameLabel { get; set; }
    public TextBox ProductNameTextBox { get; set; }
    public Label ProductPriceLabel { get; set; }
    public TextBox ProductPriceTextBox { get; set; }
    public Button EditButton { get; set; }
    public Button DeleteButton { get; set; }

    public ProductFormElements(int yPosition, int width, Font labelFont, Font textBoxFont)
    {
        ProductElementsGroup = new GroupBox();
        ProductElementsGroup.Location = new Point(0, yPosition);
        ProductElementsGroup.Width = width;
        ProductElementsGroup.Height = 72;
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
        ProductPriceTextBox.Visible = true;

        EditButton = new Button();
        EditButton.Font = labelFont;
        EditButton.Width = 120;
        EditButton.Height = 30;
        EditButton.Text = "Изменить";
        EditButton.Location = new Point(627, 8);
        EditButton.Visible = true;

        DeleteButton = new Button();
        DeleteButton.Font = labelFont;
        DeleteButton.Width = 120;
        DeleteButton.Height = 30;
        DeleteButton.Text = "Удалить";
        DeleteButton.Location = new Point(627, 39);
        DeleteButton.Visible = true;

        ProductElementsGroup.Controls.Add(ProductPositionNumberLabel);
        ProductElementsGroup.Controls.Add(ProductPositionNumberTextBox);
        ProductElementsGroup.Controls.Add(ProductNameLabel);
        ProductElementsGroup.Controls.Add(ProductNameTextBox);
        ProductElementsGroup.Controls.Add(ProductPriceLabel);
        ProductElementsGroup.Controls.Add(ProductPriceTextBox);
        ProductElementsGroup.Controls.Add(EditButton);
        ProductElementsGroup.Controls.Add(DeleteButton);
    }
    
    public void SetProductInfo(int productPositionNumber, string productName, int productPrice)
    {
        ProductPositionNumberTextBox.Text = productPositionNumber.ToString();
        ProductNameTextBox.Text = productName;
        ProductPriceTextBox.Text = productPrice.ToString();
    }
}