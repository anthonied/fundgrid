using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class GridItem
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string Owner { get; set; }
        public decimal? Amount { get; set; }
    }
}
