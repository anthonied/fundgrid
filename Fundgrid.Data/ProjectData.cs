using FunGrid.Domain;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthentication.Domain;

namespace Fundgrid.Data
{
    [Alias("Projects")]
    public class ProjectData: DataObject<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [ForeignKey(typeof(User), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int Owner_Id { get; set; }
        public Project ToDomain()
        {
            return new Project() { Id = Id, Description = Description, Image = Image, Name = Name, Owner_Id = Owner_Id.ToString() };
        }
    }
}
