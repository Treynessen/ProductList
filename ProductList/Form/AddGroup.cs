using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class Form1 : Form
{
    private void AddGroup(ProductInformation product)
    {
        ProductInfoGroup productGroup = new ProductInfoGroup(
                product: product,
                yPosition: 0,
                groupWidth: panel1.Width - 20,
                labelFont: new Font("Century Gothic", 10, FontStyle.Regular),
                textBoxFont: new Font("Century Gothic", 12, FontStyle.Regular),
                barcodeLabel: new Font("Century Gothic", 14, FontStyle.Regular)
        );
        // Если сейчас отображены позиции определенного ID из товарного отчета и позиция нашего товара
        // совпадает с ID
        if (displayedPosition.HasValue && displayedPosition.Value == product.PositionNumber)
        {
            if (displayedGroups.Count == 0)
                displayedGroups.AddLast(productGroup);
            else
            {
                productGroup.SetNewGroupYPosition(GetNextYPosition(displayedGroups.Last.Value.GetCurrentGroupYPosition()));
                displayedGroups.AddLast(productGroup);
            }
            productGroup.EditButton.Click += (sender, e) =>
            EditProduct(product, productGroup.ProductPositionNumberTextBox.Text, productGroup.ProductNameTextBox.Text, productGroup.ProductPriceTextBox.Text, productGroup.ProductBarcodeTextBox.Text);
            productGroup.DeleteButton.Click += (sender, e) => DeleteProduct(product);
            panel1.Controls.Add(productGroup.ProductElementsGroup);
        }
        else if (!displayedPosition.HasValue)
        {
            LinkedListNode<ProductInformation> productNode = null;
            for (LinkedListNode<ProductInformation> it = data.First; it != null; it = it.Next)
            {
                // Находим наш товар в списке товаров
                if (ReferenceEquals(product, it.Value))
                {
                    productNode = it;
                    break;
                }
            }
            LinkedListNode<ProductInfoGroup> productGroupNode = null;
            // Если у узла товара нет ссылки на предыдущую позицию, значит он первый в списке
            if (productNode.Previous == null)
            {
                productGroupNode = displayedGroups.AddFirst(productGroup);
            }
            // Если нет ссылки на следующий узел, значит наш товар последний в списке
            else if (productNode.Next == null)
            {
                productGroup.SetNewGroupYPosition(GetNextYPosition(displayedGroups.Last.Value.GetCurrentGroupYPosition()));
                productGroupNode = displayedGroups.AddLast(productGroup);
            }
            else
            {
                LinkedListNode<ProductInfoGroup> node = null;
                ProductInformation previousProduct = productNode.Previous.Value;
                for (LinkedListNode<ProductInfoGroup> it = displayedGroups.First; it != null; it = it.Next)
                {
                    // Ищем в списке отображений предыдущий товар
                    if (it.Value.ReferenceEquals(previousProduct))
                    {
                        node = it;
                        break;
                    }
                }
                // Смещаем все последующие позиции и добавляем в отображений наш товар
                productGroup.SetNewGroupYPosition(GetNextYPosition(node.Value.GetCurrentGroupYPosition()));
                productGroupNode = displayedGroups.AddAfter(node, productGroup);
                for (LinkedListNode<ProductInfoGroup> it = productGroupNode.Next; it != null; it = it.Next)
                {
                    it.Value.SetNewGroupYPosition(GetNextYPosition(it.Value.GetCurrentGroupYPosition()));
                }
            }
            productGroup.EditButton.Click += (sender, e) =>
            EditProduct(product, productGroup.ProductPositionNumberTextBox.Text, productGroup.ProductNameTextBox.Text, productGroup.ProductPriceTextBox.Text, productGroup.ProductBarcodeTextBox.Text);
            productGroup.DeleteButton.Click += (sender, e) => DeleteProduct(product);
            panel1.Controls.Add(productGroup.ProductElementsGroup);
        }
    }
}