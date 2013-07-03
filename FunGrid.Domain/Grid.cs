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
        public List<GridItem> GridItems { get; set; }
        public decimal? GridItemValue { get; set; }
    }
}
