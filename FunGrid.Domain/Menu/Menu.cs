using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGrid.Domain
{
    public class Menu
    {
        public int Id {get; set;}
        public string Text{get; set;}
        public string HRef {get; set;}
        public string Role {get; set;}
        public string DataToggle {get; set;}
        public List<Menu> DropDown {get;set;}
        public bool IsHeader { get; set; }
    }

}
