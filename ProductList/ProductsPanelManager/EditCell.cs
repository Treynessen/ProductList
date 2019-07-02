using System.Collections.Generic;
using Treynessen.Products;

public partial class ProductsPanelManager
{
    private void EditCell(ProductInformation product)
    {
        for (var pageNode = pages.First; pageNode != null; pageNode = pageNode.Next)
        {
            for (LinkedListNode<ProductCell> cellNode = pageNode.Value.First; cellNode != null; cellNode = cellNode.Next)
            {
                if (cellNode.Value.ReferenceEquals(product))
                {
                    // Удаляем и вставляем ячейку только в том случае, если её позиция должна измениться.
                    if ((cellNode.Previous != null && cellNode.Previous.Value.Product.PositionNumber > product.PositionNumber)
                        || (cellNode.Previous == null && pageNode.Previous != null && pageNode.Previous.Value.Last.Value.Product.PositionNumber > product.PositionNumber)
                        || (cellNode.Next != null && cellNode.Next.Value.Product.PositionNumber < product.PositionNumber)
                        || (cellNode.Next == null && pageNode.Next != null && pageNode.Next.Value.Last.Value.Product.PositionNumber < product.PositionNumber))
                    {
                        DeleteCell(product);
                        AddCell(product);
                    }
                }
            }
        }
    }
}