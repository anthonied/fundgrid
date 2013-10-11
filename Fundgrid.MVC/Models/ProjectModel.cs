using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fundgrid.MVC.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please supply the name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Owner_Id { get; set; }
    }
}
