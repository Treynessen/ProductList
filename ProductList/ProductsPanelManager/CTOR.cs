using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Treynessen.Products;
using ProductCells = System.Collections.Generic.LinkedList<ProductCell>;

public partial class ProductsPanelManager
{
    Panel productsPanel;

    private int maxDisplayedCells; // максимальное количество товаров на странице
    private LinkedListNode<ProductCells> currentPage; // Текущие отображенные товары
    private LinkedList<ProductCells> pages; // Полный список товаров, разбитых на страницы

    public int CurrentPageNum { get; private set; }
    public int NumberOfPages => pages.Count;

    public event Action NumOfCellsChanged;

    public ProductsPanelManager(LinkedList<ProductInformation> products, Panel productsPanel, int maxDisplayedCells,
        Action<ProductInformation, string, string, string, string> editProduct, Func<ProductInformation, bool> deleteProduct)
    // string в параметре-типе: 1 - позиция; 2 - название; 3 - цена; 4 - штрих-код
    {
        if (products == null)
            throw new ArgumentNullException("База товаров равна null");

        this.maxDisplayedCells = maxDisplayedCells;
        this.productsPanel = productsPanel;
        this.editProduct = editProduct;
        this.deleteProduct = deleteProduct;

        pages = new LinkedList<ProductCells>();
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
                pages.AddLast(new ProductCells());
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