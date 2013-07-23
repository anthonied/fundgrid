using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fundgrid.MVC.Models
{
    public class DonateModel:MenuBase
    {
      public  List<ProjectModel> ProjectModels { get; set; }
    }
}