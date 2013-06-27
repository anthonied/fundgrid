using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class Grid
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public List<GridItem> GridItems { get; set; }
    }
}
