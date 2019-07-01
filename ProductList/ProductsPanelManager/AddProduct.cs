using System.Collections.Generic;
using Treynessen.Products;

public partial class ProductsPanelManager
{
    public void AddProduct(ProductInformation product, ref bool createdPage)
    {
        ProductCell cell = CreateProductCell(product, startedYPos);

        if (currentPage == null)
        {
            pages = new LinkedList<LinkedList<ProductCell>>();
            pages.AddLast(new LinkedList<ProductCell>());
            pages.First.Value.AddLast(cell);
            currentPage = pages.First;
            DisplayCurrentPage();
        }
        // Если у нас уже отображены товары, тогда необходимо найти место для текущего товара
        // и сдвинуть все последующие на NextYPos(от текущей позиции). Если после вставки
        // количество товаров на странице стало больше, чем maxDisplayedCells, тогда переносим последний
        // товар на странице на следующую страницу (тоже самое проделываем и с последующими страницами)
        // Если для товара не нашлось места, значит его номер больше, чем у остальных товаров, поэтому вставляем
        // его на последнюю страницу, в конец (не забывая про maxDisplayedCells)
        // Так же нужно отобразить вставленные или перенесенные товары, если они находятся на текущей странице.
        // Если же отображаемый ранее товар был перенесен на другую страницу, тогда его следует сделать невидимым
        // и удалить из коллекции панели продуктов.
        else
        {
            bool found = false;
            // Ищем позицию для добавленного товара и смещаем все последующие позиции
            for (var pageNode = pages.First; pageNode != null; pageNode = pageNode.Next)
            {
                for (LinkedListNode<ProductCell> cellNode = pageNode.Value.First; cellNode != null; cellNode = cellNode.Next)
                {
                    // Если это перенесенная позиция с прошлой страницы, то пропускаем
                    if (found && cellNode == pageNode.Value.First)
                        continue;
                    if (!found && product.PositionNumber < cellNode.Value.Product.PositionNumber)
                    {
                        cell.Cell.Location = cellNode.Value.Cell.Location;
                        pageNode.Value.AddBefore(cellNode, cell);
                        // Если вставленная позиция на текущей странице, то делаем её видимой
                        if (currentPage == pageNode)
                        {
                            cell.Cell.Visible = true;
                            productsPanel.Controls.Add(cell.Cell);
                        }
                        found = true;
                    }
                    // Сдвигаем все последующие позиции
                    if (found)
                    {
                        int currentYPos = cellNode.Value.Cell.Location.Y;
                        cellNode.Value.SetNewGroupYPosition(GetNextYPos(currentYPos));
                    }
                }
                // Если количество товаров на странице больше максимально возможного,
                // то делаем перенос последнего товара на следующую страницу
                if (pageNode.Value.Count > maxDisplayedCells)
                {
                    pageNode.Value.Last.Value.SetNewGroupYPosition(startedYPos);
                    productsPanel.Controls.Remove(pageNode.Value.Last.Value.Cell);
                    pageNode.Value.Last.Value.Cell.Visible = false;
                    if (pageNode.Next != null)
                    {
                        pageNode.Next.Value.AddFirst(pageNode.Value.Last.Value);
                        // Если перенесенная позиция на текущей странице, то делаем её видимой
                        if (pageNode.Next == currentPage)
                        {
                            pageNode.Next.Value.First.Value.Cell.Visible = true;
                            productsPanel.Controls.Add(pageNode.Next.Value.First.Value.Cell);
                        }
                    }
                    else
                    {
                        pageNode.List.AddLast(new LinkedList<ProductCell>());
                        pageNode.List.Last.Value.AddLast(pageNode.Value.Last.Value);
                        createdPage = true;
                    }
                    pageNode.Value.Remove(pageNode.Value.Last);
                }
            }
            // Если место не найдено, значит добавляем в конец последней страницы
            if (!found)
            {
                // Если количество товаров на последней страницы - максимальное, то
                // создаем новую и переносим туда наш товар
                if (pages.Last.Value.Count + 1 > maxDisplayedCells)
                {
                    pages.AddLast(new LinkedList<ProductCell>());
                    pages.Last.Value.AddLast(cell);
                    createdPage = true;
                }
                else
                {
                    int lastCellYPos = pages.Last.Value.Last.Value.Cell.Location.Y;
                    cell.SetNewGroupYPosition(GetNextYPos(lastCellYPos));
                    pages.Last.Value.AddLast(cell);
                    // Если вставленная на последнюю страницу позиция - на текущей странице, то делаем её видимой
                    if (pages.Last == currentPage)
                    {
                        productsPanel.Controls.Add(cell.Cell);
                        cell.Cell.Visible = true;
                    }
                }
            }
        }
    }
}