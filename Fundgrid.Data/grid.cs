//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fundgrid.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class grid
    {
        public grid()
        {
            this.grid_item = new HashSet<grid_item>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<int> dimension_rows { get; set; }
        public Nullable<int> dimension_column { get; set; }
        public Nullable<int> project_id { get; set; }
        public Nullable<decimal> item_value { get; set; }
        public Nullable<decimal> increment_value { get; set; }
        public string status { get; set; }
    
        public virtual ICollection<grid_item> grid_item { get; set; }
        public virtual project project { get; set; }
    }
}
