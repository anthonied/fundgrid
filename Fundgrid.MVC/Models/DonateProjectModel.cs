using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FunGrid.Domain;

namespace Fundgrid.MVC.Models
{
    public class DonateProjectModel:MenuBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Owner_Id { get; set; }
        public Grid Grid { get; set; }
    }
}