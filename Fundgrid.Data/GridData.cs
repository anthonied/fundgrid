using FunGrid.Domain;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundgrid.Data
{
    [Alias("Grids")]
    public class GridData : DataObject<Grid>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? DimensionRows { get; set; }
        public int? DimensionColumns { get; set; }
        public decimal? InitialValue { get; set; }
        public decimal? IncrementValue { get; set; }
        public Status GridStatus { get; set; }
        [ForeignKey(typeof(ProjectData), OnDelete = "CASCADE")]
        public int ProjectId { get; set; }
        public Grid ToDomain()
        {
            return new Grid() {Id = Id, DimensionRows = DimensionRows, DimensionColumns = DimensionColumns, InitialValue = InitialValue, IncrementValue = IncrementValue, GridStatus = GridStatus, Name = Name, Description = Description };
        }
    }
}
