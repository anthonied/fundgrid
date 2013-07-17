using System;
using System.Collections.Generic;
using System.Linq;

namespace FunGrid.Domain
{
    public class Grid
    {
        public int Id { get; set; }
        public int? DimensionRows { get; set; }
        public int? DimensionColumns { get; set; }
        public List<List<GridItem>> FullGridItems
        {
            get
            {
                return CreateFullGrid();
            }
        }
        private List<List<GridItem>> CreateFullGrid()
        {
            int number = 1;
            var fullGridItems = new List<List<GridItem>>();
            for (int i = 0; i < DimensionRows; i++)
            {
                fullGridItems.Add(new List<GridItem>());
                for (int j = 0; j < DimensionColumns; j++)
                {
                    fullGridItems[i].Add(new GridItem() { Id = 0, Number = number, Amount = GetAmount(number) });
                    ExistingGridItems.ForEach(gridItem =>
                    {
                        if (gridItem.Number == (number))
                            fullGridItems[i][j] = gridItem;
                    });
                    number += 1;
                }
            }
            return fullGridItems;
        }

        private decimal? GetAmount(int number)
        {
            return (InitialValue + (IncrementValue * (number - 1)));
        }

        public List<GridItem> ExistingGridItems { set; private get; }
        public decimal? InitialValue { get; set; }
        public decimal? IncrementValue { get; set; }
        public int ItemCount
        {
            get
            {
                int count = 0;
                FullGridItems.ForEach(gridItemList => count += gridItemList.Count);
                return count;
            }
        }
        public Status GridStatus {get;set; }
    }
}
