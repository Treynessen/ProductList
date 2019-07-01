using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;

public partial class ProductsPanelManager
{
    Panel productsPanel;

    private int maxDisplayedCells; // максимальное количество товаров на странице
    private LinkedListNode<LinkedList<ProductCell>> currentPage; // Текущие отображенные товары
    private LinkedList<LinkedList<ProductCell>> pages; // Полный список товаров, разбитых на страницы

    public int CurrentPageNum { get; private set; }
    public int NumberOfPages => pages.Count;

    private Action addPageButtons;

    public ProductsPanelManager(LinkedList<ProductInformation> products, Panel productsPanel, int maxDisplayedCells,
        Func<ProductInformation, string, string, string, string, bool> editProduct, Func<ProductInformation, bool> deleteProduct, Action addPageButtons)
    // string в параметре-типе: 1 - позиция; 2 - название; 3 - цена; 4 - штрих-код
    {
        this.maxDisplayedCells = maxDisplayedCells;
        this.productsPanel = productsPanel;
        this.addPageButtons = addPageButtons;
        this.editProduct = editProduct;
        this.deleteProduct = deleteProduct;

        pages = new LinkedList<LinkedList<ProductCell>>();
        int currentYPosition = startedYPos;
        int count = 1;
        // Распределяем товары по страницам
        foreach (var product in products)
        {
            if (count > maxDisplayedCells)
            {
                currentYPosition = startedYPos;
                count = 1;
            }
            if (count == 1)
            {
                pages.AddLast(new LinkedList<ProductCell>());
            }

            ProductCell cell = CreateProductCell(product, currentYPosition);

            pages.Last.Value.AddLast(cell);
            currentYPosition = GetNextYPos(currentYPosition);
            ++count;
        }
        currentPage = pages.First;
        CurrentPageNum = 1;
    }
}