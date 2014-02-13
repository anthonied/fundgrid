using FunGrid.Domain;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundgrid.Data
{
    [Alias("GridItems")]
    public class GridItemData: DataObject<GridItem>
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string Owner { get; set; }
        public decimal? Amount { get; set; }
        [ForeignKey(typeof(GridData), OnDelete = "CASCADE")]
        public int GridId { get; set; }

        public GridItem ToDomain()
        {
            return new GridItem() { Id = Id, Amount = Amount, Number = Number, Owner = Owner };
        }
    }
}
