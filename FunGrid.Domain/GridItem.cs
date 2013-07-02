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
        private bool _isAvailable;
        public bool IsAvailable
        {
            get
            {
                return _isAvailable;
            }
            set
            {
                if (Id != null || Id != 0)
                    _isAvailable = true;
                else
                    _isAvailable = false;
            }
        }
    }
}
