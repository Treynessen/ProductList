using System.Collections.Generic;
using Treynessen.Products;

public partial class ProductsPanelManager
{
    private void DeleteProduct(ProductInformation product)
    {
        LinkedListNode<LinkedList<ProductCell>> pageWithDeletableCell = null;
        LinkedListNode<ProductCell> deletableCell = null;

        bool found = false;
        // Ищем удаляемый товар
        for (var pageNode = pages.First; pageNode != null; pageNode = pageNode.Next)
        {
            for (LinkedListNode<ProductCell> cellNode = pageNode.Value.First; cellNode != null; cellNode = cellNode.Next)
            {
                // Смещаем все последующие товары на GetPreviousYPos(от текущей позиции)
                if (found)
                {
                    int currentYPos = cellNode.Value.Cell.Location.Y;
                    cellNode.Value.SetNewGroupYPosition(GetPreviousYPos(currentYPos));
                }
                if (!found && cellNode.Value.ReferenceEquals(product))
                {
                    // Если просто удалить товар, тогда не получится сместить последующие товары
                    pageWithDeletableCell = pageNode;
                    deletableCell = cellNode;
                    found = true;
                }
            }
            // Если есть ещё страница и был удален товар, тогда переносил первый товар со следующей страницы
            // на текущую
            if (found && pageNode.Next != null)
            {
                int lastProductYPos = pageNode.Value.Last.Value.Cell.Location.Y;
                pageNode.Value.AddLast(pageNode.Next.Value.First.Value);
                pageNode.Value.Last.Value.SetNewGroupYPosition(GetNextYPos(lastProductYPos));
                pageNode.Next.Value.First.Value.Cell.Visible = false;
                productsPanel.Controls.Remove(pageNode.Next.Value.First.Value.Cell);
                pageNode.Next.Value.Remove(pageNode.Next.Value.First);
                // Если страница на которую сделан перенос - текущая страница, 
                // то делаем перенесенный товар видимым
                if (pageNode == currentPage)
                {
                    pageNode.Value.Last.Value.Cell.Visible = true;
                    productsPanel.Controls.Add(pageNode.Value.Last.Value.Cell);
                }
                // Если на следующей странице не осталось товаров, то удаляем её
                if (pageNode.Next.Value.Count == 0)
                {
                    // Если следующая страница - это текущая страница, тогда пытаемся перейти на предыдущую
                    if (pageNode.Next == currentPage && currentPage.Previous != null)
                    {
                        ToPreviousPage();
                        pages.Remove(currentPage.Next);
                    }
                    // Если это текущая страница и она единственная, то удаляем и присваиваем текущей странице
                    // значение null
                    else if (pageNode.Next == currentPage)
                    {
                        pages.Remove(currentPage);
                        currentPage = null;
                    }
                    // Иначе просто удаляем
                    else pages.Remove(pageNode.Next);
                    addPageButtons();
                }
            }
        }

        if (pageWithDeletableCell != null && deletableCell != null)
        {
            deletableCell.Value.Cell.Visible = false;
            productsPanel.Controls.Remove(deletableCell.Value.Cell);
            pageWithDeletableCell.Value.Remove(deletableCell);
            // Если на странице не осталось товаров, то удаляем её
            if (pageWithDeletableCell.Value.Count == 0)
            {
                // Если удаляемая страница - это текущая страница, тогда пытаемся перейти на предыдущую
                if (pageWithDeletableCell == currentPage && currentPage.Previous != null)
                {
                    ToPreviousPage();
                    pages.Remove(currentPage.Next);
                }
                // Если это текущая страница и она единственная, то удаляем и присваиваем текущей странице
                // значение null
                else if (pageWithDeletableCell == currentPage)
                {
                    pages.Remove(currentPage);
                    currentPage = null;
                }
                // Иначе просто удаляем
                else pages.Remove(pageWithDeletableCell);
                addPageButtons();
            }
        }
    }
}