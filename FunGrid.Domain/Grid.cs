using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class Grid
    {
        public int Id { get; set; }
        public int? DimensionRows { get; set; }
        public int? DimensionColumns { get; set; }
        public List<List<GridItem>> GridItems { get; set; }
        public decimal? InitialValue { get; set; }
        public decimal? IncrementValue { get; set; }
        public int ItemCount
        {
            get
            {
                int count = 0;
                GridItems.ForEach(gridItemList => count += gridItemList.Count);
                return count;
            }
        }
        public void FillGrid(List<GridItem> existingGridItems)
        {
            int number = 1;
            GridItems = new List<List<GridItem>>();
            for (int i = 0; i < DimensionColumns; i++)
            {
                GridItems.Add(new List<GridItem>());
                for (int j = 0; j < DimensionRows; j++)
                {
                    GridItems[i].Add(new GridItem() { Id = 0, Number = number });
                    existingGridItems.ForEach(gridItem =>
                                        {
                                            if (gridItem.Number == (number))
                                                GridItems[i][j] = new GridItem(gridItem);
                                        });
                    number += 1;
                }
            }
        }
    }
}
