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
        public bool IsAvailible
        {
            get
            {
                if (Id == 0)
                    return true;
                return false;
            }
        }
        public GridItem() { }
        public GridItem(GridItem parameter)
        {
            Id = parameter.Id;
            Number = parameter.Number;
            Owner = parameter.Owner;
            Amount = parameter.Amount;
        }
    }
}
