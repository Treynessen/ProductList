using Treynessen.Products;
using Page = System.Collections.Generic.LinkedListNode<System.Collections.Generic.LinkedList<ProductCell>>;
using Cell = System.Collections.Generic.LinkedListNode<ProductCell>;

public partial class ProductsPanelManager
{
    private void DeleteCell(ProductInformation product)
    {
        Page pageWithDeletableCell = null;
        Cell deletableCell = null;

        bool found = false;
        // Ищем удаляемый товар
        for (Page pageNode = pages.First; pageNode != null; pageNode = pageNode.Next)
        {
            for (Cell cellNode = pageNode.Value.First; cellNode != null; cellNode = cellNode.Next)
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
            // Если есть ещё страница и был удален товар, тогда переносим первый товар со следующей страницы
            // на текущую
            if (found && pageNode.Next != null)
            {
                int lastProductYPos = pageNode.Value.Last.Value.Cell.Location.Y;
                // Добавляем первый товар со следующей страницы на текущую страницу
                pageNode.Value.AddLast(pageNode.Next.Value.First.Value);
                // Устанавливаем перенесенной ячейке новое y-значение
                pageNode.Value.Last.Value.SetNewGroupYPosition(GetNextYPos(lastProductYPos));
                // Делаем эту ячейку невидимой
                pageNode.Value.Last.Value.Cell.Visible = false;
                // Удаляем переносимую ячейку со следующей страницы
                productsPanel.Controls.Remove(pageNode.Next.Value.First.Value.Cell);
                pageNode.Next.Value.Remove(pageNode.Next.Value.First);
                // Если страница на которую сделан перенос - текущая страница, 
                // то делаем перенесенный товар видимым
                if (pageNode == currentPage)
                {
                    pageNode.Value.Last.Value.Cell.Visible = true;
                    productsPanel.Controls.Add(pageNode.Value.Last.Value.Cell);
                }
            }
        }
        if (pageWithDeletableCell != null && deletableCell != null)
        {
            deletableCell.Value.Cell.Visible = false;
            productsPanel.Controls.Remove(deletableCell.Value.Cell);
            pageWithDeletableCell.Value.Remove(deletableCell);

            // Если после удаления ячейки товара на последней странице не осталось товаров, то удаляем её
            if (pages.Last.Value.Count == 0)
            {
                // Если удаляемая страница - это текущая страница, тогда пытаемся перейти на предыдущую
                if (pages.Last == currentPage && currentPage.Previous != null)
                {
                    ToPreviousPage();
                    pages.Remove(pages.Last);
                }
                // Если это текущая страница и она единственная, то удаляем и присваиваем текущей странице
                // значение null
                else if (pages.Last == currentPage)
                {
                    pages.Remove(pages.Last);
                    currentPage = null;
                }
                // Иначе просто удаляем
                else pages.Remove(pages.Last);
                PageAddedOrDeleted?.Invoke();
            }
        }
    }
}