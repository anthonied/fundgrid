using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunGrid.Domain;

namespace Fundgrid.MVC.Models
{
    public class CreateModel:MenuBase
    {
        public Project project { get; set; }
    }
}
