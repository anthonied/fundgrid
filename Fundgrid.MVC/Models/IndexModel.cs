using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundgrid.MVC.Models
{
    public class IndexModel:MenuBase
    {
        public List<ProjectModel> ProjectModels { get; set; }
    }
}
