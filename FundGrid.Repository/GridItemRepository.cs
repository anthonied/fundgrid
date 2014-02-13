using FunGrid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using Fundgrid.Data;

namespace FundGrid.Repository
{
    public class GridItemRepository : RepositoryBase
    {
        public List<GridItem> GetGridItemsByGridId(int id)
        {
            var gridItemsDb = _db.Select<GridItemData>().Where(x => x.GridId == id).ToList();
            var gridItems = new List<GridItem>();
            foreach (var gridItemDb in gridItemsDb)
                gridItems.Add(gridItemDb.ToDomain());
            return gridItems;
        }
        public void AssignItemToGrid(int gridId, int number, string owner, decimal paidAmount)
        {
            _db.Insert<GridItemData>(new GridItemData() { GridId = gridId, Amount = paidAmount, Number = number, Owner = owner });
        }
    }
}
